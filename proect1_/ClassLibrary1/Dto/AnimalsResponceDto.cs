using ShelterBLL.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterBLL.Dto
{
  
    public class AnimalsResponceDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? NameKind { get; set; }
        public string? Gender { get; set; }
    }
}
