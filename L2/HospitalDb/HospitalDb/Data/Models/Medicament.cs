using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDb.Data.Models
{
    public class Medicament
    {

        [Key]
        public int MedicamentId { get; set; }
        public Medicament()
        {
            this.Prescriptions = new List<PatientMedicament>();
        }
        public string Name { get; set; }
        public ICollection<PatientMedicament> Prescriptions { get; set; }

    }
}
