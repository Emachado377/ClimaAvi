using ClimaAvi.Aplicacao;
using ClimaAvi.Dominio.Interfaces;
using ClimaAvi.Persistencia;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ClimaAviAPI.App_Start
{

    public class AccessTokenProvider : OAuthAuthorizationServerProvider
    {
        //private UsuarioApplication usuarioApplication;
        //private IUsuarioRepository usuarioRepository;

        private UserAplicacao userAplicacao;
        private IUserRepository userRepository;

       // private PlantaAplicacao plantaAplicacao;
       // private IPlantaRepository plantaRepository;

        public AccessTokenProvider()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexao"].ToString();
            userRepository = new UserRepository(connectionString);
            userAplicacao = new UserAplicacao(userRepository);

        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (userAplicacao.Autenticar(context.UserName, context.Password))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));

                context.Validated(identity);
            }
            else
            {
                context.SetError("Acesso Inválido", "Usuario ou senha são inválidos");
                return;
            }
        }
    }
}