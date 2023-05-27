using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterDAL.Models
{
    public class Animals:BaseModel
    {

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Age must be a non-negative number.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Kind is required.")]
        public int Kind { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public string? Gender { get; set; }
    }
}
