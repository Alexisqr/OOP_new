using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterDAL.Models
{
    public class Volonters_Animals : BaseModel
    {
        public int IDVolonter { get; set; }
        public int IDAnimals { get; set; }
        public string? Date { get; set; }//ПерепитатисЬ за дату
    }
}
