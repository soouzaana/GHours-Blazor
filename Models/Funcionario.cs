namespace AppExemplo.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Cpf { get; set; }
        public required string Telefone { get; set; }
        public string? Email { get; set; }
        public string? Endereco { get; set; }
        public required string Funcao { get; set; }
    }
}
