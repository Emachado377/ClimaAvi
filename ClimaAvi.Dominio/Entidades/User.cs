using System;

namespace ClimaAvi.Dominio.Entidades
{
    public class User
    {
        public Guid Id { get; }
        public int Code { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(int code, string name, string lastName, string email, string password)
        {
            Code = code;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}