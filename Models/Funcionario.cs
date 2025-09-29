namespace AppExemplo.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Funcao { get; set; }
    }
}
