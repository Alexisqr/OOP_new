using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDb.Data.Models
{
    public class PatientMedicament
    {
       
        [Key]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int MedicamentId { get; set; }
        public virtual Medicament Medicament { get; set; }
    }
}
