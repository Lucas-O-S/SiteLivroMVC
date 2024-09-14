using Microsoft.AspNetCore.Routing.Constraints;
using SiteLivro.Controllers;
using SiteLivro.Models;
using System.Data;
using System.Data.SqlClient;

namespace SiteLivro.DAO
{
	public class LivroDAO
	{

		private SqlParameter[] CriarParametros(LivroViewModel livro)
		{
			SqlParameter[] parametros = new SqlParameter[8];
			parametros[0] = new SqlParameter("ID", livro.id);
			parametros[1] = new SqlParameter("Titulo", livro.titulo);
			parametros[2] = new SqlParameter("Autor1", livro.autor1);
			if (livro.autor2 == null)
				parametros[3] = new SqlParameter("Autor2", DBNull.Value);
			else
				parametros[3] = new SqlParameter("Autor2", livro.autor2);
			parametros[4] = new SqlParameter("Editora", livro.editora);
			parametros[5] = new SqlParameter("AnoLancamento", livro.anoLancamento);
			parametros[6] = new SqlParameter("Edicao", livro.edicao);
			parametros[7] = new SqlParameter("PrecoSugerido", livro.precoSugerido);

			return parametros;

		}

		private LivroViewModel MontarLivro(DataRow registro)
		{
			LivroViewModel livro = new LivroViewModel();
			livro.id = Convert.ToInt32(registro["ID"]);
			livro.titulo = Convert.ToString(registro["Titulo"]);
			livro.autor1 = Convert.ToString(registro["Autor1"]);
			livro.autor2 = Convert.ToString(registro["Autor2"]);
			livro.editora = Convert.ToString(registro["Editora"]);
			livro.anoLancamento = Convert.ToInt32(registro["AnoLancamento"]);
			livro.edicao = Convert.ToInt32(registro["Edicao"]);
			livro.precoSugerido = Convert.ToDecimal(registro["PrecoSugerido"]);
			return livro;
		}

		public void Inserir(LivroViewModel livro)
		{
			string sql = "insert into tbLivros(ID, Titulo, Autor1, Autor2, Editora, AnoLancamento, Edicao, PrecoSugerido)" +
				"values(@ID, @Titulo, @Autor1, @Autor2, @Editora, @AnoLancamento, @Edicao, @PrecoSugerido)";

			HelperDAO.ExecutarSQL(sql, CriarParametros(livro));
		}

		public void Excluir(int id)
		{
			string sql = "delete from tbLivros where id = " + id;

			HelperDAO.ExecutarSQL(sql, null);
		}

		public void Alterar(LivroViewModel livro)
		{
			string sql = "update tbLivros set id= @ID," +
				" Titulo = @Titulo, Autor1 = @Autor1, Autor2 = @Autor2," +
				"Editora = @Editora, AnoLancamento = @AnoLancamento, Edicao = @Edicao," +
				" PrecoSugerido = @PrecoSugerido where id = @ID";

			HelperDAO.ExecutarSQL(sql, CriarParametros(livro));


		}

		public LivroViewModel Consulta(int id)
		{
			string sql = "select * from tbLivros where id = " + id;

			DataTable tabela = HelperDAO.ExecutaSelect(sql,null);
			if (tabela.Rows.Count == 0)
			{
				return null;
			}
			else
			{
				return MontarLivro(tabela.Rows[0]);
			}
		}
		public List<LivroViewModel> Listagem()
		{ 
			List < LivroViewModel > lista = new List<LivroViewModel>();
			string sql = "select * from tbLivros order by Titulo ";

			DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
			foreach (DataRow dr in tabela.Rows)
				lista.Add(MontarLivro(dr));
			return lista;
		}

		public int ProximoID ()
		{
			string sql ="select isnull(max(ID)+1,1) as 'Maior' from tbLivros";
			DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
			return Convert.ToInt32(tabela.Rows[0]["Maior"]);
		}
	}
}
