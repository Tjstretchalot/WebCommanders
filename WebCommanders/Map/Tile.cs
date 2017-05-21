using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCommanders.Entities;

namespace WebCommanders.Map
{
    /// <summary>
    /// A tile. Not actually rendered, as the map is entirely grass as a base, with mountains
    /// described as entities. Used for partitioning the world for the purpose of collision.
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// The entities that are intersecting this tile.
        /// </summary>
        public List<Entity> Entities;
    }
}
