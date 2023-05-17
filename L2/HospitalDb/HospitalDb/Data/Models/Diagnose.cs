using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDb.Data.Models
{
    public class Diagnose
    {

        [Key]
        public int DiagnoseId { get; set; }

        public string Name { get; set; }

        public string Comments { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
