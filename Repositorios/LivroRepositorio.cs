using BookStore.Context;
using BookStore.Repositorios.Interface;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly BookStoreContext _db;

        public LivroRepositorio(BookStoreContext context)
        {
            _db = context;
        }

        public Criar_EditarLivroViewModel ListarLivros(string categoria, string busca)
        {
            IQueryable<string> categoriaQuery = from l in _db.Livro 
                                                orderby l.Categoria 
                                                select l.Categoria;

            var livros = from l in _db.Livro 
                         select l;

            if (!string.IsNullOrEmpty(busca))
            {
                livros = livros.Where(l => l.Nome.Contains(busca));
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                livros = livros.Where(l => l.Categoria == categoria);
            }

            var getLivros = new Criar_EditarLivroViewModel
            {
                Categoria = new SelectList(categoriaQuery.Distinct().ToList()),
                Livros = _db.Livro.ToList()
            };

            return getLivros;
        }

        public Criar_EditarLivroViewModel GetCriar()
        {
            var model = new Criar_EditarLivroViewModel
            {
                Nome = "",
                ISBN = "",
                DataLancamento = DateTime.Now,
                LivroCategoria = ""
            };

            return model;
        }

        public void Criar(Criar_EditarLivroViewModel model)
        {
            var livro = new Livro
            {
                Nome = model.Nome,
                ISBN = model.ISBN,
                DataLancamento = model.DataLancamento,
                Categoria = model.LivroCategoria
            };

            try
            {
                _db.Livro.Add(livro);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public Criar_EditarLivroViewModel GetEditar(int id)
        {
            var livro =  _db.Livro.Find(id);

            var model = new Criar_EditarLivroViewModel
            {
                Nome = livro.Nome,
                ISBN = livro.ISBN,
                DataLancamento = livro.DataLancamento,
                LivroCategoria = livro.Categoria
            };

            return model;
        }

        public Criar_EditarLivroViewModel Editar(Criar_EditarLivroViewModel model)
        {
            var livro =  _db.Livro.Find(model.Id);
            _db.Entry<Livro>(livro).State = EntityState.Modified;
            _db.SaveChanges();

            return model;
        }

        public Criar_EditarLivroViewModel GetDeletar(int id)
        {
            var livro = _db.Livro.Find(id);

            var model = new Criar_EditarLivroViewModel
            {
                Nome = livro.Nome,
                ISBN = livro.ISBN,
                DataLancamento = livro.DataLancamento,
                LivroCategoria = livro.Categoria
            };

            return model;
        }

        public void Deletar(Criar_EditarLivroViewModel model)
        {
            var livro = _db.Livro.Find(model.Id);
            _db.Livro.Remove(livro);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
