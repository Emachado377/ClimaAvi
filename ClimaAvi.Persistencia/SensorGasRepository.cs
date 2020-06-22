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
    public class SensorGasRepository : ISensorGasRepository
    {

        private string strConexao;

        public SensorGasRepository()
        {
            //this.strConexao = "Server=localhost;Port=5432;Database=ClimaAVI;User Id=postgres;Password=81544744";
            this.strConexao = "Server=localhost;Port=5432;Database=ClimaAVI;User Id=Ruan;Password=root";
           
        }
        public Guid Alterar(SensorGas sensorGas)
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
                        comando.CommandText = @"delete from sensorgas where MacHost = (select MacHost from sensorgas where id = @id)";
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

        public Guid Inserir(SensorGas sensorGas)
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
                        comando.CommandText = @"insert into sensorgas (id, Metano, Propeno, Hidrogenio, Fumaca, Leitura,MacHost) values (@id, @Metano, @Propeno, @Hidrogenio, @Fumaca, @LeituraGas,@MacHostGas)";
                        comando.Parameters.AddWithValue("@Metano", sensorGas.Metano);
                        comando.Parameters.AddWithValue("@Propeno", sensorGas.Propeno);
                        comando.Parameters.AddWithValue("@Hidrogenio", sensorGas.Hidrogenio);
                        comando.Parameters.AddWithValue("@Fumaca", sensorGas.Fumaca);
                        comando.Parameters.AddWithValue("@LeituraGas", sensorGas.LeituraGas);
                        comando.Parameters.AddWithValue("@MacHostGas", sensorGas.MacHostGas);
                        comando.Parameters.AddWithValue("@id", sensorGas.Id);
                        comando.ExecuteNonQuery();
                        transacao.Commit();
                        con.Close();

                        return sensorGas.Id;
                    }
                    catch (NpgsqlException e)
                    {
                        transacao.Rollback();
                        throw e;
                    }
                }
            }
        }

        public SensorGas Selecionar(Guid id)
        {
            SensorGas sensorGas = null;
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from sensorgas where machost = (select machost from plantas where id = @id) ORDER BY leitura DESC LIMIT 1";
                comando.Parameters.AddWithValue("id", id);
                NpgsqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    sensorGas = new SensorGas();
                    sensorGas.Id = Guid.Parse(leitor["id"].ToString());
                    sensorGas.Metano = Convert.ToDecimal(leitor["Metano"].ToString());
                    sensorGas.Propeno = Convert.ToDecimal(leitor["Propeno"].ToString());
                    sensorGas.Hidrogenio = Convert.ToDecimal(leitor["Hidrogenio"].ToString());
                    sensorGas.Fumaca = Convert.ToDecimal(leitor["Fumaca"].ToString());
                    sensorGas.LeituraGas = Convert.ToDateTime(leitor["Leitura"].ToString());
                    sensorGas.MacHostGas = leitor["machost"].ToString();

                }
            }
            return sensorGas;
        }

        public List<SensorGas> SelecionarTodos(Guid id)
        {
            List<SensorGas> dados = new List<SensorGas>();
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from sensorgas where machost = (select machost from plantas where id = @id)";
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                NpgsqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    dados.Add(new SensorGas()
                    {
                        Id = Guid.Parse(leitor["id"].ToString()),
                        Metano = Convert.ToDecimal(leitor["Metano"].ToString()),
                        Propeno = Convert.ToDecimal(leitor["Propeno"].ToString()),
                        Hidrogenio = Convert.ToDecimal(leitor["Hidrogenio"].ToString()),
                        Fumaca = Convert.ToDecimal(leitor["Fumaca"].ToString()),
                        LeituraGas = Convert.ToDateTime(leitor["Leitura"].ToString()),
                        MacHostGas = leitor["MacHost"].ToString(),
                    });
                }
            }
            return dados;
        }
    }
}
