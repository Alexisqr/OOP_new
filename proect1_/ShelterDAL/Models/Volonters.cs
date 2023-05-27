using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterDAL.Models
{
    public class Volonters : BaseModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneName { get; set; }
        public string? EMail { get; set; }
    }
}
