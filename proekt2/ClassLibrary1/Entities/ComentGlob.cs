using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEF.DAL.Entities
{
    public class ComentGlob:BaseModel
    {
        public int IDVolonter { get; set; }
        public Volonters? Volonters { get; set; }
       
        public string? Text { get; set; }
        public string? Date { get; set; }//ПерепитатисЬ за дату
    }
}
