using AppExemplo.Configs;

namespace AppExemplo.Models
{
    public class FuncionarioDAO
    {
        private readonly Conexao _conexao;
        public FuncionarioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Funcionario> ListarTodos() { 
        
            var lista = new List<Funcionario>();

            var comando = _conexao.CreateCommand("SELECT * FROM funcionario");
            var leitor = comando.ExecuteReader();

            while(leitor.Read())
            {
                var funcionario = new Funcionario
                {
                    Id = leitor.GetInt32("id_fun"),
                    Nome = leitor.GetString("nome_fun"),
                    Cpf = leitor.GetString("cpf_fun"),
                    Telefone = leitor.GetString("telefone_fun"),
                    Email = leitor.GetString("email_fun"),
                    Endereco = leitor.GetString("endereco_fun"),
                    Funcao = leitor.GetString("funcao_fun")
                };

                lista.Add(funcionario);
            }
            return lista;
        }
    }
}
