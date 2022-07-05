using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        Bitmap off;
        Timer t = new Timer();
        Camera camera = new Camera();

        List<Cell> cells;
        Cube cube;

        public Form1()
        {
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            cube.GoForward(10, cells);
            cube.GoLeft(10, cells);
            cube.GoRight(10, cells);
            cube.GameOver();

            DrawDubb(CreateGraphics());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!cube.isForward && !cube.isLeft && !cube.isRight && !cube.isGameOver)
            {
                if (e.KeyCode == Keys.Up)
                {
                    cube.isForward = true;
                }

                if (e.KeyCode == Keys.Right)
                {
                    cube.isRight = true;
                }

                if (e.KeyCode == Keys.Left)
                {
                    cube.isLeft = true;
                } 
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(ClientSize.Width, ClientSize.Height);

            CreateCamera();
            CreateCells();
            cube = new Cube(0, 50, camera);
        }

        private void CreateCells()
        {
            cells = new List<Cell>();
            Random random = new Random();
            int XS = -60;
            int YS = 50;
            for (int r = 0; r < 20; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Cell cell = new Cell();
                    cell.plane = new _3DModel();
                    cell.kwtsh = new Kwtsh(XS, YS, 8, camera);
                    CreatePlane(cell.plane, XS, YS, 0);
                    cell.kwtsh.Design();
                    if (random.NextDouble() < 0.2)
                    {
                        cell.isKwtsh = true;
                    }
                    else
                    {
                        cell.isKwtsh = false;
                    }
                    cells.Add(cell);

                    XS += 20;
                }
                YS -= 20;
                XS = -60;
            }

            cells[3].isKwtsh = false;
        }

        private void CreateCamera()
        {
            camera.ceneterX = ClientSize.Width / 2;
            camera.ceneterY = ClientSize.Height / 2;
            camera.BuildNewSystem();
        }

        void CreatePlane(_3DModel plane, float XS, float YS, float ZS)
        {
            float[] vert =
                            {
                                -10  ,  10  , 0  ,
                                10   , 10   , 0 ,
                                10   , -10   , 0,
                                -10  ,  -10  , 0
                            };


            _3DPoint point;
            for (int i = 0; i < vert.Length; i += 3)
            {
                point = new _3DPoint(vert[i] + XS, vert[i + 1] + YS, vert[i + 2] + ZS);
                plane.AddPoint(point);
            }


            int[] Edges = {
                              0,1 ,
                              1,2 ,
                              2,3 ,
                              3,0
                          };
            for (int i = 0; i < Edges.Length; i += 2)
            {
                plane.AddEdge(Edges[i], Edges[i + 1], Color.White);
            }
            plane.camera = camera;
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);

            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].DrawSelf(g);
            }

            cube.DrawYourSelf(g, 4);
        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
