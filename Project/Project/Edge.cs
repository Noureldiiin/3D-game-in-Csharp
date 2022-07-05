using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Project
{
    class Edge
    {
        public int i, j;
        public Color color;

        public Edge(int i, int j, Color cl)
        {
            this.i = i;
            this.j = j;
            color = cl;
        }
    }
}
