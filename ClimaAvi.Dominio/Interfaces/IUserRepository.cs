using ClimaAvi.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Dominio.Interfaces
{
    public interface IUserRepository
    {
        User Selecionar(Guid id);
        List<User> SelecionarTodos();
        Guid Inserir(User user);
        Guid Alterar(User user);
        void Excluir(Guid id);
    }
}
