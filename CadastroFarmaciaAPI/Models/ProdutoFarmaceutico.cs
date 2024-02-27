using System;
using System.Collections.Generic;

namespace CadastroFarmaciaAPI.Models
{
    public partial class ProdutoFarmaceutico
    {
        public int Idproduto { get; set; }
        public string? NomeProduto { get; set; }
        public string? Descricao { get; set; }
        public string? Fabricante { get; set; }
        public decimal? Preco { get; set; }
        public int? QuantidadeEstoque { get; set; }
        public DateTime? DataValidade { get; set; }
    }
}
