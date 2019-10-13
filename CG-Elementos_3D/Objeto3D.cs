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

        public Objeto3D()
        {
            faces = new List<Face>();
            vertices = new List<Vertice>();
            originais = new List<Vertice>();
        }
        public Objeto3D(List<Face> faces, List<Vertice> vertices)
        {
            faces = new List<Face>();
            this.faces.AddRange(faces);

            vertices = new List<Vertice>();
            this.vertices.AddRange(vertices);

            originais = new List<Vertice>();
            this.originais.AddRange(vertices);
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
                vertices.Add(novo);
            }
        }
    }
}
