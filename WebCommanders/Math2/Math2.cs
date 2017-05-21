using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCommanders.Math2
{
    public class Math2
    {
        /// <summary>
        /// Default epsilon
        /// </summary>
        public const float DEFAULT_EPSILON = 0.001f;

        /// <summary>
        /// Determines if v1, v2, and v3 are collinear
        /// </summary>
        /// <remarks>
        /// Calculates if the area of the triangle of v1, v2, v3 is less than or equal to epsilon.
        /// </remarks>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <param name="v3">Vector 3</param>
        /// <param name="epsilon">How close is close enough</param>
        /// <returns>If v1, v2, v3 is collinear</returns>
        public static bool IsOnLine(Vector2 v1, Vector2 v2, Vector2 v3, float epsilon = DEFAULT_EPSILON)
        {
            return Math.Abs(v1.X * (v2.Y - v3.Y) + v2.X * (v3.Y - v1.Y) + v3.X * (v1.Y - v2.Y)) <= epsilon;
        }
    }
}
