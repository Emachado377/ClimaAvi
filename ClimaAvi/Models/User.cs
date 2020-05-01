using System;
using System.ComponentModel.DataAnnotations;

namespace ClimaAvi.Models
{
    public class User
    {
        public Guid Id { get; }
        [Display(Name = "Codigo")]
        [Range(minimum: 1, maximum: 50, ErrorMessage = "Codigo do Aluno deve ser entre 1 e 50")]
        public int Code { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo Nome deve ser preenchido")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Nome deve ter entre 4 e 50 caracteres!")]
        public string Name { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Campo Nome deve ser preenchido")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Nome deve ter entre 4 e 50 caracteres!")]
        public string LastName { get; set; }

        [Display(Name = "E-mail")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Formato do E-mail Inválido")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha deve ser preenchida!")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Senha deve ter entre 4 e 15 caracteres")]
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