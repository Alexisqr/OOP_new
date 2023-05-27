using ShelterDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEF.DAL.Entities
{
    public class KindOfAnimals : BaseModel
    {
        public KindOfAnimals()
        {
            this.ComentKindAnimalss = new HashSet<ComentKindAnimals>();
        }
       
            public string? NameKind { get; set; }
        public ICollection<ComentKindAnimals> ComentKindAnimalss { get; set; }

    }
}
