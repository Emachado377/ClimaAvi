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

        private string connectionString;
           

        public UserRepository()
        {
            //Academico  //////////////////////////////////////////
            connectionString = "Server=localhost;Port=44313; Database=ClimaAVI; User Id=postgres; Password=81544744";

        }

        public Guid Alterar(User user)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var transacao = con.BeginTransaction())
                {
                    try
                    {
                        NpgsqlCommand comando = new NpgsqlCommand();
                        comando.Connection = con;
                        comando.Transaction = transacao;
                        comando.CommandText = @"update usuario set Codigo=@codigo, nome=@Name, sobrenome=@LastName, email=@Email, senha=@Password where id=@id";
                        comando.Parameters.AddWithValue("codigo", user.Codigo);
                        comando.Parameters.AddWithValue("Name", user.Name);
                        comando.Parameters.AddWithValue("LastName", user.LastName);
                        comando.Parameters.AddWithValue("Email", user.Email);
                        comando.Parameters.AddWithValue("Password", user.Password);
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
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var transacao = con.BeginTransaction())
                {
                    try
                    {
                        NpgsqlCommand comando = new NpgsqlCommand();
                        comando.Connection = con;
                        comando.Transaction = transacao;
                        comando.CommandText = @"delete from usuario where id=@id";
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
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                using (var transacao = con.BeginTransaction())
                {
                    try
                    {      
                        NpgsqlCommand comando = new NpgsqlCommand();
                        comando.Connection = con;
                        comando.Transaction = transacao;
                        comando.CommandText = @"insert into usuario (id, codigo, nome, sobrenome, email, senha) values (@id, @Codigo, @Name, @LastName, @Email, @Password)";
                        comando.Parameters.AddWithValue("id", user.Id);
                        comando.Parameters.AddWithValue("codigo", user.Codigo);
                        comando.Parameters.AddWithValue("Name", user.Name);
                        comando.Parameters.AddWithValue("LastName", user.LastName);
                        comando.Parameters.AddWithValue("Email", user.Email);
                        comando.Parameters.AddWithValue("Password", user.Password);                       
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
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from usuario where id=@id";
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
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from usuario";
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

