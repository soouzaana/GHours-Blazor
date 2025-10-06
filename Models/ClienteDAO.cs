using AppExemplo.Configs;

namespace AppExemplo.Models
{
    public class ClienteDAO
    {
        private readonly Conexao _conexao;
        public ClienteDAO(Conexao conexao) 
        {
            _conexao = conexao;
        }

        public List<Cliente> ListarTodos() { 
        
            var lista = new List<Cliente>();

            var comando = _conexao.CreateCommand("SELECT * FROM cliente");
            var leitor = comando.ExecuteReader();

            while(leitor.Read())
            {
                var cliente = new Cliente
                {
                    Id = leitor.GetInt32("id_cli"),
                    Nome = leitor.GetString("nome_cli"),
                    Cpf = leitor.GetString("cpf_cli"),
                    Telefone = leitor.GetString("telefone_cli"),
                    Email = leitor.GetString("email_cli")
                };

                lista.Add(cliente);
            }
            return lista;
        }
    }
}
