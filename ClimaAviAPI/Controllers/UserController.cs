
using ClimaAvi.Aplicacao;
using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClimaAviAPI.Controllers
{
    public class UserController : ApiController
    {
        public HttpResponseMessage Get()
        {
            UserRepository userRepository = new UserRepository();
            UserAplicacao userAplicacao = new UserAplicacao(userRepository);
            List<User> users = new List<User>();

            var urs = userAplicacao.SelecionarTodos();

            foreach (var busca in urs)
            {
                users.Add(new User()
                {
                    Id = busca.Id,
                    Codigo = busca.Codigo,
                    Name = busca.Name,
                    LastName = busca.Name,
                    Email = busca.Email,
                    Password = busca.Password
                });
            }
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        // GET api/values/5
        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                var urs = Procurar(id);
               
                if (urs.Id == id)
                {                    
                    return Request.CreateResponse(HttpStatusCode.OK, urs);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                //falha é trata aqui
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] User user)
        {
            try
            {
                Guid id = Inserir(user);
                return Request.CreateResponse(HttpStatusCode.OK, id);
            }
            catch (ApplicationException e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private Guid Inserir(User user)
        {
            UserRepository userRepository = new UserRepository();
            UserAplicacao userAplicacao = new UserAplicacao(userRepository);

            //Adapter
            ClimaAvi.Dominio.Entidades.User ursDominio = new ClimaAvi.Dominio.Entidades.User()
            {
                Id = Guid.Empty,
                Codigo = user.Codigo,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };

            var id = userAplicacao.CadastrarUser(ursDominio);

            return id;

        }

        // PUT api/values/5
        public HttpResponseMessage Put(Guid id, [FromBody] User user)
        {
            try
            {
                var busca = Procurar(id);
                if (busca != null)
                {
                    Guid id_user = Alterar(user);
                    return Request.CreateResponse(HttpStatusCode.OK, id_user);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private Guid Alterar(User user)
        {
            UserRepository userRepository = new UserRepository();
            UserAplicacao userAplicacao = new UserAplicacao(userRepository);

            //Adapter
            ClimaAvi.Dominio.Entidades.User ursDominio = new ClimaAvi.Dominio.Entidades.User()
            {
                Id = user.Id,
                Codigo = user.Codigo,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
            };

            var id = userAplicacao.CadastrarUser(ursDominio);

            return id;
        }

        private User Procurar(Guid id_user)
        {
            UserRepository userRepository = new UserRepository();
            UserAplicacao userAplicacao = new UserAplicacao(userRepository);

            var urs = userAplicacao.Selecionar(id_user);
             
            return new User()
            {
                Id = urs.Id,
                Codigo = urs.Codigo,
                Name = urs.Name,
                LastName = urs.LastName,
                Email = urs.Email,
                Password = urs.Password,
            };
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                Excluir(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        private void Excluir(Guid id_user)
        {
            UserRepository userRepository = new UserRepository();
            UserAplicacao userAplicacao = new UserAplicacao(userRepository);
            userAplicacao.Excluir(id_user);
        }
    }
}
