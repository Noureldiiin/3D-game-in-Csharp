using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Transformation
    {
        public static void RotateX(List<_3DPoint> points, float theta)
        {


            float th = (float)(Math.PI * theta / 180);
            for (int i = 0; i < points.Count; i++)
            {
                _3DPoint point = points[i];

                float y = (float)(point.Y * Math.Cos(th) - point.Z * Math.Sin(th));
                float z = (float)(point.Y * Math.Sin(th) + point.Z * Math.Cos(th));

                point.Y = y;
                point.Z = z;
            }
        }

        public static void RotateY(List<_3DPoint> points, float theta)
        {

            float th = (float)(Math.PI * theta / 180);
            for (int i = 0; i < points.Count; i++)
            {
                _3DPoint point = points[i];


                float x = (float)(point.Z * Math.Sin(th) + point.X * Math.Cos(th));
                float z = (float)(point.Z * Math.Cos(th) - point.X * Math.Sin(th));

                point.X = x;
                point.Z = z;
            }
        }

        public static void RotateZ(List<_3DPoint> points, float theta)
        {

            float th = (float)(Math.PI * theta / 180);
            for (int i = 0; i < points.Count; i++)
            {
                _3DPoint point = points[i];


                float x = (float)(point.X * Math.Cos(th) - point.Y * Math.Sin(th));
                float y = (float)(point.X * Math.Sin(th) + point.Y * Math.Cos(th));

                point.X = x;
                point.Y = y;
            }
        }

        public static void TranslateX(List<_3DPoint> points, float x)
        {
            for (int i = 0; i < points.Count; i++)
            {
                _3DPoint point = points[i];
                point.X += x;
            }
        }

        public static void TranslateY(List<_3DPoint> points, float y)
        {
            for (int i = 0; i < points.Count; i++)
            {
                _3DPoint point = points[i];
                point.Y += y;
            }
        }

        public static void TranslateZ(List<_3DPoint> points, float z)
        {
            for (int i = 0; i < points.Count; i++)
            {
                _3DPoint point = points[i];
                point.Z += z;
            }
        }


        public static void RotateArbitrary(List<_3DPoint> points, _3DPoint p1, _3DPoint p2, float theta)
        {
            Transformation.TranslateX(points, p1.X * -1);
            Transformation.TranslateY(points, p1.Y * -1);
            Transformation.TranslateZ(points, p1.Z * -1);

            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            float dz = p2.Z - p1.Z;

            float th = (float)Math.Atan2(dy, dx);
            float phi = (float)Math.Atan2(Math.Sqrt(dx * dx + dy * dy), dz);

            th = (float)(th * 180 / Math.PI);
            phi = (float)(phi * 180 / Math.PI);
            Transformation.RotateZ(points, th * -1);
            Transformation.RotateY(points, phi * -1);

            Transformation.RotateZ(points, theta);

            Transformation.RotateY(points, phi * 1);
            Transformation.RotateZ(points, th * 1);
            Transformation.TranslateZ(points, p1.Z * 1);
            Transformation.TranslateY(points, p1.Y * 1);
            Transformation.TranslateX(points, p1.X * 1);
        }
    }
}
