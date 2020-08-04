using BookStore.Repositorios.Interface;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Controllers
{
    [Route("livros")]
    public class LivroController : Controller
    {
        private readonly ILivroRepositorio _repositorio;

        public LivroController(ILivroRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [Route("listar")]
        public ActionResult Index(string categoria, string busca)
        {
            var getLivros = _repositorio.ListarLivros(categoria, busca);
            return View(getLivros);
        }
        
        [Route("criar")]
        public ActionResult Criar()
        {
            var getCriar = _repositorio.GetCriar();
            return View(getCriar);
        }
        
        [Route("criar")]
        [HttpPost]
        public ActionResult Criar(Criar_EditarLivroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Mensagem", "Campos inválidos");
                return RedirectToAction("Criar");
            }
            _repositorio.Criar(model);
            return RedirectToAction("Index");       
        }
        
        [Route("editar/{id:int}")]
        public ActionResult Editar(int id)
        {
            var editarLivro = _repositorio.GetEditar(id);
            return View(editarLivro);            
        }
        
        [Route("editar/{id:int}")]
        [HttpPost]
        public ActionResult Editar(Criar_EditarLivroViewModel model)
        {
            _repositorio.Editar(model);
            return RedirectToAction("Index");
        }

        [Route("deletar/{id:int}")]
        public ActionResult Deletar(int id)
        {
            var deletarLivro = _repositorio.GetDeletar(id);
            return View(deletarLivro);
        }

        [Route("deletar/{id:int}")]
        [HttpPost]
        public ActionResult Deletar(Criar_EditarLivroViewModel model)
        {
            _repositorio.Deletar(model);
            return RedirectToAction("Index");
        }
    }
}
