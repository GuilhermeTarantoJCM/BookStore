using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositorios.Interface
{
    public interface ILivroRepositorio : IDisposable
    {
        Criar_EditarLivroViewModel ListarLivros(string categoria, string busca);
        Criar_EditarLivroViewModel GetCriar();
        void Criar(Criar_EditarLivroViewModel model);
        Criar_EditarLivroViewModel GetEditar(int id);
        Criar_EditarLivroViewModel Editar(Criar_EditarLivroViewModel model);
        Criar_EditarLivroViewModel GetDeletar(int id);
        void Deletar(Criar_EditarLivroViewModel model);
    }
}
