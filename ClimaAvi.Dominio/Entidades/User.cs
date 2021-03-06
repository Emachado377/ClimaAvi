﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClimaAvi.Dominio.Entidades
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Codigo")]
        public int Codigo { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        public string Password { get; set; }
       

        public User()
        {
            Id = Guid.NewGuid();
        }

        public User(int codigo, string name, string lastName, string email, string password)
        {
            Codigo = codigo;
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}