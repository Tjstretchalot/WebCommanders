using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCommanders.Math2
{
    /// <summary>
    /// Describes a 2D vector - uses the same conventions as XNA. Float based.
    /// </summary>
    public struct Vector2
    {
        public static Vector2 Zero = new Vector2(0, 0);
        public static Vector2 UnitX = new Vector2(1, 0);
        public static Vector2 UnitY = new Vector2(0, 1);

        public float X;
        public float Y;

        /// <summary>
        /// Creates a new vector2 with the specified components.
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Creates a copy of the other vector
        /// </summary>
        /// <param name="other">The vector to copy</param>
        public Vector2(Vector2 other) : this(other.X, other.Y)
        {
        }

        /// <summary>
        /// Adds the vectors component-wise
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>v1 + v2</returns>
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }

        /// <summary>
        /// Subtracts v2 from v1, component wise.
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>v1 - v2</returns>
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }

        /// <summary>
        /// Finds the additive inverse of v (-v.X, -v.Y)
        /// </summary>
        /// <param name="v">Vector</param>
        /// <returns>Additive inverse</returns>
        public static Vector2 operator -(Vector2 v)
        {
            return new Vector2(-v.X, -v.Y);
        }
        
        /// <summary>
        /// Determines if v1 is equal to v2.
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>If vector 1 is equal to vector 2</returns>
        public static bool operator ==(Vector2 v1, Vector2 v2)
        {
            return v1.X == v2.X && v1.Y == v2.Y;
        }

        /// <summary>
        /// Determines if v1 is not equal to v2
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>v1 != v2</returns>
        public static bool operator !=(Vector2 v1, Vector2 v2)
        {
            return v1.X != v2.X || v1.Y != v2.Y;
        }

        /// <summary>
        /// Truncates the vector to a point.
        /// </summary>
        /// <param name="v">Vector to round to a point</param>
        public static explicit operator Point2(Vector2 v)
        {
            return new Point2((int)v.X, (int)v.Y);
        }
        
        /// <summary>
        /// Calculates the dot product of v1 and v2
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>v1 dot v2</returns>
        public static float DotProduct(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }

        /// <summary>
        /// Returns (v.X * scalar, v.Y * scalar)
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="scalar">Scalar</param>
        /// <returns>Scalar multiple of v</returns>
        public static Vector2 ScalarMult(Vector2 v, float scalar)
        {
            return new Vector2(v.X * scalar, v.Y * scalar);
        }

        /// <summary>
        /// Returns the dot product of (v1X, v1Y) and (v2X, v2Y)
        /// </summary>
        /// <param name="v1X">Vector 1 x</param>
        /// <param name="v1Y">Vector 1 y</param>
        /// <param name="v2X">Vector 2 x</param>
        /// <param name="v2Y">Vector 2 y</param>
        /// <returns>Dot product of (v1X, v1Y) and (v2X, v2Y)</returns>
        public static float DotProduct(float v1X, float v1Y, float v2X, float v2Y)
        {
            return v1X * v2X + v1Y * v2Y;
        }

        /// <summary>
        /// Finds the square of the magnitude of the specified vector.
        /// </summary>
        /// <param name="v">The vector</param>
        /// <returns>Square of the magnitude of the vector</returns>
        public static float MagnitudeSquared(Vector2 v)
        {
            return v.X * v.X + v.Y * v.Y;
        }

        /// <summary>
        /// Finds the magnitude of the vector
        /// </summary>
        /// <param name="v">The vector</param>
        /// <returns>Magnitude of the vector</returns>
        public static float Magnitude(Vector2 v)
        {
            return (float)Math.Sqrt(MagnitudeSquared(v));
        }

        /// <summary>
        /// Finds the vector with magnitude 1 in the same direction
        /// as v.
        /// </summary>
        /// <param name="v">The vector</param>
        /// <returns>The normalized vector</returns>
        public static Vector2 Normalize(Vector2 v)
        {
            var magn = Magnitude(v);
            return new Vector2(v.X / magn, v.Y / magn);
        }

        /// <summary>
        /// Returns a vector that is perpendicular to the specified vector
        /// </summary>
        /// <param name="v">The vector</param>
        /// <returns>A perpendicular vector</returns>
        public static Vector2 Perpendicular(Vector2 v)
        {
            return new Vector2(-v.Y, v.X);
        }

        /// <summary>
        /// Determines if v1.X ~= v2.X and v1.Y ~= v2.Y.
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <param name="epsilon">How close is close enough</param>
        /// <returns>If v1 is approximately v2</returns>
        public static bool Approximately(Vector2 v1, Vector2 v2, float epsilon=Math2.DEFAULT_EPSILON)
        {
            return Math.Abs(v1.X - v2.X) <= epsilon && Math.Abs(v1.Y - v2.Y) <= epsilon;
        }

        /// <summary>
        /// Determines if obj is a Vector2 and is equal to this vector.
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>If this == obj</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;

            if (obj.GetType() != typeof(Vector2))
                return false;

            var v2 = (Vector2)obj;

            return this == v2;
        }

        public override int GetHashCode()
        {
            int result = 31;

            result = result * 17 + X.GetHashCode();
            result = result * 17 + Y.GetHashCode();

            return result;
        }

        public override string ToString()
        {
            return $"<{X}, {Y}>";
        }
    }
}
