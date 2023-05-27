using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterDAL.Models
{
    public class Goods : BaseModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Invalid NameKind value.")]
        public int NameKind { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public int Price { get; set; }
    }
}
