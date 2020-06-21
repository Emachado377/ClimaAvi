using ClimaAvi.Dominio.Entidades;
using ClimaAvi.Dominio.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimaAvi.Persistencia
{
    public class PlantaRepository : IPlantaRepository
    {
        private string strConexao;

        public PlantaRepository()
        {
            this.strConexao = "Server=localhost;Port=5432;Database=ClimaAVI;User Id=postgres;Password=81544744";
            // this.strConexao = "Server=localhost;Port=5432;Database=ClimaAVI;User Id=Ruan;Password=root";

        }

        public Guid Alterar(Planta planta)
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
                        comando.CommandText = @"update plantas set  codigo=@CodigoPlanta, nome=@NomePlanta, local=@LocalPlanta, machost=@MacHost where id=@id"; 
                        comando.Parameters.AddWithValue("codigoPlanta", planta.CodigoPlanta);
                        comando.Parameters.AddWithValue("nomePlanta", planta.NomePlanta);
                        comando.Parameters.AddWithValue("localPlanta", planta.LocalPlanta);
                        comando.Parameters.AddWithValue("machost", planta.MacHost);
                        comando.Parameters.AddWithValue("id", planta.Id);
                        comando.ExecuteNonQuery();
                        transacao.Commit();
                        con.Close();
                        return planta.Id;
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
                        comando.CommandText = @"delete from plantas where id=@id";
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

        public Guid Inserir(Planta planta)
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
                        comando.CommandText = @"insert into plantas(id, codigo, nome, local, machost) values (@id, @CodigoPlanta, @NomePlanta, @LocalPlanta, @MacHost)";
                        comando.Parameters.AddWithValue("codigoPlanta", planta.CodigoPlanta);
                        comando.Parameters.AddWithValue("nomePlanta", planta.NomePlanta);
                        comando.Parameters.AddWithValue("localPlanta", planta.LocalPlanta);
                        comando.Parameters.AddWithValue("machost", planta.MacHost);
                        comando.Parameters.AddWithValue("id", planta.Id);
                        comando.ExecuteNonQuery();
                        transacao.Commit();
                        con.Close();

                        return planta.Id;
                    }
                    catch (NpgsqlException e)
                    {
                        transacao.Rollback();
                        throw e;
                    }
                }
            }
        }

        public Planta Selecionar(Guid id)
        {
            Planta planta = null;
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from plantas where id=@id";
                comando.Parameters.AddWithValue("id", id);
                NpgsqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    planta = new Planta();
                    planta.CodigoPlanta = Convert.ToInt32(leitor["codigo"].ToString());
                    planta.NomePlanta = leitor["nome"].ToString();
                    planta.LocalPlanta = leitor["local"].ToString();
                    planta.MacHost = leitor["machost"].ToString();
                    planta.Id = Guid.Parse(leitor["id"].ToString());
                }
            }
            return planta;
        }

        public List<Planta> SelecionarTodos()
        {
            List<Planta> plantas = new List<Planta>();
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from plantas";
                NpgsqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    plantas.Add(new Planta()
                    {
                        Id = Guid.Parse(leitor["id"].ToString()),
                        CodigoPlanta = Convert.ToInt32(leitor["codigo"].ToString()),
                        NomePlanta = leitor["nome"].ToString(),
                        LocalPlanta = leitor["local"].ToString(),
                        MacHost = leitor["machost"].ToString(),
                    });
                }
            }
            return plantas;
        }
    }
}

