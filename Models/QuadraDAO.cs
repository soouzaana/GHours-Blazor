using AppExemplo.Configs;

namespace AppExemplo.Models
{
    public class QuadraDAO
    {
        private readonly Conexao _conexao;
        public QuadraDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public void Inserir(Quadra quadra)
        {
            try
            {
                var comando = _conexao.CreateCommand("INSERT INTO quadra (nome_qua, descricao_qua, valor_qua, status_qua) VALUES (@_nome, @_descricao, @_valor, @_status)");

                comando.Parameters.AddWithValue("@_nome", quadra.Nome);
                comando.Parameters.AddWithValue("@_descricao", quadra.Descricao);
                comando.Parameters.AddWithValue("@_valor", quadra.Valor);
                comando.Parameters.AddWithValue("@_status", quadra.Status);

                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<Quadra> ListarTodos() { 
        
            var lista = new List<Quadra>();

            var comando = _conexao.CreateCommand("SELECT * FROM quadra");
            var leitor = comando.ExecuteReader();

            while(leitor.Read())
            {
                var quadra = new Quadra
                {
                    Id = leitor.GetInt32("id_qua"),
                    Nome = leitor.GetString("nome_qua"),
                    Descricao = leitor.GetString("descricao_qua"),  
                    Valor = leitor.GetDecimal("valor_qua"),
                    Status = leitor.GetString("status_qua")
                };

                lista.Add(quadra);
            }
            return lista;
        }

            public Quadra? BuscarPorId(int id)
            {
                var comando = _conexao.CreateCommand("SELECT * FROM quadra WHERE id_qua = @_id");
                comando.Parameters.AddWithValue("@_id", id);

                var leitor = comando.ExecuteReader();
    
                Quadra? quadra = null;
                if (leitor.Read())
                {
                    quadra = new Quadra
                    {
                        Id = leitor.GetInt32("id_qua"),
                        Nome = leitor.GetString("nome_qua"),
                        Descricao = leitor.GetString("descricao_qua"),
                        Valor = leitor.GetDecimal("valor_qua"),
                        Status = leitor.GetString("status_qua")
                    };

                    return quadra;
                }
                else
                {
                    return null;
                }
              
            }

            public void Atualizar(Quadra quadra)
            {
                try
                {
                    var comando = _conexao.CreateCommand("UPDATE quadra SET nome_qua = @_nome, descricao_qua = @_descricao, valor_qua = @_valor, status_qua = @_status WHERE id_qua = @_id");

                    comando.Parameters.AddWithValue("@_nome", quadra.Nome);
                    comando.Parameters.AddWithValue("@_descricao", quadra.Descricao);
                    comando.Parameters.AddWithValue("@_valor", quadra.Valor);
                    comando.Parameters.AddWithValue("@_status", quadra.Status);
                    comando.Parameters.AddWithValue("@_id", quadra.Id);

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
                    var comando = _conexao.CreateCommand("DELETE FROM quadra WHERE id_qua = @_id");
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
