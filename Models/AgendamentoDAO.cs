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
