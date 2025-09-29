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
    }
}
