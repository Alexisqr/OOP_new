using ShelterEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterDAL.Models
{
    public class ComentKindAnimals : BaseModel
    {

        public int IDVolonter { get; set; }
        public int IDKindAnimals { get; set; }
        public string? Text { get; set; }
        public string? Date { get; set; }//ПерепитатисЬ за дату
    }
}
