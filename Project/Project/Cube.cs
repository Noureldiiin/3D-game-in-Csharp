using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Project
{
    class Cube : _3DModel
    {
        public int XS, YS, r, c;
        public bool isForward, isRight, isLeft, isGameOver;
        int ct;

        public Cube(int xS, int yS, Camera camera)
        {
            XS = xS;
            YS = yS;
            r = 0;
            c = 3;
            CreateCube(XS, YS, -10, camera);
        }

        public void GameOver()
        {
            if (isGameOver)
            {
                TranslateZ(5);
            }
        }

        public void CheckGameOver(List<Cell> cells)
        {
            if (cells[(r * 8)  + c].isKwtsh)
            {
                isGameOver = true;
            }
        }

        public void GoForward(float theta, List<Cell> cells)
        {
            if (r >= (cells.Count / 8) - 1)
            {
                isForward = false;
            }

            if (isForward)
            {
                RotateAroundEdge(5, theta);
                MoveCells(cells, theta);
                TranslateY(20 / (90 / theta));
                ct++;
                if (ct >= 90 / theta)
                {
                    isForward = false;
                    ct = 0;
                    r++;
                    CreateCube(XS, YS, -10, camera);
                    CheckGameOver(cells);
                }
            }
        }

        private void MoveCells(List<Cell> cells, float theta)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].TranslateY(20 / (90 / theta));
            }
        }

        public void GoLeft(float theta, List<Cell> cells)
        {
            if (c <= 0)
            {
                isLeft = false;
            }

            if (isLeft)
            {
                RotateAroundEdge(10, -theta);
                ct++;
                if (ct >= 90 / theta)
                {
                    isLeft = false;
                    ct = 0;
                    XS -= 20;
                    c--;
                    CreateCube(XS, YS, -10, camera);
                    CheckGameOver(cells);
                }
            }
        }

        public void GoRight(float theta, List<Cell> cells)
        {
            if (c >= 7)
            {
                isRight = false;
            }

            if (isRight)
            {
                RotateAroundEdge(11, theta);
                ct++;
                if (ct >= 90 / theta)
                {
                    isRight = false;
                    ct = 0;
                    XS += 20;
                    c++;
                    CreateCube(XS, YS, -10, camera);
                    CheckGameOver(cells);
                }
            }
        }

        private void CreateCube(float XS, float YS, float ZS, Camera camera)
        {
            points.Clear();
            edges.Clear();
            float[] vert =
                            {
                                     10,     10,     -10,
                                     10,     10,      10,
                                    -10,     10,      10,
                                    -10,     10,     -10,
                                     10,    -10,     -10,
                                     10,    -10,      10,
                                    -10,    -10,      10,
                                    -10,    -10,     -10

                            };


            _3DPoint point;
            for (int i = 0; i < vert.Length; i += 3)
            {
                point = new _3DPoint(vert[i] + XS, vert[i + 1] + YS, vert[i + 2] + ZS);
                AddPoint(point);
            }


            int[] Edges = {
                                0,1,
                                1,2,
                                2,3,
                                3,0,
                                4,5,
                                5,6,
                                6,7,
                                7,4,
                                0,4,
                                3,7,
                                2,6,
                                1,5
                          };
            for (int i = 0; i < Edges.Length; i += 2)
            {
                AddEdge(Edges[i], Edges[i + 1], Color.White);
            }

            this.camera = camera;
        }
    }
}
