using System;
using System.Collections.Generic;

namespace CadastroFarmaciaAPI.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            PrescricaoMedicas = new HashSet<PrescricaoMedica>();
            VendaProdutos = new HashSet<VendaProduto>();
        }

        public int Idcliente { get; set; }
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<PrescricaoMedica> PrescricaoMedicas { get; set; }
        public virtual ICollection<VendaProduto> VendaProdutos { get; set; }
    }
}
