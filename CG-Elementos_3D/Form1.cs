using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_Elementos_3D
{
    public partial class Form1 : Form
    {
        Objeto3D objeto;

        int dx, dy, desx, desy, desz, rotacao, translacao, xini, yini;

        double escala;

        public Form1()
        {
            InitializeComponent();
            //objeto = new Objeto3D();

            this.pictureBox1.MouseWheel += scroll;

            dx = pictureBox1.Width / 2;
            dy = pictureBox1.Height / 2;

            rotacao = translacao = 0;
            escala = 1;

            desx = desy = desz = 0;

            lbEscala.Text = "Escala: " + escala;
            lbRotacao.Text = "Rotação: " + rotacao; 

            apagaPictureBox();
        }

        private void BtAbrir_Click(object sender, EventArgs e)
        {
            apagaPictureBox();

            objeto = new Objeto3D();

            if (opf.ShowDialog() == DialogResult.OK)
            {
                lbTitle.Text = opf.FileName;

                StreamReader sr = new StreamReader(opf.FileName);

                carregaObjeto(sr);
            }
        }

        private void scroll(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                escala += 0.1;
                objeto.escala(1.1);
            }
            else if(escala > 0.1)
            {
                escala -= 0.1;

                if (escala < 0.1)
                    escala = 0.1;

                objeto.escala(0.9);
            }
            lbEscala.Text = "Escala: " + escala;

            apagaPictureBox();
            desenha();
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            xini = e.X;
            yini = e.Y;

            Console.WriteLine(e.X + " - " + e.Y);
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            //if(Form1.ModifierKeys.ToString().Equals("Control"))
            { 
                desx = e.X - xini;
                desy = e.Y - yini;
                desz = 1;

                lbTX.Text = "X: " + desx;
                lbTY.Text = "Y: " + desy;

                objeto.translacao(desx, desy, desz);
                apagaPictureBox();
                desenha();  
            }
        }

        private void carregaObjeto(StreamReader sr)
        {
            String linha = sr.ReadLine();
            String[] splitada;
            char[] separators = {'v', 'f', ' '};

            List<Vertice> vertices = new List<Vertice>();

            while(linha != null)
            {
                if(linha != "")
                {

                    if (linha[0] == 'v' && linha[1] == ' ')    /// VÉRTICE
                    {
                        linha = linha.Remove(0, 2);
                        linha = linha.Replace(".", ",");

                        splitada = linha.Split(' ');

                        Vertice v = new Vertice((int)double.Parse(splitada[0]), (int)double.Parse(splitada[1]), (int)double.Parse(splitada[2]));

                        objeto.addVertice(v);

                        Console.WriteLine(v.X + " - " + v.Y + " - " + v.Z);
                    }

                    if (linha[0] == 'f')    /// FACE
                    {
                        //Console.WriteLine("Face");
                        linha = linha.Remove(0, 2);

                        splitada = linha.Split(' ');

                        splitada[0] = splitada[0].Substring(0, splitada[0].IndexOf('/'));
                        splitada[1] = splitada[1].Substring(0, splitada[1].IndexOf('/'));
                        splitada[2] = splitada[2].Substring(0, splitada[2].IndexOf('/'));

                        Face f = new Face(int.Parse(splitada[0]), int.Parse(splitada[1]), int.Parse(splitada[2]));

                        objeto.addFace(f);
                    }
                }

                linha = sr.ReadLine();
            }
            desenha();
        }

        private void desenha()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            foreach (Face f in objeto.Faces)
            {
                //if (isOnPictureBox(v.X + dx, v.Y + dy, pictureBox1))
                //    bmp.SetPixel(v.X + dx, v.Y + dy, Color.White);
                Vertice v1 = objeto.Vertices.ElementAt(f.getPosVertice(0) - 1);
                Vertice v2= objeto.Vertices.ElementAt(f.getPosVertice(1) - 1);
                Vertice v3 = objeto.Vertices.ElementAt(f.getPosVertice(2) - 1);

                Bresenham(v1.X + dx, v2.X + dx, v1.Y + dy, v2.Y + dy, bmp);
                Bresenham(v2.X + dx, v3.X + dx, v2.Y + dy, v3.Y + dy, bmp);
                Bresenham(v3.X + dx, v1.X + dx, v3.Y + dy, v1.Y + dy, bmp);
            }
            pictureBox1.Image = bmp;
        }

        private bool isOnPictureBox(int x, int y, PictureBox pb)
        {
            return x >= 0 && x < pb.Width && y >= 0 && y < pb.Height;
        }

        private void apagaPictureBox()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int y = 0; y < pictureBox1.Height; y++)
            {
                for (int x = 0; x < pictureBox1.Width; x++)
                    bmp.SetPixel(x, y, Color.Black);
            }
            pictureBox1.Image = bmp;
        }

        public void Bresenham(int x1, int x2, int y1, int y2, Bitmap bmp) /// FUNCIONA
        {
            int dx, dy, incE, incNE, declive, d, x, y;

            dx = (int)(x2 - x1);
            dy = (int)(y2 - y1);
            declive = 1;

            /*if (cor == Color.Red)
                Console.WriteLine("COR: RED");

            Console.WriteLine("P: " + x1 + ", " + x2 + ", " + y1 + ", " + y2);*/

            if (Math.Abs(dx) > Math.Abs(dy)) // FOR EM RELAÇÃO A X
            {
                if (x1 > x2)
                {
                    // INVERTE OS PONTOS E REFAZ AS PERGUNTAS
                    Bresenham(x2, x1, y2, y1, bmp);
                }
                else
                {
                    if (dy < 0)
                    {
                        // X, -Y
                        declive = -1;
                        dy = -dy;
                    }

                    incE = 2 * dy;
                    incNE = 2 * dy - 2 * dx;
                    d = incE - dx;

                    y = (int)y1;

                    for (x = (int)x1; x <= x2; x++)
                    {
                        if (isOnPictureBox(x, y, pictureBox1))
                            bmp.SetPixel(x, y, Color.White);

                        if (d < 0)
                            d += incE;
                        else
                        {
                            d += incNE;
                            y += declive;
                        }
                    }
                }
            }
            else // FOR EM RELAÇÃO A Y
            {
                if (y1 > y2)
                {
                    Bresenham(x2, x1, y2, y1, bmp);
                }
                else
                {
                    if (dx < 0)
                    {
                        declive = -1;
                        dx = -dx;
                    }

                    incE = 2 * dx;
                    incNE = 2 * dx - 2 * dy;
                    d = incE - dy;

                    x = (int)x1;
                    for (y = (int)y1; y <= y2; ++y)
                    {
                        if (isOnPictureBox(x, y, pictureBox1))
                            bmp.SetPixel(x, y, Color.White);
                        if (d < 0) // escolhe incE
                            d += incE;
                        else
                        {   // escolhe incNE
                            d += incNE;
                            x += declive;
                        }
                    }
                }
            }

        }
    }
}
