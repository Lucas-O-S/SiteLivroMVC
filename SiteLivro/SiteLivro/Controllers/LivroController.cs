using Microsoft.AspNetCore.Mvc;
using SiteLivro.DAO;
using SiteLivro.Models;

namespace SiteLivro.Controllers
{
	public class LivroController : Controller
	{
		public IActionResult Index()
		{
			try
			{
				LivroDAO dao = new LivroDAO();
				List<LivroViewModel> lista = dao.Listagem();
				return View(lista);
			}
			catch (Exception ex)
			{
				return View("Error", new ErrorViewModel(ex.ToString()));
			}

		}

		public IActionResult Create()
		{
			try
			{
				LivroViewModel livro = new LivroViewModel();
				LivroDAO dao = new LivroDAO();
				livro.id = dao.ProximoID();
				return View("Form", livro);
			}
			catch (Exception ex)
			{
				return View("Error", new ErrorViewModel(ex.ToString()));
			}
		}

		public IActionResult Salvar(LivroViewModel livro)
		{
			try
			{
				LivroDAO dao = new LivroDAO();
				if (dao.Consulta(livro.id) == null)
					dao.Inserir(livro);
				else
					dao.Alterar(livro);




			}
			catch (Exception ex)
			{
				return View("Error", new ErrorViewModel(ex.ToString()));
			}
			return RedirectToAction("index");
		}

		public IActionResult Edit(int id)
		{
			try
			{
				LivroDAO dao = new LivroDAO();
				LivroViewModel livro = dao.Consulta(id);
				if (livro == null)
				{
					return RedirectToAction("Index");
				}
				else
				{
					return View("Form", livro);
				}
			}
			catch (Exception ex)
			{
				return View("Error", new ErrorViewModel(ex.ToString()));
			}
		}

		public IActionResult Delete(int id)
		{
			try
			{
				LivroDAO dao = new LivroDAO();
				dao.Excluir(id);
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				return View("Error", new ErrorViewModel(ex.ToString()));
			}
		}
	}
}
