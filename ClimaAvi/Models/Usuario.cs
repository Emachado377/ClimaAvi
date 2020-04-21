namespace ClimaAvi.Models
{
    public class Usuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }

        public Usuario()
        {
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