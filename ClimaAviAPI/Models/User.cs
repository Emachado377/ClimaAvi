using System;
using System.ComponentModel.DataAnnotations;

namespace ClimaAvi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(int codigo, string name, string lastName, string email, string password, string token)
        {
            Codigo = codigo;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Token = token;
        }
    }
}