using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEF.DAL.Entities
{
    public class Goods : BaseModel
    {
        public Goods()
        {
            this.ComentGoods = new HashSet<ComentGood>();
        }
        public string? Name { get; set; }
        public int NameKind { get; set; }
        public int Price { get; set; }
        public ICollection<ComentGood> ComentGoods { get; set; }
    }
}
