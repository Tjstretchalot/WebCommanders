using Microsoft.Xna.Framework;
using SharpMath2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCommanders.Map;

namespace WebCommanders.Entities
{
    /// <summary>
    /// Describes an entity in the world.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// The bounds of the entity
        /// </summary>
        public readonly Polygon2 Bounds;

        /// <summary>
        /// Where the entity is located.
        /// </summary>
        public Vector2 Location;

        /// <summary>
        /// The rotation of this entity
        /// </summary>
        public Rotation2 Rotation;

        /// <summary>
        /// The tiles that the entity intersects.
        /// </summary>
        public List<Tile> IntersectedTiles;
        
    }
}
