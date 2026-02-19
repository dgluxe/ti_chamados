using Npgsql; 
// Importa a biblioteca Npgsql, que permite o C# se conectar ao PostgreSQL

namespace OComeço
{
// Define o namespace do projeto (organização das classes)

	public class ChamadoRepository
	{
		// String de conexão com o banco de dados PostgreSQL
		// Aqui você informa onde está o banco, porta, usuário, senha e nome do banco

		private readonly string _connectionString =
			"Host=localhost;Port=5432;Username=postgres;Password=1234;Database=chamadosdb";

		// Método público que cria um chamado no banco de dados
		public void Criar(string titulo, string descricao)
		{
			// Cria uma conexão com o PostgreSQL usando a string de conexão
			using var conn = new NpgsqlConnection(_connectionString);

			// Abre a conexão com o banco de dados
			conn.Open();

			// Comando SQL que será executado no banco
			// @titulo e @descricao são parâmetros que serão substituídos pelos valores reais
			string sql = "INSERT INTO chamados (titulo, descricao) VALUES (@titulo, @descricao)";

			// Cria um comando SQL associado à conexão aberta
			using var cmd = new NpgsqlCommand(sql, conn);

			// Define o valor do parâmetro @titulo com o valor recebido no método
			cmd.Parameters.AddWithValue("@titulo", titulo);

			// Define o valor do parâmetro @descricao com o valor recebido no método
			cmd.Parameters.AddWithValue("@descricao", descricao);

			// Executa o comando SQL no banco de dados (INSERT)
			cmd.ExecuteNonQuery();
		}

		public void Listar()
		{
			// Cria uma conexão com o banco usando a string de conexão
			using var conn = new NpgsqlConnection(_connectionString);

			// Abre a conexão com o PostgreSQL
			conn.Open();

			// Comando SQL que busca os chamados no banco
			// ORDER BY id só organiza do menor id para o maior
			string sql = "SELECT id, titulo, descricao, estar_aberto FROM chamados ORDER BY id";

			// Cria o comando SQL ligado à conexão
			using var cmd = new NpgsqlCommand(sql, conn);

			// Executa o SELECT e devolve um leitor de dados (linha por linha)
			using var reader = cmd.ExecuteReader();

			// Verifica se a consulta voltou vazia (nenhum chamado no banco)
			if (!reader.HasRows)
			{
				Console.WriteLine("Não há chamados no banco.");
				return;
			}

			// Enquanto existir linha para ler no resultado do SELECT
			while (reader.Read())
			{
				// Lê o valor da coluna id (posição 0 da consulta)
				int id = reader.GetInt32(0);

				// Lê o valor da coluna titulo (posição 1 da consulta)
				string titulo = reader.GetString(1);

				// Lê a descrição, mas antes verifica se está nula no banco
				string descricao = reader.IsDBNull(2) ? "" : reader.GetString(2);

				// Lê se o chamado está aberto ou fechado (true ou false)
				bool estarAberto = reader.GetBoolean(3);

				// Converte o true/false em texto para o usuário entender
				string status = estarAberto ? "Aberto" : "Fechado";

				// Mostra os dados no console
				Console.WriteLine($"ID: {id}");
				Console.WriteLine($"Titulo: {titulo}");
				Console.WriteLine($"Descrição: {descricao}");
				Console.WriteLine($"Status do chamado: {status}\n");
			}
		}

		public bool Fechar(int id)
		{
		using var conn = new NpgsqlConnection(_connectionString);
		conn.Open();

		string sql = "UPDATE chamados SET estar_aberto = FALSE WHERE id = @id";

		using var cmd = new NpgsqlCommand(sql, conn);
		cmd.Parameters.AddWithValue("@id", id);

		int linhasAfetadas = cmd.ExecuteNonQuery();
		return linhasAfetadas > 0;
		}
	}
}