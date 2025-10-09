using AppExemplo.Configs;

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
    }
}
