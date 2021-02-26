using Profit.Models.Db.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Models.Db
{
    public class Venda
    {
        [Key][Required]
        public int Id { get; set; }
        [ForeignKey("Cliente")]
        public string Id_Cliente { get; set; }
        public Cliente Cliente { get; set; }
        public string Name { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public decimal Taxa { get; set; }
        [Required]
        public decimal Desconto { get; set; }
        [Required]
        public Modalidade Modalidade { get; set; }
        [Required]
        public decimal Total { get; set; }
        public decimal Troco { get; set; }
        [Required]
        public decimal Lucro { get; set; }
        public string Observation { get; set; }
        [DefaultValue(Status.Pendente)]
        public Status Status { get; set; }
        [Required]
        public Pagamento Forma { get; set; }
        public decimal Gasto { get; set; }
        public DateTime Hora { get; set; }
    }
}
