using System;

namespace ClimaAvi.Models
{
    public class Usuario
    {
        public Guid Id { get; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }

        public Usuario()
        {
            Id = Guid.NewGuid();
        }

        public Usuario(int codigo, string nome, string email, int telefone)
        {
            Codigo = codigo;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}