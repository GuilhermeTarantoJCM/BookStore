using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class Criar_EditarLivroViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome inválido")]
        [Display(Name = "Nome do livro *")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "ISBN inválido")]
        [Display(Name = "ISBN *")]
        public string ISBN { get; set; }

        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data inválida")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Digite uma categoria")]
        [Display(Name = "Categoria *")]
        public string LivroCategoria { get; set; }
        public SelectList Categoria { get; set; }

        public List<Livro> Livros { get; set; }
    }
}
