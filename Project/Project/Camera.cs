using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Project
{
    class Camera
    {
        public _3DPoint cop;
        public _3DPoint lookAt;
        public _3DPoint up;
        public _3DPoint basisa, lookDir, basisc;
        public float focal = 300;

        public int ceneterX, ceneterY;

        public Camera()
        {
            cop = new _3DPoint(0, 0, -100);
            lookAt = new _3DPoint(5, -5, 50);
            up = new _3DPoint(0, 1, 0);
        }

        public void BuildNewSystem()
        {
            lookDir = new _3DPoint(0, 0, 0);
            basisa = new _3DPoint(0, 0, 0);
            basisc = new _3DPoint(0, 0, 0);

            lookDir.X = lookAt.X - cop.X;
            lookDir.Y = lookAt.Y - cop.Y;
            lookDir.Z = lookAt.Z - cop.Z;
            Matrix.Normalise(lookDir);

            basisa = Matrix.CrossProduct(up, lookDir);
            Matrix.Normalise(basisa);

            basisc = Matrix.CrossProduct(lookDir, basisa);
            Matrix.Normalise(basisc);
        }

        public void TransformToOrigin_And_Rotate(_3DPoint p1, _3DPoint p2)
        {
            _3DPoint w = new _3DPoint(p1.X, p1.Y, p1.Z);
            w.X -= cop.X;
            w.Y -= cop.Y;
            w.Z -= cop.Z;

            p2.X = w.X * basisa.X + w.Y * basisa.Y + w.Z * basisa.Z;
            p2.Y = w.X * basisc.X + w.Y * basisc.Y + w.Z * basisc.Z;
            p2.Z = w.X * lookDir.X + w.Y * lookDir.Y + w.Z * lookDir.Z;
        }

        public PointF TransformToOrigin_And_Rotate_And_Project(_3DPoint point)
        {
            _3DPoint p1 = new _3DPoint(0, 0, 0);
            TransformToOrigin_And_Rotate(point, p1);


            _3DPoint n1 = new _3DPoint(0, 0, 0);
            n1.X = focal * p1.X / p1.Z;
            n1.Y = focal * p1.Y / p1.Z;
            n1.Z = focal;

            n1.X = (int)(ceneterX + n1.X);
            n1.Y = (int)(ceneterY + n1.Y);

            return new PointF(n1.X, n1.Y);
        }
    }
}
