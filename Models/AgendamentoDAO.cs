using AppExemplo.Configs;
using AppWeb.Configs;

namespace AppExemplo.Models
{
    public class AgendamentoDAO
    {
        private readonly Conexao _conexao;
        public AgendamentoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Agendamento agendamento)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO Agendamento (data_agen, horaInicial_agen, horaFinal_agen, status_agen, valor_total, data_reserva_agen, id_qua_fk) VALUES (@_data, @_horaInicial, @_horaFinal, @_status, @_valorTotal, @_dataReserva, @_id_qua_fk)");

                // comando.Parameters.AddWithValue("@_clienteId", agendamento.ClienteId);
                comando.Parameters.AddWithValue("@_data", agendamento.Data);
                comando.Parameters.AddWithValue("@_horaInicial", agendamento.HoraInicial);
                comando.Parameters.AddWithValue("@_horaFinal", agendamento.HoraFinal);
                comando.Parameters.AddWithValue("@_status", agendamento.Status);
                comando.Parameters.AddWithValue("@_valorTotal", agendamento.ValorTotal);
                comando.Parameters.AddWithValue("@_dataReserva", agendamento.DataReserva);
                comando.Parameters.AddWithValue("@_id_qua_fk", agendamento.QuadraId);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<Agendamento> ListarTodos()
        {

            var lista = new List<Agendamento>();

            var comando = _conexao.CreateCommand("SELECT * FROM agendamento");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var agendamento = new Agendamento
                {
                    Id = leitor.GetInt32("id_agen"),
                    // ClienteId = leitor.GetInt32("clienteId"),
                    Data = leitor.GetDateTime("data_agen"),
                    HoraInicial = leitor.GetTimeSpan("horaInicial_agen"),
                    HoraFinal = leitor.GetTimeSpan("horaFinal_agen"),
                    Status = leitor.GetString("status_agen"),
                    ValorTotal = leitor.GetDecimal("valor_total"),
                    DataReserva = leitor.GetDateTime("data_reserva_agen"),
                    QuadraId = leitor.GetInt32("id_qua_fk")
                };

                lista.Add(agendamento);
            }
            return lista;
        }
        
        public Agendamento? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM agendamento WHERE id_agen = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var agendamento = new Agendamento
                {
                    Id = leitor.GetInt32("id_agen"),
                    Data = leitor.GetDateTime("data_agen"),
                    HoraInicial = leitor.GetTimeSpan("horaInicial_agen"),
                    HoraFinal = leitor.GetTimeSpan("horaFinal_agen"),
                    Status = leitor.GetString("status_agen"),
                    ValorTotal = leitor.GetDecimal("valor_total"),
                    DataReserva = leitor.GetDateTime("data_reserva_agen"),
                    QuadraId = leitor.GetInt32("id_qua_fk")
                };

                return agendamento;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Agendamento agendamento)
        {
            try
            {
                var comando = _conexao.CreateCommand("UPDATE agendamento SET data_agen = @_data, horaInicial_agen = @_horaInicial, horaFinal_agen = @_horaFinal, status_agen = @_status, valor_total = @_valorTotal, data_reserva_agen = @_dataReserva, id_qua_fk = @_id_qua_fk WHERE id_agen = @_id");

                comando.Parameters.AddWithValue("@_data", agendamento.Data);
                comando.Parameters.AddWithValue("@_horaInicial", agendamento.HoraInicial);
                comando.Parameters.AddWithValue("@_horaFinal", agendamento.HoraFinal);
                comando.Parameters.AddWithValue("@_status", agendamento.Status);
                comando.Parameters.AddWithValue("@_valorTotal", agendamento.ValorTotal);
                comando.Parameters.AddWithValue("@_dataReserva", agendamento.DataReserva);
                comando.Parameters.AddWithValue("@_id_qua_fk", agendamento.QuadraId);
                comando.Parameters.AddWithValue("@_id", agendamento.Id);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                var comando = _conexao.CreateCommand("DELETE * FROM agendamento WHERE id_agen = @_id");
                comando.Parameters.AddWithValue("@_id", id);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
