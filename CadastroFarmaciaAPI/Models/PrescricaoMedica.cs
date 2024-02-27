using System;
using System.Collections.Generic;

namespace CadastroFarmaciaAPI.Models
{
    public partial class PrescricaoMedica
    {
        public int Idprescricao { get; set; }
        public int? PacienteId { get; set; }
        public int? FarmaceuticoId { get; set; }
        public DateTime? DataPrescricao { get; set; }
        public string? MedicamentosPrescritos { get; set; }

        public virtual Farmaceutico? Farmaceutico { get; set; }
        public virtual Cliente? Paciente { get; set; }
    }
}
