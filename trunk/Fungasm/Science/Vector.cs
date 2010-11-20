using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace Fungasm.Science
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
            : this()
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector(Vector v)
            : this()
        {
            X = v.X;
            Y = v.Y;
            Z = v.Z;
        }

        public static Vector Zero = new Vector(0, 0, 0);

        public double Length() { return Math.Sqrt(X * X + Y * Y + Z * Z); }
        public double LengthSquared() { return X * X + Y * Y + Z * Z; }

        public bool Equals(Vector v) { return (X == v.X) && (Y == v.Y) && (Z == v.Z); }
        public Vector Invert()
        {
            return new Vector(-X, -Y, -Z);
        }
        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y, Z + v.Z);
        }
        /// <summary>
        /// Adds the current vector with a scaled vector (this+vs)
        /// </summary>
        /// <param name="v"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public void AddScaledVector(Vector v, double s)
        {
            X += v.X * s;
            Y += v.Y * s;
            Z += v.Z * s;
        }
        public Vector Subtract(Vector v)
        {
            return new Vector(X - v.X, Y - v.Y, Z - v.Z);
        }
        public Vector Scale(double s)
        {
            return new Vector(X * s, Y * s, Z * s);
        }
        public double DotProduct(Vector v)
        {
            return (v.X * X) + (Y * v.Y) + (Z * v.Z);
        }
        public Vector CrossProduct(Vector v)
        {
            //this = B, vector param = C
            double x = Y * v.Z - Z * v.Y;   //Ax = ByCz - BzCy
            double y = Z * v.X - X * v.Z;   //Ay = BzCx - BxCz
            double z = X * v.Y - Y * v.X;   //Az = BxCy - ByCx
            return new Vector(x,y,z);
        }
        public Vector ComponentProduct(Vector v)
        {
            return new Vector(X * v.X, Y * v.Y, Z * v.Z);
        }

        /// <summary>
        /// Sets all vector components to zero
        /// </summary>
        public void Clear()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }
        public Vector Normalize()
        {
            double r = Length();
            if (r != 0.0) // If the length is 0, then the vector is at the origin
            {
                return new Vector(X / r, Y / r, Z / r); // normalize and return
            }
            else
            {
                return new Vector(0, 0, 0);
            }
        }

        public override int GetHashCode() { return (int)X ^ (int)Y ^ (int)Z; }
        public override bool Equals(object obj)
        {
            if (obj is Vector)
                return Equals((Vector)obj);
            return base.Equals(obj);
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            // If they're the same object or both null, return true.
            if (System.Object.ReferenceEquals(v1, v2))
            {
                return true;
            }
            // If one is null, but not both, return false.
            if (v1 == null || v2 == null)
            {
                return false;
            }
            return v1.Equals(v2);
        }
        public static bool operator !=(Vector v1, Vector v2)
        {
            return !v1.Equals(v2);
        }
        public static Vector operator +(Vector v1, Vector v2)
        {
            return v1.Add(v2);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return v1.Subtract(v2);
        }
        public static Vector operator *(Vector v, double s)
        {
            return v.Scale(s);
        }
        public static double operator *(Vector v1, Vector v2)
        {
            return v1.DotProduct(v2);
        }
        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Z:{2}", X, Y, Z);
        }
    }
}
