using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Elementos_3D
{
    class Aresta
    {
        private Vertice inicio;
        private Vertice fim;

        public Aresta() { }
        public Aresta(Vertice inicio, Vertice fim)
        {
            this.inicio = inicio;
            this.fim = fim;
        }

        internal Vertice Inicio { get => inicio; set => inicio = value; }
        internal Vertice Fim { get => fim; set => fim = value; }
    }
}
