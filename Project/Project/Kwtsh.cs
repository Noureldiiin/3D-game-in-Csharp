using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Project
{
    class Kwtsh : _3DModel
    {
        public float XS, YS, radius;

        public Kwtsh(float xS, float yS, float radius, Camera camera)
        {
            XS = xS;
            YS = yS;
            this.radius = radius;
            this.camera = camera;
        }

        public void Design()
        {
            float x, y;
            int i = 0;
            int increment = 1;
            int iStart = 0;

            for (float theta = 0; theta < 360; theta += increment)
            {
                x = (float)(Math.Cos(theta * Math.PI / 180) * radius) + XS;
                y = (float)(Math.Sin(theta * Math.PI / 180) * radius) + YS;
                points.Add(new _3DPoint(x, y, 0));

                if (i > 0)
                {
                    if (theta > 0)
                    {
                        AddEdge(i, i - 1, Color.Yellow);
                    }
                }
                i++;
            }
            AddEdge(i - 1, iStart, Color.Yellow);
        }
    }
}
