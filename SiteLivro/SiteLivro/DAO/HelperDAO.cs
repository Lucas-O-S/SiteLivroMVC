﻿using System.Data.SqlClient;
using System.Data;

namespace SiteLivro.DAO
{
	public class HelperDAO
	{
		public static void ExecutarSQL(string sql, SqlParameter[] parametros)
		{
			using (SqlConnection conexao = ConexaoDB.GetConexao())
			{
				using (SqlCommand comando = new SqlCommand(sql, conexao))
				{
					if (parametros != null)
						comando.Parameters.AddRange(parametros);
					comando.ExecuteNonQuery();

					conexao.Close();
				}
			}

		}

		public static DataTable ExecutaSelect(string sql, SqlParameter[] parametros)
		{
			using (SqlConnection conexao = ConexaoDB.GetConexao())
			{
				using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao))
				{
					if (parametros != null)
						adapter.SelectCommand.Parameters.AddRange(parametros);
					DataTable tabela = new DataTable();
					adapter.Fill(tabela);
					conexao.Close();
					return tabela;

				}
			}
		}
	}
}
