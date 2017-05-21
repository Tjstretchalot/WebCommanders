using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCommanders.Map
{
    /// <summary>
    /// The game map is described with very large tiles, about 4x the size of any unit. The tiles are rectangular, and used
    /// as a way of partitioning units for the purpose of collision. Units that do not intersect the same tiles cannot possibly
    /// intersect.
    /// </summary>
    public class GameMap
    {
        public Tile[] Tiles;
    }
}
