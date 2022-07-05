using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Project
{
    class Cell
    {
        public _3DModel plane;
        public Kwtsh kwtsh;
        public bool isKwtsh;

        public void TranslateY(float y)
        {
            plane.TranslateY(y);
            kwtsh.TranslateY(y);
        }

        public void DrawSelf(Graphics g)
        {
            plane.DrawYourSelf(g, 2);
            if (isKwtsh)
            {
                kwtsh.DrawYourSelf(g, 2); 
            }
        }
    }
}
