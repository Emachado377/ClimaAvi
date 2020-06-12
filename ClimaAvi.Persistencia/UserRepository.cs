using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Persistencia
{
    class UserRepository : IUserRepository
    {
        public Guid Alterar(User user)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            using (var dbUser = new Contexto())
            //dbUser.Users.Remove(id);
            //dbUser.SaveChanges();
            throw new NotImplementedException();
        }

        public Guid Inserir(User user)
        {
            //throw new NotImplementedException();
            using (var dbUser  = new Contexto())
            {
                try
                {
                    dbUser.Users.Add(user);
                    dbUser.SaveChanges();
                }
                catch
                {

                }
               
            }
            return user.Id;

        }

        public User Selecionar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<User> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
