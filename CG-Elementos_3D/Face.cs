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
    }
}
