namespace AppExemplo.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public required string Status { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataReserva { get; set; }
        public int QuadraId { get; set; }
    }
}

