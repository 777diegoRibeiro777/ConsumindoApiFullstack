using System;
using System.Collections.Generic;

namespace CadastroFarmaciaAPI.Models
{
    public partial class VendaProduto
    {
        public int Idvenda { get; set; }
        public DateTime? DataVenda { get; set; }
        public int? ClienteId { get; set; }
        public int? FarmaceuticoId { get; set; }
        public decimal? ValorTotal { get; set; }

        public virtual Cliente? Cliente { get; set; }
        public virtual Farmaceutico? Farmaceutico { get; set; }
    }
}
