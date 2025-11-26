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

         public Cliente? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand(
                "SELECT * FROM cliente WHERE id_cli = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var cliente = new Cliente
                {
                    Id = leitor.GetInt32("id_cli"),
                    Nome = leitor.GetString("nome_cli"),
                    Cpf = leitor.GetString("cpf_cli"),
                    Telefone = leitor.GetString("telefone_cli"),
                    Email = leitor.GetString("email_cli"),
                };

                return cliente;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Cliente cliente)
        {
            try
            {
                var comando = _conexao.CreateCommand(
                    "UPDATE cliente SET nome_cli = @_nome, cpf_cli = @_cpf, telefone_cli = @_telefone, email_cli = @_email WHERE id_cli = @_id");

                comando.Parameters.AddWithValue("@_nome", cliente.Nome);
                comando.Parameters.AddWithValue("@_cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("@_telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@_email", cliente.Email);
                comando.Parameters.AddWithValue("@_id", cliente.Id);

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
                var comando = _conexao.CreateCommand(
                    "DELETE FROM cliente WHERE id_cli = @_id");

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
