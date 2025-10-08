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
        
        public void Inserir(Cliente cliente)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO cliente (nome_cli, cpf_cli, telefone_cli, email_cli) VALUES (@_nome, @_cpf, @_telefone, @_email)"
);

                comando.Parameters.AddWithValue("@_nome", cliente.Nome);
                comando.Parameters.AddWithValue("@_cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("@_telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@_email", cliente.Email);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<Cliente> ListarTodos()
        {

            var lista = new List<Cliente>();

            var comando = _conexao.CreateCommand("SELECT * FROM cliente");
            var leitor = comando.ExecuteReader();


            while (leitor.Read())
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
