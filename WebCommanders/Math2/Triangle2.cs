using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCommanders.Math2
{
    /// <summary>
    /// Describes a simple triangle based on it's three vertices. Does not
    /// have position - most functions require specifying the origin of the
    /// triangle. Triangles are meant to be reused.
    /// </summary>
    public class Triangle2 : Shape2
    {
        /// <summary>
        /// The three vertices of this triangle
        /// </summary>
        public readonly Vector2[] Vertices;

        /// <summary>
        /// The three normal vectors of this triangle, normalized
        /// </summary>
        public readonly Vector2[] Normals;

        /// <summary>
        /// Initializes a trinagle with the specified vertices
        /// </summary>
        /// <param name="vertices">Vertices</param>
        /// <exception cref="ArgumentNullException">If vertices is null</exception>
        /// <exception cref="ArgumentException">If vertices.Length != 3</exception>
        /// <exception cref="ArgumentException">If any 2 vertices are the same</exception>
        /// <exception cref="ArgumentException">If the vertices are collinear (make a line, not a triangle)</exception>
        public Triangle2(Vector2[] vertices)
        {
            if (vertices == null)
                throw new ArgumentNullException(nameof(vertices));
            if (vertices.Length != 3)
                throw new ArgumentException($"Expected 3 vertices, got {vertices.Length}", nameof(vertices));

            if (Vector2.Approximately(vertices[0], vertices[1]) || Vector2.Approximately(vertices[0], vertices[2]) || Vector2.Approximately(vertices[1], vertices[2]))
                throw new ArgumentException($"At least 2 vertices are the same: {vertices[0]}, {vertices[1]}, {vertices[2]}", nameof(vertices));

            if (Math2.IsOnLine(vertices[0], vertices[1], vertices[2]))
                throw new ArgumentException($"Vertices {vertices[0]}, {vertices[1]}, {vertices[2]} are collinear (on the same line) - that's not a triangle", nameof(vertices));

            Vertices = vertices;

            Normals = new[] {
                Vector2.Normalize(Vector2.Perpendicular(Vertices[1] - Vertices[0])),
                Vector2.Normalize(Vector2.Perpendicular(Vertices[2] - Vertices[1])),
                Vector2.Normalize(Vector2.Perpendicular(Vertices[0] - Vertices[2])) };
        }
        
        /// <summary>
        /// Determines if the first triangle intersects the second triangle when triangle one
        /// is at position 1 and triangle two is at position two.
        /// </summary>
        /// <param name="tri1">Triangle one</param>
        /// <param name="tri2">Triangle two</param>
        /// <param name="pos1">Position one</param>
        /// <param name="pos2">Position two</param>
        /// <param name="strict">If overlapping is required for intersection</param>
        /// <returns>If tri1 at pos1 intersects tri2 at pos2</returns>
        public static bool Intersects(Triangle2 tri1, Triangle2 tri2, Vector2 pos1, Vector2 pos2, bool strict)
        {
            for(int i = 0; i < 3; i++)
            {
                if (!IntersectsAlongAxis(tri1, tri2, pos1, pos2, strict, tri1.Normals[i]))
                    return false;
                if (!IntersectsAlongAxis(tri1, tri2, pos1, pos2, strict, tri2.Normals[i]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Determines the mtv to move pos1 by to prevent tri1 at pos1 from intersecting tri2 at pos2.
        /// Returns null if tri1 and tri2 do not intersect.
        /// </summary>
        /// <param name="tri1">Triangle 1</param>
        /// <param name="tri2">Triangle 2</param>
        /// <param name="pos1">Triangle 1 origin</param>
        /// <param name="pos2">Triangle 2 origin</param>
        /// <returns>MTV for triangle 1</returns>
        public static Vector2? IntersectMTV(Triangle2 tri1, Triangle2 tri2, Vector2 pos1, Vector2 pos2)
        {
            Vector2? bestAxis = null;
            float? bestMagn = null;

            for(int i = 0; i < 3; i++)
            {
                var mtv = IntersectMTVAlongAxis(tri1, tri2, pos1, pos2, tri1.Normals[i]);
                if (!mtv.HasValue)
                    return null;
                else if (!bestAxis.HasValue || bestMagn.Value > mtv.Value)
                {
                    bestAxis = tri1.Normals[i];
                    bestMagn = mtv;
                }

                mtv = IntersectMTVAlongAxis(tri1, tri2, pos1, pos2, tri2.Normals[i]);
                if (!mtv.HasValue)
                    return null;
                else if (bestMagn.Value > mtv.Value)
                {
                    bestAxis = tri2.Normals[i];
                    bestMagn = mtv;
                }
            }

            return Vector2.ScalarMult(bestAxis.Value, bestMagn.Value);
        }

        /// <summary>
        /// Determines if triangle 1 and triangle 2 at position 1 and position 2, respectively, intersect along axis.
        /// </summary>
        /// <param name="tri1">Triangle 1</param>
        /// <param name="tri2">Triangle 2</param>
        /// <param name="pos1">Origin of triangle 1</param>
        /// <param name="pos2">Origin of triangle 2</param>
        /// <param name="strict">If overlapping is required for intersection</param>
        /// <param name="axis">The axis to check</param>
        /// <returns>If tri1 at pos1 intersects tri2 at pos2 along axis</returns>
        public static bool IntersectsAlongAxis(Triangle2 tri1, Triangle2 tri2, Vector2 pos1, Vector2 pos2, bool strict, Vector2 axis)
        {
            var proj1 = ProjectAlongAxis(tri1, pos1, axis);
            var proj2 = ProjectAlongAxis(tri2, pos2, axis);

            return AxisAlignedLine2.Intersects(proj1, proj2, strict);
        }

        /// <summary>
        /// Determines the distance along axis, if any, that triangle 1 should be shifted by
        /// to prevent intersection with triangle 2. Null if no intersection along axis.
        /// </summary>
        /// <param name="tri1">Triangle 1</param>
        /// <param name="tri2">Triangle 2</param>
        /// <param name="pos1">Triangle 1 origin</param>
        /// <param name="pos2">Triangle 2 origin</param>
        /// <param name="axis">Axis to check</param>
        /// <returns>a number to shift pos1 along axis by to prevent tri1 at pos1 from intersecting tri2 at pos2, or null if no int. along axis</returns>
        public static float? IntersectMTVAlongAxis(Triangle2 tri1, Triangle2 tri2, Vector2 pos1, Vector2 pos2, Vector2 axis)
        {
            var proj1 = ProjectAlongAxis(tri1, pos1, axis);
            var proj2 = ProjectAlongAxis(tri2, pos2, axis);

            return AxisAlignedLine2.IntersectMTV(proj1, proj2);
        }
        /// <summary>
        /// Projects the triangle at position onto the specified axis.
        /// </summary>
        /// <param name="tri">The triangle</param>
        /// <param name="pos">The triangles origin</param>
        /// <param name="axis">The axis to project onto</param>
        /// <returns>tri at pos projected along axis</returns>
        public static AxisAlignedLine2 ProjectAlongAxis(Triangle2 tri, Vector2 pos, Vector2 axis)
        {
            return ProjectAlongAxis(axis, pos, tri.Vertices);
        }
    }
}
