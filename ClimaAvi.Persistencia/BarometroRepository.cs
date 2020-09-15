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
    public class BarometroRepository : IBarometroRepository
    {
        private string strConexao;

        public BarometroRepository()
        {
            this.strConexao = "Server=localhost;Port=5432; Database=ClimaAVI; User Id=postgres; Password=81544744;";
        }
        public Guid Alterar(Barometro barometro)
        {
            throw new NotImplementedException();
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
                        comando.CommandText = @"delete from barometro where machost = (select machost from barometro where id = @id)";
                        comando.Parameters.AddWithValue("@id", id);
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

        public Guid Inserir(Barometro barometro)
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
                        comando.CommandText = @"insert into barometro (id, altitude, temperatura, pressaoatmosferica, umidadear, leitura,machost) values (@id, @altitude,@temperatura, @pressaoatmosferica, @umidadear, @leiturabarometro, @machostbarometro)";
                        comando.Parameters.AddWithValue("@altitude", barometro.Altitude);
                        comando.Parameters.AddWithValue("@temperatura", barometro.Temperatura);
                        comando.Parameters.AddWithValue("@pressaoatmosferica", barometro.PressaoAtmosferica);
                        comando.Parameters.AddWithValue("@umidadear", barometro.UmidadeAr);
                        comando.Parameters.AddWithValue("@leiturabarometro", barometro.LeituraBarometro);
                        comando.Parameters.AddWithValue("@machostbarometro", barometro.MacHostBarometro);
                        comando.Parameters.AddWithValue("@id", barometro.Id);
                        comando.ExecuteNonQuery();
                        transacao.Commit();
                        con.Close();

                        return barometro.Id;
                    }
                    catch (NpgsqlException e)
                    {
                        transacao.Rollback();
                        throw e;
                    }
                }
            }
        }

        public Barometro Selecionar(Guid id)
        {
            Barometro barometro = null;
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from barometro where machost = (select machost from plantas where id = @id) ORDER BY leitura DESC LIMIT 1";
                comando.Parameters.AddWithValue("id", id);
                NpgsqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    barometro = new Barometro();
                    barometro.Id = Guid.Parse(leitor["id"].ToString());
                    barometro.Altitude = Convert.ToDecimal(leitor["altitude"].ToString());
                    barometro.Temperatura = Convert.ToDecimal(leitor["temperatura"].ToString());
                    barometro.PressaoAtmosferica = Convert.ToDecimal(leitor["pressaoatmosferica"].ToString());
                    barometro.UmidadeAr = Convert.ToDecimal(leitor["umidadear"].ToString());
                    barometro.LeituraBarometro = Convert.ToDateTime(leitor["leitura"].ToString());
                    barometro.MacHostBarometro = leitor["machost"].ToString();
                    
                }
            }
            return barometro;
        }

        public List<Barometro> SelecionarTodos(Guid id, DateTime dataInicial, DateTime dataFinal)
        {
            List<Barometro> dados = new List<Barometro>();
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = @"select * from barometro where machost = (select machost from plantas where id = @id) and leitura BETWEEN @dataInicial and @dataFinal ORDER BY leitura ASC LIMIT 43200";
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@dataInicial", dataInicial);
                comando.Parameters.AddWithValue("@dataFinal", dataFinal);
                comando.ExecuteNonQuery();
                NpgsqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    dados.Add(new Barometro()
                    {
                        Id = Guid.Parse(leitor["id"].ToString()),
                        Altitude = Convert.ToDecimal(leitor["altitude"].ToString()),
                        Temperatura = Convert.ToDecimal(leitor["temperatura"].ToString()),
                        PressaoAtmosferica = Convert.ToDecimal(leitor["pressaoatmosferica"].ToString()),
                        UmidadeAr = Convert.ToDecimal(leitor["umidadear"].ToString()),
                        LeituraBarometro = Convert.ToDateTime(leitor["leitura"].ToString()),
                        MacHostBarometro = leitor["machost"].ToString(),
                    });
                }
            }
            return dados;
        }
    }
}
