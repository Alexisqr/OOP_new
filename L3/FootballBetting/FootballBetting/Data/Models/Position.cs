using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
            this.Players = new List<Player>();
        }

        public int PositionId { get; set; }

        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
