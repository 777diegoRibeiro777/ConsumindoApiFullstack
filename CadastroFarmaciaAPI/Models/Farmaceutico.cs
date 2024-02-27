using System;
using System.Collections.Generic;

namespace CadastroFarmaciaAPI.Models
{
    public partial class Farmaceutico
    {
        public Farmaceutico()
        {
            PrescricaoMedicas = new HashSet<PrescricaoMedica>();
            VendaProdutos = new HashSet<VendaProduto>();
        }

        public int Idfarmacutico { get; set; }
        public string? Nome { get; set; }
        public string? NumeroRegistroProfissional { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<PrescricaoMedica> PrescricaoMedicas { get; set; }
        public virtual ICollection<VendaProduto> VendaProdutos { get; set; }
    }
}
