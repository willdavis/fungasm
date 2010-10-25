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

        public double Length() { return Math.Sqrt(X * X + Y * Y + Z * Z); }
        public bool Equals(Vector v) { return (X == v.X) && (Y == v.Y) && (Z == v.Z); }

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

    }
}
