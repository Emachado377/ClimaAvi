using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Aplicacao
{
    public class UserAplicacao
    {
        IUserRepository userRepository;

        public UserAplicacao(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Guid CadastrarProduto(User user)
        {
            if (string.IsNullOrEmpty(user.Email))
            {
                throw new ApplicationException("Endereço E-mail não informado!");
            }

            if (this.userRepository.Selecionar(user.Id) == null)
            {
                user.Id = Guid.NewGuid();
                return this.userRepository.Inserir(user);
            }
            else
            {
                return this.userRepository.Alterar(user);
            }
        }

        public void Excluir(Guid id)
        {
            this.userRepository.Excluir(id);
        }

        public User Selecionar(Guid id)
        {
            return this.userRepository.Selecionar(id);
        }

        public List<User> SelecionarTodos()
        {
            return this.userRepository.SelecionarTodos();
        }

    }
}
