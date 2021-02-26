using System.ComponentModel.DataAnnotations;

namespace Profit.Models.Db
{
    public class Gasto
    {
        [Key][Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Cost { get; set; }
    }
}
