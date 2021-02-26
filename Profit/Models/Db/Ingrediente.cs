using System.ComponentModel.DataAnnotations;

namespace Profit.Models.Db
{
    public class Ingrediente
    {
        [Key][Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantia_Total { get; set; }
    }
}
