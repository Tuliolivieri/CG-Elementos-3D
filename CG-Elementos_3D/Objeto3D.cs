using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Elementos_3D
{
    class Objeto3D
    {
        private List<Face> faces;
        private List<Vertice> vertices;
        private List<Vertice> originais;

        private double[,] ma;

        public Objeto3D()
        {
            faces = new List<Face>();
            vertices = new List<Vertice>();
            originais = new List<Vertice>();

            ma = geraMA();
        }
        public Objeto3D(List<Face> faces, List<Vertice> vertices)
        {
            faces = new List<Face>();
            this.faces.AddRange(faces);

            vertices = new List<Vertice>();
            this.vertices.AddRange(vertices);

            originais = new List<Vertice>();
            this.originais.AddRange(vertices);

            ma = geraMA();
        }

        internal List<Face> Faces { get => faces; set => faces = value; }
        internal List<Face> Faces1 { get => faces; set => faces = value; }
        internal List<Vertice> Vertices { get => vertices; set => vertices = value; }
        internal List<Vertice> Originais { get => originais; set => originais = value; }

        public void addFace(Face nova)
        {
            if (faces != null)
                faces.Add(nova);
        }

        public void addVertice(Vertice novo)
        {
            if(originais != null && vertices != null)
            {
                originais.Add(novo);
                vertices.Add(new Vertice(novo.X, novo.Y, novo.Z));
            }
        }

        public void rotacao(int ang)
        {
            double[,] m = new double[3, 3];
        }

        public void translacao(int tx, int ty, int tz)
        {
            double[,] m = new double[4, 4];

            m[0, 0] = m[1, 1] = m[2, 2] = m[3, 3] = 1;

            m[0, 3] = tx;
            m[1, 3] = ty;
            m[2, 3] = tz;

            ma = multiplicaMatriz(ma, m);

            Vertice v, vo;

            /*int i = 0;
            int f = originais.Count;
            Parallel.For(i, f, index =>
            {
                v = vertices.ElementAt(i);
                vo = originais.ElementAt(i);

                v.X = (int)(vo.X * ma[0, 0] + vo.Y * ma[0, 1] + v.Z * ma[0, 2] + ma[0, 3]);
                v.Y = (int)(vo.X * ma[1, 0] + vo.Y * ma[1, 1] + v.Z * ma[1, 2] + ma[1, 3]);
                v.Z = (int)(vo.X * ma[2, 0] + vo.Y * ma[2, 1] + v.Z * ma[2, 2] + ma[2, 3]);
            });*/

            for (int i = 0; i < originais.Count; i++)
            {
                v = vertices.ElementAt(i);
                vo = originais.ElementAt(i);
                
                v.X = (int)(vo.X * ma[0, 0] + vo.Y * ma[0, 1] + vo.Z * ma[0, 2] + ma[0, 3]);
                v.Y = (int)(vo.X * ma[1, 0] + vo.Y * ma[1, 1] + vo.Z * ma[1, 2] + ma[1, 3]);
                v.Z = (int)(vo.X * ma[2, 0] + vo.Y * ma[2, 1] + vo.Z * ma[2, 2] + ma[2, 3]);
            }
        }

        public void escala(double esc)
        {
            double[,] m = new double[4, 4];

            m[0, 0] = m[1, 1] = m[2, 2] = esc;
            m[3, 3] = 1;

            ma = multiplicaMatriz(ma, m);

            Vertice v, vo;

            for (int i = 0; i < originais.Count; i++)
            {
                v = vertices.ElementAt(i);
                vo = originais.ElementAt(i);

                v.X = (int)(vo.X * ma[0, 0] + vo.Y * ma[0, 1] + vo.Z * ma[0, 2] + ma[0, 3]);
                v.Y = (int)(vo.X * ma[1, 0] + vo.Y * ma[1, 1] + vo.Z * ma[1, 2] + ma[1, 3]);
                v.Z = (int)(vo.X * ma[2, 0] + vo.Y * ma[2, 1] + vo.Z * ma[2, 2] + ma[2, 3]);
            }
        }

        public void rotacao_x(int ang)
        {
            double[,] m = new double[4, 4];

            m[0, 0] = m[3, 3] = 1;

            m[1, 1] = m[2, 2] = Math.Cos(ang);
            m[1, 2] = -Math.Sin(ang);
            m[2, 1] = Math.Sin(ang);

            ma = multiplicaMatriz(ma, m);

            Vertice v, vo;

            for (int i = 0; i < originais.Count; i++)
            {
                v = vertices.ElementAt(i);
                vo = originais.ElementAt(i);

                v.X = (int)(vo.X * ma[0, 0] + vo.Y * ma[0, 1] + vo.Z * ma[0, 2] + ma[0, 3]);
                v.Y = (int)(vo.X * ma[1, 0] + vo.Y * ma[1, 1] + vo.Z * ma[1, 2] + ma[1, 3]);
                v.Z = (int)(vo.X * ma[2, 0] + vo.Y * ma[2, 1] + vo.Z * ma[2, 2] + ma[2, 3]);
            }
        }

        public void rotacao_y(int ang)
        {
            double[,] m = new double[4, 4];

            m[1, 1] = m[3, 3] = 1;

            m[0, 0] = m[2, 2] = Math.Cos(ang);
            m[2, 0] = -Math.Sin(ang);
            m[0, 2] = Math.Sin(ang);

            ma = multiplicaMatriz(ma, m);

            Vertice v, vo;

            for (int i = 0; i < originais.Count; i++)
            {
                v = vertices.ElementAt(i);
                vo = originais.ElementAt(i);

                v.X = (int)(vo.X * ma[0, 0] + vo.Y * ma[0, 1] + vo.Z * ma[0, 2] + ma[0, 3]);
                v.Y = (int)(vo.X * ma[1, 0] + vo.Y * ma[1, 1] + vo.Z * ma[1, 2] + ma[1, 3]);
                v.Z = (int)(vo.X * ma[2, 0] + vo.Y * ma[2, 1] + vo.Z * ma[2, 2] + ma[2, 3]);
            }
        }

        public void rotacao_z(int ang)
        {
            double[,] m = new double[4, 4];

            m[2, 2] = m[3, 3] = 1;

            m[0, 0] = m[1, 1] = Math.Cos(ang);
            m[0, 1] = -Math.Sin(ang);
            m[1, 0] = Math.Sin(ang);

            ma = multiplicaMatriz(ma, m);

            Vertice v, vo;

            for (int i = 0; i < originais.Count; i++)
            {
                v = vertices.ElementAt(i);
                vo = originais.ElementAt(i);

                v.X = (int)(vo.X * ma[0, 0] + vo.Y * ma[0, 1] + vo.Z * ma[0, 2] + ma[0, 3]);
                v.Y = (int)(vo.X * ma[1, 0] + vo.Y * ma[1, 1] + vo.Z * ma[1, 2] + ma[1, 3]);
                v.Z = (int)(vo.X * ma[2, 0] + vo.Y * ma[2, 1] + vo.Z * ma[2, 2] + ma[2, 3]);
            }
        }

        public double[,] geraMA()
        {
            double[,] m = new double[4, 4];

            m[0, 0] = m[1, 1] = m[2, 2] = m[3, 3] = 1;

            return m;
        }

        private double[,] multiplicaMatriz(double[,] mat1, double[,] mat2)
        {
            double[,] mat = new double[4, 4];
            int i, j, k;
            double val;

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    val = 0;
                    for (k = 0; k < 4; k++)
                    {
                        val += mat1[i, k] * mat2[k, j];
                    }
                    mat[i, j] = val;
                }
            }

            return mat;
        }
    }
}
