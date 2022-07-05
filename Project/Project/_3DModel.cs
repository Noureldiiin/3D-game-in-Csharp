using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Project
{
    class _3DModel
    {
        public List<_3DPoint> points = new List<_3DPoint>();
        public List<Edge> edges = new List<Edge>();
        public Camera camera;

        public void AddPoint(_3DPoint pnn)
        {
            points.Add(pnn);
        }

        public void AddEdge(int i, int j, Color cl)
        {
            Edge edge = new Edge(i, j, cl);
            edges.Add(edge);
        }

        public void RotateX(float theta)
        {
            Transformation.RotateX(points, theta);
        }

        public void RotateY(float theta)
        {
            Transformation.RotateY(points, theta);
        }

        public void RotateZ(float theta)
        {
            Transformation.RotateZ(points, theta);
        }

        public void TranslateX(float x)
        {
            Transformation.TranslateX(points, x);
        }

        public void TranslateY(float y)
        {
            Transformation.TranslateY(points, y);
        }

        public void TranslateZ(float z)
        {
            Transformation.TranslateZ(points, z);
        }

        public void RotateAroundEdge(int iWhichEdge, float theta)
        {
            _3DPoint p1 = new _3DPoint(points[edges[iWhichEdge].i]);
            _3DPoint p2 = new _3DPoint(points[edges[iWhichEdge].j]);
            Transformation.RotateArbitrary(points, p1, p2, theta);
        }

        public void DrawYourSelf(Graphics g, int lineWidth)
        {
            for (int k = 0; k < edges.Count; k++)
            {
                int i = edges[k].i;
                int j = edges[k].j;

                _3DPoint pi = points[i];
                _3DPoint pj = points[j];

                PointF pi_2D = camera.TransformToOrigin_And_Rotate_And_Project(pi);
                PointF pj_2D = camera.TransformToOrigin_And_Rotate_And_Project(pj);



                Pen Pn = new Pen(edges[k].color, lineWidth);

                g.DrawLine(Pn, pi_2D.X, pi_2D.Y, pj_2D.X, pj_2D.Y);
            }
        }
    }
}
