using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Models.Db
{
    public class Venda_Produto
    {
        [Key][Required]
        public int Id { get; set; }
        [Required][ForeignKey("Produto")]
        public int Id_Produto { get; set; }
        public Produto Produto { get; set; }
        [Required][ForeignKey("Venda")]
        public int Id_Venda { get; set; }
        public Venda Venda { get; set; }
        public string Nome_Produto { get; set; }
    }
}
