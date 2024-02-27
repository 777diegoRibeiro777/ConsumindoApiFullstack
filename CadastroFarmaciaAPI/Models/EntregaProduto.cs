using System;
using System.Collections.Generic;

namespace CadastroFarmaciaAPI.Models
{
    public partial class EntregaProduto
    {
        public int Identrega { get; set; }
        public int? FornecedorId { get; set; }
        public string? ProdutosEntregues { get; set; }
        public int? QuantidadeEntregue { get; set; }
        public DateTime? DataEntrega { get; set; }

        public virtual Fornecedor? Fornecedor { get; set; }
    }
}
