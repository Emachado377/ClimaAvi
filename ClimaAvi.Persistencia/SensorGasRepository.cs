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
            this.strConexao = "Server=localhost;Port=5432; Database=ClimaAVI; User Id=postgres; Password=81544744";

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
                        comando.CommandText = @"insert into sensorgas (id, metano, propeno, hidrogenio, fumaca, leituraGas,machostGas) values (@id, @metano, @propeno, @hidrogenio, @fumaca, @leituraGas,@machostGas)";
                        comando.Parameters.AddWithValue("@metano", sensorGas.Metano);
                        comando.Parameters.AddWithValue("@propeno", sensorGas.Propeno);
                        comando.Parameters.AddWithValue("@hidrogenio", sensorGas.Hidrogenio);
                        comando.Parameters.AddWithValue("@fumaca", sensorGas.Fumaca);
                        comando.Parameters.AddWithValue("@leituraGas", sensorGas.LeituraGas);
                        comando.Parameters.AddWithValue("@machostGas", sensorGas.MachostGas);
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
                    sensorGas.Metano = Convert.ToDecimal(leitor["metano"].ToString());
                    sensorGas.Propeno = Convert.ToDecimal(leitor["propeno"].ToString());
                    sensorGas.Hidrogenio = Convert.ToDecimal(leitor["hidrogenio"].ToString());
                    sensorGas.Fumaca = Convert.ToDecimal(leitor["fumaca"].ToString());
                    sensorGas.LeituraGas = Convert.ToDateTime(leitor["leituraGas"].ToString());
                    sensorGas.MachostGas = leitor["machostGas"].ToString();

                }
            }
            return sensorGas;
        }

        public List<SensorGas> SelecionarTodos(Guid id, DateTime dataInicial, DateTime dataFinal)
        {
            List<SensorGas> dados = new List<SensorGas>();
            using (NpgsqlConnection con = new NpgsqlConnection(this.strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "select * from sensorgas where machostGas = (select machost from plantas where id = @id) and leitura BETWEEN @dataInicial and @dataFinal ORDER BY leitura DESC LIMIT 30";
                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@dataInicial", dataInicial);
                comando.Parameters.AddWithValue("@dataFinal", dataFinal);
                comando.ExecuteNonQuery();
                NpgsqlDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    dados.Add(new SensorGas()
                    {
                        Id = Guid.Parse(leitor["id"].ToString()),
                        Metano = Convert.ToDecimal(leitor["metano"].ToString()),
                        Propeno = Convert.ToDecimal(leitor["propeno"].ToString()),
                        Hidrogenio = Convert.ToDecimal(leitor["hidrogenio"].ToString()),
                        Fumaca = Convert.ToDecimal(leitor["fumaca"].ToString()),
                        LeituraGas = Convert.ToDateTime(leitor["eituraGas"].ToString()),
                        MachostGas = leitor["MachostGas"].ToString(),
                    });
                }
            }
            return dados;
        }
    }
}
