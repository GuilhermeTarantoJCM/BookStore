using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string ISBN { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        public string Categoria { get; set; }
    }
}
