using AppExemplo.Configs;
using AppWeb.Configs;


namespace AppExemplo.Models
{
    public class FuncionarioDAO
    {
        private readonly Conexao _conexao;
        public FuncionarioDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<Funcionario> ListarTodos()
        {

            var lista = new List<Funcionario>();

            var comando = _conexao.CreateCommand("SELECT * FROM funcionario");
            var leitor = comando.ExecuteReader();

            while (leitor.Read())
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
        
        public void Inserir(Funcionario funcionario)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO funcionario (nome_fun, cpf_fun, telefone_fun, email_fun, endereco_fun, funcao_fun) VALUES (@_nome, @_cpf, @_telefone, @_email, @_endereco, @_funcao)");

                comando.Parameters.AddWithValue("@_nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@_cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@_telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@_email", funcionario.Email);
                comando.Parameters.AddWithValue("@_endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@_funcao", funcionario.Funcao);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        public Funcionario? BuscarPorId(int id)
        {
            var comando = _conexao.CreateCommand("SELECT * FROM funcionario WHERE id_fun = @id;");
            comando.Parameters.AddWithValue("@id", id);

            var leitor = comando.ExecuteReader();

            if (leitor.Read())
            {
                var funcionario = new Funcionario
                {
                    Id = leitor.GetInt32("id_fun"),
                    Nome = DAOHelper.GetString(leitor, "nome_fun"),
                    Cpf = DAOHelper.GetString(leitor, "cpf_fun"),
                    Telefone = leitor.GetString("telefone_fun"),
                    Email = leitor.GetString("email_fun"),
                    Endereco = DAOHelper.GetString(leitor, "endereco_fun"),
                    Funcao = leitor.GetString("funcao_fun")
                };

                return funcionario;
            }
            else
            {
                return null;
            }
        }

        public void Atualizar(Funcionario funcionario)
        {
            try
            {
                var comando = _conexao.CreateCommand("UPDATE funcionario SET nome_fun = @_nome, cpf_fun = @_cpf, telefone_fun = @_telefone, email_fun = @_email, endereco_fun = @_endereco, funcao_fun = @_funcao WHERE id_fun = @_id");

                comando.Parameters.AddWithValue("@_nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@_cpf", funcionario.Cpf);
                comando.Parameters.AddWithValue("@_telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@_email", funcionario.Email);
                comando.Parameters.AddWithValue("@_endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@_funcao", funcionario.Funcao);
                comando.Parameters.AddWithValue("@_id", funcionario.Id);

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
                var comando = _conexao.CreateCommand("DELETE FROM funcionario WHERE id_fun = @_id");
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
