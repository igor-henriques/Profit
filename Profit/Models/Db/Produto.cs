using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Profit.Models.Db
{
    public class Produto
    {
        [Key][Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Profit { get; set; }
        [Required][ForeignKey("Receita")]
        public int Id_Receita { get; set; }
        public Receita Receita { get; set; }
    }
}
