using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Matrix
    {
        static public void Normalise(_3DPoint point)
        {
            float length;

            length = (float)Math.Sqrt(point.X * point.X + point.Y * point.Y + point.Z * point.Z);
            point.X /= length;
            point.Y /= length;
            point.Z /= length;
        }

        static public _3DPoint CrossProduct(_3DPoint p1, _3DPoint p2)
        {
            _3DPoint p3;
            p3 = new _3DPoint(0, 0, 0);
            p3.X = p1.Y * p2.Z - p1.Z * p2.Y;
            p3.Y = p1.Z * p2.X - p1.X * p2.Z;
            p3.Z = p1.X * p2.Y - p1.Y * p2.X;
            return p3;
        }
    }
}
