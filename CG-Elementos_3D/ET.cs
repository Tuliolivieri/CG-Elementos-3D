using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_Elementos_3D
{
    class ET
    {
        private double xmin, ymax, incx;
        ET proxima;

        public ET()
        {
            this.xmin = 0;
            this.ymax = 0;
            this.incx = 0;
            this.proxima = null;
        }

        public ET(double xmin, double ymax, double incx)
        {
            this.xmin = xmin;
            this.ymax = ymax;
            this.incx = incx;
            this.proxima = null;
        }

        public double Xmin { get => xmin; set => xmin = value; }
        public double Ymax { get => ymax; set => ymax = value; }
        public double Incx { get => incx; set => incx = value; }
        internal ET Proxima { get => proxima; set => proxima = value; }
    }
}
