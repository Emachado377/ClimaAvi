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
            this.strConexao = "Server=localhost;Port=5432;Database=ClimaAVI;User Id=postgres;Password=81544744";
           // this.strConexao = "Server=localhost;Port=5432;Database=ClimaAVI;User Id=Ruan;Password=root";
           
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
                        comando.CommandText = @"delete from sensorgas where MacHostGas = (select MacHostGas from sensorgas where id = @id)";
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
                        comando.CommandText = @"insert into sensorgas (id, Metano, Propeno, Hidrogenio, Fumaca, LeituraGas,MacHostGas) values (@id, @Metano, @Propeno, @Hidrogenio, @Fumaca, @LeituraGas,@MacHostGas)";
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
            throw new NotImplementedException();
        }

        public List<SensorGas> SelecionarTodos()
        {
            List<SensorGas> dados = new List<SensorGas>();
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from sensorgas";
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
                        LeituraGas = Convert.ToDateTime(leitor["LeituraGas"].ToString()),
                        MacHostGas = leitor["MacHostGas"].ToString(),
                    });
                }
            }
            return dados;
        }
    }
}
