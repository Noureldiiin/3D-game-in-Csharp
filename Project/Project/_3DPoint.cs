using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class _3DPoint
    {
        public float X, Y, Z;
        public _3DPoint(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public _3DPoint(_3DPoint point)
        {
            X = point.X;
            Y = point.Y;
            Z = point.Z;
        }
    }
}
