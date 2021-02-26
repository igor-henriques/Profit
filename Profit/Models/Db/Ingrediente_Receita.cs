using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Models.Db
{
    public class Ingrediente_Receita
    {
        [Key][Required]
        public int Id { get; set; }

        [Required][ForeignKey("Ingrediente")]
        public int Id_Ingrediente { get; set; }
        public Ingrediente Ingrediente { get; set; }

        [Required][ForeignKey("Receita")]
        public int Id_Receita { get; set; }
        public Receita Receita { get; set; }

        [Required]
        public decimal Quantia_Usada { get; set; }
        [Required]
        public decimal Preco_Unitario { get; set; }
    }
}
