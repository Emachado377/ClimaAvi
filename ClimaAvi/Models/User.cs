using System;

namespace ClimaAvi.Models
{
    public class User
    {
        public Guid Id { get; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(int code, string name, string email, string phone, string password)
        {
            Code = code;
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }
    }
}