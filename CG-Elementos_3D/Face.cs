using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Elementos_3D
{
    class Face
    {
        private List<int> vertices;

        public Face()
        {
            vertices  = new List<int>();
        }

        public Face(int p1, int p2, int p3)
        {
            vertices = new List<int>();
            vertices.Add(p1);
            vertices.Add(p2);
            vertices.Add(p3);
        }

        public void addVertice(int indice)
        {
            vertices.Add(indice);
        }

        public int getPosVertice(int index)
        {
            return vertices.ElementAt(index);
        }

        public bool getVisivel(List<Vertice> vo)
        {
            Vetor AB = new Vetor(vo.ElementAt(vertices.ElementAt(1) - 1).X - vo.ElementAt(vertices.ElementAt(0) - 1).X, vo.ElementAt(vertices.ElementAt(1) - 1).Y - vo.ElementAt(vertices.ElementAt(0) - 1).Y, vo.ElementAt(vertices.ElementAt(1) - 1).Z - vo.ElementAt(vertices.ElementAt(0) - 1).Z);
            Vetor AC = new Vetor(vo.ElementAt(vertices.ElementAt(2) - 1).X - vo.ElementAt(vertices.ElementAt(0) - 1).X, vo.ElementAt(vertices.ElementAt(2) - 1).Y - vo.ElementAt(vertices.ElementAt(0) - 1).Y, vo.ElementAt(vertices.ElementAt(2) - 1).Z - vo.ElementAt(vertices.ElementAt(0) - 1).Z);
            Vetor VN = new Vetor();

            VN.X = AB.Y * AC.Z - AB.Z * AC.Y;
            VN.Y = AB.Z * AC.X - AB.X * AC.Z;
            VN.Z = AB.X * AC.Y - AB.Y * AC.X;

            double mVN = Math.Pow(VN.X, 2) + Math.Pow(VN.Y, 2) + Math.Pow(VN.Z, 2);
            mVN = Math.Sqrt(mVN);

            VN.X /= mVN;
            VN.Y /= mVN;
            VN.Z /= mVN;

            if (VN.Z >= 0)
                return true;
            return false;
        }

        public bool getVisivelX(List<Vertice> vo)
        {
            Vetor AB = new Vetor(vo.ElementAt(vertices.ElementAt(1) - 1).X - vo.ElementAt(vertices.ElementAt(0) - 1).X, vo.ElementAt(vertices.ElementAt(1) - 1).Y - vo.ElementAt(vertices.ElementAt(0) - 1).Y, vo.ElementAt(vertices.ElementAt(1) - 1).Z - vo.ElementAt(vertices.ElementAt(0) - 1).Z);
            Vetor AC = new Vetor(vo.ElementAt(vertices.ElementAt(2) - 1).X - vo.ElementAt(vertices.ElementAt(0) - 1).X, vo.ElementAt(vertices.ElementAt(2) - 1).Y - vo.ElementAt(vertices.ElementAt(0) - 1).Y, vo.ElementAt(vertices.ElementAt(2) - 1).Z - vo.ElementAt(vertices.ElementAt(0) - 1).Z);
            Vetor VN = new Vetor();

            VN.X = AB.Y * AC.Z - AB.Z * AC.Y;
            VN.Y = AB.Z * AC.X - AB.X * AC.Z;
            VN.Z = AB.X * AC.Y - AB.Y * AC.X;

            double mVN = Math.Pow(VN.X, 2) + Math.Pow(VN.Y, 2) + Math.Pow(VN.Z, 2);
            mVN = Math.Sqrt(mVN);

            VN.X /= mVN;
            VN.Y /= mVN;
            VN.Z /= mVN;

            if (VN.X >= 0)
                return true;
            return false;
        }

        public bool getVisivelY(List<Vertice> vo)
        {
            Vetor AB = new Vetor(vo.ElementAt(vertices.ElementAt(1) - 1).X - vo.ElementAt(vertices.ElementAt(0) - 1).X, vo.ElementAt(vertices.ElementAt(1) - 1).Y - vo.ElementAt(vertices.ElementAt(0) - 1).Y, vo.ElementAt(vertices.ElementAt(1) - 1).Z - vo.ElementAt(vertices.ElementAt(0) - 1).Z);
            Vetor AC = new Vetor(vo.ElementAt(vertices.ElementAt(2) - 1).X - vo.ElementAt(vertices.ElementAt(0) - 1).X, vo.ElementAt(vertices.ElementAt(2) - 1).Y - vo.ElementAt(vertices.ElementAt(0) - 1).Y, vo.ElementAt(vertices.ElementAt(2) - 1).Z - vo.ElementAt(vertices.ElementAt(0) - 1).Z);
            Vetor VN = new Vetor();

            VN.X = AB.Y * AC.Z - AB.Z * AC.Y;
            VN.Y = AB.Z * AC.X - AB.X * AC.Z;
            VN.Z = AB.X * AC.Y - AB.Y * AC.X;

            double mVN = Math.Pow(VN.X, 2) + Math.Pow(VN.Y, 2) + Math.Pow(VN.Z, 2);
            mVN = Math.Sqrt(mVN);

            VN.X /= mVN;
            VN.Y /= mVN;
            VN.Z /= mVN;

            if (VN.Y >= 0)
                return true;
            return false;
        }





    }
}
