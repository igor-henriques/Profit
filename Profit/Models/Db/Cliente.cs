using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Models.Db
{
    public class Cliente
    {
        [Key][Required]
        public string Cpf { get; set; }
        [Required]
        public string Nome{ get; set; }
        [Required]
        public string Tel { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Num_residencia { get; set; }
        public string Referencia { get; set; }

    }
}
