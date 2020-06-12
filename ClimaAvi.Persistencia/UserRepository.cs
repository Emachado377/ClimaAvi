using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Dominio.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Persistencia
{
    public class UserRepository : IUserRepository
    {

        private string strConexao;

        public UserRepository()
        {
            this.strConexao = "Server=localhost;Port=44313; Database=Db_ClimaAvi; User Id=postgres; Password=81544744";

        }


        public Guid Alterar(User user)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                using (var transacao = con.BeginTransaction())
                {
                    try
                    {
                        NpgsqlCommand comando = new NpgsqlCommand();
                        comando.Connection = con;
                        comando.Transaction = transacao;
                        comando.CommandText = @"update Usuarios set codigo=@codigo, Name=@Nome, LastName=@Sobrenome, Email@Email, Password=@Senha where id=@id";
                        comando.Parameters.AddWithValue("Codigo", user.Codigo);
                        comando.Parameters.AddWithValue("Nome", user.Name);
                        comando.Parameters.AddWithValue("Sobrenome", user.LastName);
                        comando.Parameters.AddWithValue("Email", user.Email);
                        comando.Parameters.AddWithValue("Senha", user.Password);
                        comando.Parameters.AddWithValue("id", user.Id);
                        comando.ExecuteNonQuery();
                        transacao.Commit();
                        con.Close();
                        return user.Id;
                    }
                    catch (NpgsqlException e)
                    {
                        transacao.Rollback();
                        throw e;
                    }
                }
            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                using (var transacao = con.BeginTransaction())
                {
                    try
                    {
                        NpgsqlCommand comando = new NpgsqlCommand();
                        comando.Connection = con;
                        comando.Transaction = transacao;
                        comando.CommandText = @"delete from Usuarios where id=@id";
                        comando.Parameters.AddWithValue("id", id);
                        comando.ExecuteNonQuery();
                        transacao.Commit();
                        con.Close();
                    }
                    catch (NpgsqlException e)
                    {
                        transacao.Rollback();
                        throw e;
                    }
                }
            }
        }

        public Guid Inserir(User user)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                using (var transacao = con.BeginTransaction())
                {
                    try
                    {      
                        NpgsqlCommand comando = new NpgsqlCommand();
                        comando.Connection = con;
                        comando.Transaction = transacao;
                        comando.CommandText = @"insert into Usuarios (id, codigo, Nome, Sobrenome, Email, Senha) values (@id, @codigo, @Name, @LastName, @Email, @Password)";
                        comando.Parameters.AddWithValue("Codigo", user.Codigo);
                        comando.Parameters.AddWithValue("Nome", user.Name);
                        comando.Parameters.AddWithValue("Sobrenome", user.LastName);
                        comando.Parameters.AddWithValue("Email", user.Email);
                        comando.Parameters.AddWithValue("Senha", user.Password);
                        comando.Parameters.AddWithValue("id", user.Id);
                        comando.ExecuteNonQuery();
                        transacao.Commit();
                        con.Close();

                        return user.Id;
                    }
                    catch (NpgsqlException e)
                    {
                        transacao.Rollback();
                        throw e;
                    }
                }
            }
        }

        public User Selecionar(Guid id)
        {
            User user = null;
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from Usuarios where id=@id";
                comando.Parameters.AddWithValue("id", id);
                NpgsqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    user = new User();
                    user.Codigo = Convert.ToInt32(leitor["codigo"].ToString());
                    user.Name = leitor["nome"].ToString();
                    user.LastName = leitor["sobrenome"].ToString();
                    user.Email = leitor["email"].ToString();
                    user.Password = leitor["senha"].ToString();
                    user.Id = Guid.Parse(leitor["id"].ToString());
                }
            }
            return user;
        }

        public List<User> SelecionarTodos()
        {
            List<User> users = new List<User>();
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from Usuario";
                NpgsqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    users.Add(new User()
                    {                        
                       Id = Guid.Parse(leitor["id"].ToString()),
                       Codigo = Convert.ToInt32(leitor["codigo"].ToString()),
                       Name = leitor["nome"].ToString(),
                       LastName = leitor["sobrenome"].ToString(),
                       Email = leitor["email"].ToString(),
                       Password = leitor["senha"].ToString(),                
                           
                    });
                }
            }
            return users;
        }
    }
}

