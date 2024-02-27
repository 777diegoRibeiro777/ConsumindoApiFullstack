using System;
using System.Collections.Generic;

namespace CadastroFarmaciaAPI.Models
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            EntregaProdutos = new HashSet<EntregaProduto>();
        }

        public int Idfornecedor { get; set; }
        public string? NomeFornecedor { get; set; }
        public string? Endereco { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<EntregaProduto> EntregaProdutos { get; set; }
    }
}
