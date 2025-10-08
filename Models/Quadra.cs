namespace AppExemplo.Models
{
    public class Quadra
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Valor { get; set; }
        public required string Status { get; set; }
    }
}
