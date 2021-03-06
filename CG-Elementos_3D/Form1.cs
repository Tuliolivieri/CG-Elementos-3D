﻿using System;
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

        int dx, dy, desx, desy, desz, translacao, xini, yini;
        double ang_x, ang_y, ang_z;
        double escala;

        DirectBitmap bmp;
        DirectBitmap bmpxy;
        DirectBitmap bmpyz;
        DirectBitmap bmpxz;

        Color cor_fundo;
        Color cor_obj;

        public Form1()
        {
            InitializeComponent();
            //objeto = new Objeto3D();

            this.pictureBox1.MouseWheel += scroll;

            dx = pictureBox1.Width / 2;
            dy = pictureBox1.Height / 2;

            ang_x = ang_y = ang_z = 0;

            escala = 1;

            desx = desy = desz = 0;

            lbEscala.Text = "Escala: " + escala;
            //lbRotacao.Text = "Rotação: " + rotacao; 

            bmp = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp.Bitmap;

            bmpxy = new DirectBitmap(pbPXY.Width, pbPXY.Height);
            pbPXY.Image = bmpxy.Bitmap;

            bmpyz = new DirectBitmap(pbPYZ.Width, pbPYZ.Height);
            pbPYZ.Image = bmpyz.Bitmap;

            bmpxz = new DirectBitmap(pbPXZ.Width, pbPXZ.Height);
            pbPXZ.Image = bmpxz.Bitmap;

            cor_fundo = Color.Black;
            cor_obj = Color.White;

            pictureBox1.BackColor = cor_fundo;
            pbPYZ.BackColor = cor_fundo;
            pbPXZ.BackColor = cor_fundo;
            pbPXY.BackColor = cor_fundo;

            cbParaOrt.Checked = true;

            lbP1.Text = "X, Y";
            lbP2.Text = "Y, Z";
            lbP3.Text = "X, Z";

            cbWireFrame.CheckState = CheckState.Checked;

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

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(objeto != null)
            {
                if (e.Button == MouseButtons.Right)
                {
                    desx = e.X - xini;
                    desy = e.Y - yini;

                    objeto.translacao(desx, desy, 0);
                    apagaPictureBox();
                    desenha();

                    xini = e.X;
                    yini = e.Y;
                }
                else if (e.Button == MouseButtons.Left)
                {
                    //Console.WriteLine("Rotacionar");
                    desx = e.X - xini;
                    desy = e.Y - yini;

                    ang_x = (-desy * Math.PI / 180);
                    ang_y = (desx * Math.PI / 180);

                    //ang_x = 1; ang_y = 1;

                    objeto.rotacao_x(ang_x);
                    objeto.rotacao_y(ang_y);

                    apagaPictureBox();
                    desenha();

                    xini = e.X;
                    yini = e.Y;
                }
            }
        }

        private void scroll(object sender, MouseEventArgs e)
        {
            if(objeto != null)
            {
                if (Form1.ModifierKeys == Keys.Control) /// ROTAÇÃO NO EIXO Z
                {
                    int ang = 0;
                    if (e.Delta > 0)
                    {
                        ang_z = 1;
                        ang = 1;
                    }
                    else
                    {
                        ang_z = -1;
                        ang = -1;
                    }
                    ang_z = (ang_z * (Math.PI / 180));
                    objeto.rotacao_z(ang_z);
                    apagaPictureBox();
                    desenha();
                }
                else if (e.Delta > 0)
                {
                    escala += 0.1;
                    objeto.escala(1.1);
                }
                else if (escala > 0.1)
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
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            xini = e.X;
            yini = e.Y;
        }

        private void BtCorFundo_Click(object sender, EventArgs e)
        {
            if(cdCorFundo.ShowDialog() == DialogResult.OK)
            {
                cor_fundo = cdCorFundo.Color;
                pictureBox1.BackColor = cor_fundo;
                pbPYZ.BackColor = cor_fundo;
                pbPXZ.BackColor = cor_fundo;
                pbPXY.BackColor = cor_fundo;
            }

        }

        private void BtCorObj_Click(object sender, EventArgs e)
        {
            if(cdCorObj.ShowDialog() == DialogResult.OK)
            {
                cor_obj = cdCorObj.Color;
                desenha();
            }
        }

        private void CbBackCull_CheckedChanged(object sender, EventArgs e)
        {
            desenha();
        }

        private void cbParaOrt_CheckedChanged(object sender, EventArgs e)
        {
            if (cbParaOrt.CheckState == CheckState.Checked)
            {
                cbParaObli.CheckState = CheckState.Unchecked;

                lbP1.Text = "X, Y";
                lbP2.Text = "Y, Z";
                lbP3.Text = "X, Z";
            }
            else
            {
                cbParaObli.CheckState = CheckState.Checked;

                lbP1.Text = "Cavaleira";
                lbP2.Text = "Cabinet";
                lbP3.Text = "1 Ponto de Fulga";
            }
            desenha();
        }

        private void cbParaObli_CheckedChanged(object sender, EventArgs e)
        {
            if (cbParaObli.CheckState == CheckState.Checked)
            {
                cbParaOrt.CheckState = CheckState.Unchecked;

                lbP1.Text = "Cavaleira";
                lbP2.Text = "Cabinet";
                lbP3.Text = "1 Ponto de Fulga";
            }
            else
            {
                cbParaOrt.CheckState = CheckState.Checked;

                lbP1.Text = "X, Y";
                lbP2.Text = "Y, Z";
                lbP3.Text = "X, Z";
            }
            desenha();
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(objeto != null && e.Button == MouseButtons.Right)
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

                        Vertice v = new Vertice(double.Parse(splitada[0]), double.Parse(splitada[1]), double.Parse(splitada[2]));

                        objeto.addVertice(v);
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

        private void btLuz_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button.Equals(MouseButtons.Right))
            {
                int x = e.X + btLuz.Location.X;
                int y = e.Y + btLuz.Location.Y;

                if (x > pictureBox1.Location.X && x < pictureBox1.Location.X + pictureBox1.Width - 42)
                    if(y > pictureBox1.Location.Y && y < pictureBox1.Location.Y + pictureBox1.Height - 42)
                        btLuz.SetBounds(x, y, 42, 42);
            }
        }

        private void desenha()
        {
            //pictureBox1.Image.Dispose();

            //DirectBitmap bmp = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
            //pictureBox1.Image = (Image)bmp.Bitmap;
        
            //foreach (Face f in objeto.Faces)
            if(objeto != null)
            { 
                Parallel.For(0, objeto.Faces.Count, i => 
                {
                    Face f = objeto.Faces[i];
                    Vertice v1 = objeto.Vertices.ElementAt(f.getPosVertice(0) - 1);
                    Vertice v2 = objeto.Vertices.ElementAt(f.getPosVertice(1) - 1);
                    Vertice v3 = objeto.Vertices.ElementAt(f.getPosVertice(2) - 1);

                    if(cbBackCull.CheckState == CheckState.Checked)
                    {
                        if(f.getVisivel(objeto.Vertices))
                        {
                            Bresenham((int)v1.X + dx, (int)v2.X + dx, (int)v1.Y + dy, (int)v2.Y + dy, bmp, pictureBox1);
                            Bresenham((int)v2.X + dx, (int)v3.X + dx, (int)v2.Y + dy, (int)v3.Y + dy, bmp, pictureBox1);
                            Bresenham((int)v3.X + dx, (int)v1.X + dx, (int)v3.Y + dy, (int)v1.Y + dy, bmp, pictureBox1);
                        }
                    }
                    else
                    {
                        Bresenham((int)v1.X + dx, (int)v2.X + dx, (int)v1.Y + dy, (int)v2.Y + dy, bmp, pictureBox1);
                        Bresenham((int)v2.X + dx, (int)v3.X + dx, (int)v2.Y + dy, (int)v3.Y + dy, bmp, pictureBox1);
                        Bresenham((int)v3.X + dx, (int)v1.X + dx, (int)v3.Y + dy, (int)v1.Y + dy, bmp, pictureBox1);
                    }
                });
                pictureBox1.Refresh();

                //if (cbFlat.Checked)
                //{
                //    foreach(Face f in objeto.Faces)
                //    {
                //        scanLine(f, objeto.Vertices);
                //    }
                //}

                if (cbParaOrt.Checked)
                {
                    desenha_xy();
                    desenha_yz();
                    desenha_xz();
                }
                else if(cbParaObli.Checked)
                {
                    desenha_cavaleira();
                    desenha_cabintet();
                    desenha_1pf();
                }
            }
        }

        private void desenha_xy()
        {
            pbPXY.Image = null;
            Console.WriteLine("DESENHA XY");
            bmpxy.Dispose();
            bmpxy = new DirectBitmap(pbPXY.Width, pbPXY.Height);
            
            pbPXY.Image = bmpxy.Bitmap;

            double rx = pbPXY.Width / pictureBox1.Width + 0.5;
            double ry = pbPXY.Height / pictureBox1.Height + 0.5;

            //Console.WriteLine(rx);

            Parallel.For(0, objeto.Faces.Count, i =>
            {
                Face f = objeto.Faces[i];
                Vertice v1 = objeto.Vertices.ElementAt(f.getPosVertice(0) - 1);
                Vertice v2 = objeto.Vertices.ElementAt(f.getPosVertice(1) - 1);
                Vertice v3 = objeto.Vertices.ElementAt(f.getPosVertice(2) - 1);

                if (cbBackCull.CheckState == CheckState.Checked)
                {
                    if (f.getVisivel(objeto.Vertices))
                    {
                        Bresenham((int) ((v1.X + dx) * rx - 50), (int) ((v2.X + dx) * rx - 50), (int) ((v1.Y + dy) * ry - 80), (int) ((v2.Y + dy) * ry - 80), bmpxy, pbPXY);
                        Bresenham((int) ((v2.X + dx) * rx - 50), (int) ((v3.X + dx) * rx - 50), (int) ((v2.Y + dy) * ry - 80), (int) ((v3.Y + dy) * ry - 80), bmpxy, pbPXY);
                        Bresenham((int) ((v3.X + dx) * rx - 50), (int) ((v1.X + dx) * rx - 50), (int) ((v3.Y + dy) * ry - 80), (int) ((v1.Y + dy) * ry - 80), bmpxy, pbPXY);
                    }
                }
                else
                {
                    Bresenham((int)((v1.X + dx) * rx - 50), (int)((v2.X + dx) * rx - 50), (int)((v1.Y + dy) * ry - 80), (int)((v2.Y + dy) * ry - 80), bmpxy, pbPXY);
                    Bresenham((int)((v2.X + dx) * rx - 50), (int)((v3.X + dx) * rx - 50), (int)((v2.Y + dy) * ry - 80), (int)((v3.Y + dy) * ry - 80), bmpxy, pbPXY);
                    Bresenham((int)((v3.X + dx) * rx - 50), (int)((v1.X + dx) * rx - 50), (int)((v3.Y + dy) * ry - 80), (int)((v1.Y + dy) * ry - 80), bmpxy, pbPXY);
                }

            });
            pbPXY.Refresh();
        }

        private void desenha_yz()
        {
            pbPYZ.Image = null;
            
            bmpyz.Dispose();
            bmpyz = new DirectBitmap(pbPYZ.Width, pbPYZ.Height);

            pbPYZ.Image = bmpyz.Bitmap;

            double rx = pbPYZ.Width / pictureBox1.Width + 0.5;
            double ry = pbPYZ.Height / pictureBox1.Height + 0.5;

            //Console.WriteLine(rx);

            Parallel.For(0, objeto.Faces.Count, i =>
            {
                Face f = objeto.Faces[i];
                Vertice v1 = objeto.Vertices.ElementAt(f.getPosVertice(0) - 1);
                Vertice v2 = objeto.Vertices.ElementAt(f.getPosVertice(1) - 1);
                Vertice v3 = objeto.Vertices.ElementAt(f.getPosVertice(2) - 1);

                if (cbBackCull.CheckState == CheckState.Checked)
                {
                    if (f.getVisivelX(objeto.Vertices))
                    {
                        Bresenham((int)((v1.Z + dx) * rx - 50), (int)((v2.Z + dx) * rx - 50), (int)((v1.Y + dy) * ry - 80), (int)((v2.Y + dy) * ry - 80), bmpyz, pbPYZ);
                        Bresenham((int)((v2.Z + dx) * rx - 50), (int)((v3.Z + dx) * rx - 50), (int)((v2.Y + dy) * ry - 80), (int)((v3.Y + dy) * ry - 80), bmpyz, pbPYZ);
                        Bresenham((int)((v3.Z + dx) * rx - 50), (int)((v1.Z + dx) * rx - 50), (int)((v3.Y + dy) * ry - 80), (int)((v1.Y + dy) * ry - 80), bmpyz, pbPYZ);
                    }
                }
                else
                {
                    Bresenham((int)((v1.Z + dx) * rx - 50), (int)((v2.Z + dx) * rx - 50), (int)((v1.Y + dy) * ry - 80), (int)((v2.Y + dy) * ry - 80), bmpyz, pbPYZ);
                    Bresenham((int)((v2.Z + dx) * rx - 50), (int)((v3.Z + dx) * rx - 50), (int)((v2.Y + dy) * ry - 80), (int)((v3.Y + dy) * ry - 80), bmpyz, pbPYZ);
                    Bresenham((int)((v3.Z + dx) * rx - 50), (int)((v1.Z + dx) * rx - 50), (int)((v3.Y + dy) * ry - 80), (int)((v1.Y + dy) * ry - 80), bmpyz, pbPYZ);
                }

            });
            pbPYZ.Refresh();
        }

        private void desenha_xz()
        {
            pbPXZ.Image = null;

            bmpxz.Dispose();
            bmpxz = new DirectBitmap(pbPXZ.Width, pbPXZ.Height);

            pbPXZ.Image = bmpxz.Bitmap;

            double rx = pbPXZ.Width / pictureBox1.Width + 0.5;
            double ry = pbPXZ.Height / pictureBox1.Height + 0.5;

            //Console.WriteLine(rx);

            Parallel.For(0, objeto.Faces.Count, i =>
            {
                Face f = objeto.Faces[i];
                Vertice v1 = objeto.Vertices.ElementAt(f.getPosVertice(0) - 1);
                Vertice v2 = objeto.Vertices.ElementAt(f.getPosVertice(1) - 1);
                Vertice v3 = objeto.Vertices.ElementAt(f.getPosVertice(2) - 1);

                if (cbBackCull.CheckState == CheckState.Checked)
                {
                    if (f.getVisivelY(objeto.Vertices))
                    {
                        Bresenham((int)((v1.X + dx) * rx - 50), (int)((v2.X + dx) * rx - 50), (int)((v1.Z + dy) * ry - 80), (int)((v2.Z + dy) * ry - 80), bmpxz, pbPXZ);
                        Bresenham((int)((v2.X + dx) * rx - 50), (int)((v3.X + dx) * rx - 50), (int)((v2.Z + dy) * ry - 80), (int)((v3.Z + dy) * ry - 80), bmpxz, pbPXZ);
                        Bresenham((int)((v3.X + dx) * rx - 50), (int)((v1.X + dx) * rx - 50), (int)((v3.Z + dy) * ry - 80), (int)((v1.Z + dy) * ry - 80), bmpxz, pbPXZ);
                    }
                }
                else
                {
                    Bresenham((int)((v1.X + dx) * rx - 50), (int)((v2.X + dx) * rx - 50), (int)((v1.Z + dy) * ry - 80), (int)((v2.Z + dy) * ry - 80), bmpxz, pbPXZ);
                    Bresenham((int)((v2.X + dx) * rx - 50), (int)((v3.X + dx) * rx - 50), (int)((v2.Z + dy) * ry - 80), (int)((v3.Z + dy) * ry - 80), bmpxz, pbPXZ);
                    Bresenham((int)((v3.X + dx) * rx - 50), (int)((v1.X + dx) * rx - 50), (int)((v3.Z + dy) * ry - 80), (int)((v1.Z + dy) * ry - 80), bmpxz, pbPXZ);
                }

            });
            pbPXZ.Refresh();
        }

        private void desenha_cavaleira()
        {
            pbPXY.Image = null;

            bmpxy.Dispose();
            bmpxy = new DirectBitmap(pbPXY.Width, pbPXY.Height);

            pbPXY.Image = bmpxy.Bitmap;

            double x1, x2, x3, y1, y2, y3;

            //Parallel.For(0, objeto.Faces.Count, i =>
            for (int i = 0; i < objeto.Faces.Count; i++)
            {
                Face f = objeto.Faces[i];
                Vertice v1 = objeto.Vertices.ElementAt(f.getPosVertice(0) - 1);
                Vertice v2 = objeto.Vertices.ElementAt(f.getPosVertice(1) - 1);
                Vertice v3 = objeto.Vertices.ElementAt(f.getPosVertice(2) - 1);

                x1 = Math.Round(v1.X + v1.Z * (Math.Cos(45)));
                y1 = Math.Round(v1.Y + v1.Z * (Math.Sin(45)));
                x2 = Math.Round(v2.X + v2.Z * (Math.Cos(45)));
                y2 = Math.Round(v2.Y + v2.Z * (Math.Sin(45)));
                x3 = Math.Round(v3.X + v3.Z * (Math.Cos(45)));
                y3 = Math.Round(v3.Y + v3.Z * (Math.Sin(45)));

                if (cbBackCull.CheckState == CheckState.Checked)
                {
                    if (f.getVisivel(objeto.Vertices))
                    {
                        Bresenham((int)x1 + 207, (int)x2 + 207, (int)y1 + 100, (int)y2 + 100, bmpxy, pbPXY);
                        Bresenham((int)x2 + 207, (int)x3 + 207, (int)y2 + 100, (int)y3 + 100, bmpxy, pbPXY);
                        Bresenham((int)x3 + 207, (int)x1 + 207, (int)y3 + 100, (int)y1 + 100, bmpxy, pbPXY);
                    }
                }
                else
                {
                    Bresenham((int)x1 + 207, (int)x2 + 207, (int)y1 + 100, (int)y2 + 100, bmpxy, pbPXY);
                    Bresenham((int)x2 + 207, (int)x3 + 207, (int)y2 + 100, (int)y3 + 100, bmpxy, pbPXY);
                    Bresenham((int)x3 + 207, (int)x1 + 207, (int)y3 + 100, (int)y1 + 100, bmpxy, pbPXY);
                }

            }//);

            pbPXY.Refresh();
        }

        private void desenha_cabintet()
        {
            pbPYZ.Image = null;

            bmpyz.Dispose();
            bmpyz = new DirectBitmap(pbPYZ.Width, pbPYZ.Height);

            pbPYZ.Image = bmpyz.Bitmap;

            double x1, x2, x3, y1, y2, y3;

            //Parallel.For(0, objeto.Faces.Count, i =>
            for (int i = 0; i < objeto.Faces.Count; i++)
            {
                Face f = objeto.Faces[i];
                Vertice v1 = objeto.Vertices.ElementAt(f.getPosVertice(0) - 1);
                Vertice v2 = objeto.Vertices.ElementAt(f.getPosVertice(1) - 1);
                Vertice v3 = objeto.Vertices.ElementAt(f.getPosVertice(2) - 1);

                x1 = Math.Round(v1.X + v1.Z * 0.5 * (Math.Cos(45)));
                y1 = Math.Round(v1.Y + v1.Z * 0.5 * (Math.Sin(45)));
                x2 = Math.Round(v2.X + v2.Z * 0.5 * (Math.Cos(45)));
                y2 = Math.Round(v2.Y + v2.Z * 0.5 * (Math.Sin(45)));
                x3 = Math.Round(v3.X + v3.Z * 0.5 * (Math.Cos(45)));
                y3 = Math.Round(v3.Y + v3.Z * 0.5 * (Math.Sin(45)));

                if (cbBackCull.CheckState == CheckState.Checked)
                {
                    if (f.getVisivel(objeto.Vertices))
                    {
                        Bresenham((int)x1 + 207, (int)x2 + 207, (int)y1 + 100, (int)y2 + 100, bmpyz, pbPYZ);
                        Bresenham((int)x2 + 207, (int)x3 + 207, (int)y2 + 100, (int)y3 + 100, bmpyz, pbPYZ);
                        Bresenham((int)x3 + 207, (int)x1 + 207, (int)y3 + 100, (int)y1 + 100, bmpyz, pbPYZ);
                    }
                }
                else
                {
                    Bresenham((int)x1 + 207, (int)x2 + 207, (int)y1 + 100, (int)y2 + 100, bmpyz, pbPYZ);
                    Bresenham((int)x2 + 207, (int)x3 + 207, (int)y2 + 100, (int)y3 + 100, bmpyz, pbPYZ);
                    Bresenham((int)x3 + 207, (int)x1 + 207, (int)y3 + 100, (int)y1 + 100, bmpyz, pbPYZ);
                }

            }//);

            pbPYZ.Refresh();
        }

        private void desenha_1pf()
        {
            pbPXZ.Image = null;

            bmpxz.Dispose();
            bmpxz = new DirectBitmap(pbPXZ.Width, pbPXZ.Height);

            pbPXZ.Image = bmpxz.Bitmap;

            int d = 20;
            double x1, x2, x3, y1, y2, y3;


            for (int i = 0; i < objeto.Faces.Count; i++)
            {
                Face f = objeto.Faces[i];
                Vertice v1 = objeto.Vertices.ElementAt(f.getPosVertice(0) - 1);
                Vertice v2 = objeto.Vertices.ElementAt(f.getPosVertice(1) - 1);
                Vertice v3 = objeto.Vertices.ElementAt(f.getPosVertice(2) - 1);

                double rx = pbPXY.Width / pictureBox1.Width + 0.5;
                double ry = pbPXY.Height / pictureBox1.Height + 0.5;

                x1 = v1.X * d / v1.Z * rx + 80;
                y1 = v1.Y * d / (v1.Z + d) * ry + 50;
                x2 = v2.X * d / (v2.Z + d) * rx + 80;
                y2 = v2.Y * d / (v2.Z + d) * ry + 50;
                x3 = v3.X * d / (v3.Z + d) * rx + 80;
                y3 = v3.Y * d / (v3.Z + d) * ry + 50;

                /*if (cbBackCull.CheckState == CheckState.Checked)
                {
                    if (f.getVisivel(objeto.Vertices))
                    {
                        Bresenham((int)x1, (int)x2, (int)y1, (int)y2, bmpxz, pbPXZ);
                        Bresenham((int)x2, (int)x3, (int)y2, (int)y3, bmpxz, pbPXZ);
                        Bresenham((int)x3, (int)x1, (int)y3, (int)y1, bmpxz, pbPXZ);
                    }
                }
                else
                {
                    Bresenham((int)x1, (int)x2, (int)y1, (int)y2, bmpxz, pbPXZ);
                    Bresenham((int)x2, (int)x3, (int)y2, (int)y3, bmpxz, pbPXZ);
                    Bresenham((int)x3, (int)x1, (int)y3, (int)y1, bmpxz, pbPXZ);
                }
                Console.WriteLine("NA");*/
            }
            //pbPXZ.Refresh();
        }

        private bool isOnPictureBox(int x, int y, PictureBox pb)
        {
            return x >= 0 && x < pb.Width && y >= 0 && y < pb.Height;
        }

        private void apagaPictureBox()
        {
            pictureBox1.Image = null;

            bmp.Dispose();
            bmp = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
            
            pictureBox1.Image = bmp.Bitmap;
        }

        public void Bresenham(int x1, int x2, int y1, int y2, DirectBitmap bmp, PictureBox pb) /// FUNCIONA
        {
            int dx, dy, incE, incNE, declive, d, x, y;

            dx = (int)(x2 - x1);
            dy = (int)(y2 - y1);
            declive = 1;

            if (Math.Abs(dx) > Math.Abs(dy)) // FOR EM RELAÇÃO A X
            {
                if (x1 > x2)
                {
                    // INVERTE OS PONTOS E REFAZ AS PERGUNTAS
                    Bresenham(x2, x1, y2, y1, bmp, pb);
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
                        if (isOnPictureBox(x, y, pb))
                            bmp.SetPixel(x, y, cor_obj);

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
                    Bresenham(x2, x1, y2, y1, bmp, pb);
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
                        if (isOnPictureBox(x, y, pb))
                            bmp.SetPixel(x, y, cor_obj);
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

        //private void scanLine(Face f, List<Vertice> vertices)
        //{
        //    ET[] et;
        //    ET aet = null;
        //    ET aux;

        //    et = geraET(f, vertices);

        //    int i = 0;

        //    if (et != null)
        //    {
        //        for (; i < et.Length && et[i] != null; i++) ;

        //        aet = et[i];
        //    }

        //    while (aet != null)
        //    {
        //        //aet = removeYMax(aet, i);

        //        if (aet != null)
        //        {
        //            //aet = ordenaAET(aet);

        //            //printScanLine(aet, i);

        //            //aet = atualizaXMin(aet, i);
        //            i++;

        //            /*if(i < et.Length)
        //                concatena(aet, et[i]);*/
        //        }
        //    }
        //}

        //private ET[] geraET(Face f, List<Vertice> vertices)
        //{
        //    Vertice a, b, c;
        //    ET[] et = null;
        //    ET nova;

        //    double xmin, ymax, incx, ymin;

        //    a = vertices.ElementAt(f.getPosVertice(0) - 1);
        //    b = vertices.ElementAt(f.getPosVertice(1) - 1);
        //    c = vertices.ElementAt(f.getPosVertice(2) - 1);

        //    a.X = a.X + dx; a.Y = a.Y + dy;
        //    b.X = b.X + dx; b.Y = b.Y + dy;
        //    c.X = c.X + dx; c.Y = c.Y + dy;


        //    int tam = getMaiorY(a.Y, b.Y, c.Y);

        //    if (tam > pictureBox1.Height)
        //        tam = pictureBox1.he

        //    if (tam > 0)
        //    {
        //        et = new ET[tam];

        //        if (a.Y <= b.Y)
        //        {
        //            ymin = a.Y;
        //            ymax = b.Y;
        //            xmin = a.X;

        //            if (ymax - ymin == 0)
        //                incx = 0;
        //            else
        //                incx = (b.X - xmin) / (ymax - ymin);
        //        }
        //        else
        //        {
        //            ymin = b.Y;
        //            ymax = a.Y;
        //            xmin = b.X;

        //            if (ymax - ymin == 0)
        //                incx = 0;
        //            else
        //                incx = (a.X - xmin) / (ymax - ymin);
        //        }

        //        nova = new ET(xmin, ymax, incx);
        //        et = insereFila(et, (int)ymin, nova);

        //        if (a.Y <= c.Y)
        //        {
        //            ymin = a.Y;
        //            ymax = c.Y;
        //            xmin = a.X;

        //            if (ymax - ymin == 0)
        //                incx = 0;
        //            else
        //                incx = (c.X - xmin) / (ymax - ymin);
        //        }
        //        else
        //        {
        //            ymin = c.Y;
        //            ymax = a.Y;
        //            xmin = c.X;

        //            if (ymax - ymin == 0)
        //                incx = 0;
        //            else
        //                incx = (a.X - xmin) / (ymax - ymin);
        //        }

        //        nova = new ET(xmin, ymax, incx);
        //        et = insereFila(et, (int)ymin, nova);

        //        if (b.Y <= c.Y)
        //        {
        //            ymin = b.Y;
        //            ymax = c.Y;
        //            xmin = b.X;

        //            if (ymax - ymin == 0)
        //                incx = 0;
        //            else
        //                incx = (c.X - xmin) / (ymax - ymin);
        //        }
        //        else
        //        {
        //            ymin = c.Y;
        //            ymax = b.Y;
        //            xmin = c.X;

        //            if (ymax - ymin == 0)
        //                incx = 0;
        //            else
        //                incx = (b.X - xmin) / (ymax - ymin);
        //        }

        //        nova = new ET(xmin, ymax, incx);
        //        et = insereFila(et, (int)ymin, nova);
        //    }
        //    return et;
        //}

        //private int getMaiorY(double y1, double y2, double y3)
        //{
        //    int maior = int.MinValue;

        //    if (y1 > maior)
        //        maior = (int)y1;

        //    if (y2 > maior)
        //        maior = (int)y2;

        //    if (y3 > maior)
        //        maior = (int)y3;

        //    return maior;
        //}

        //private ET[] insereFila(ET[] et, int pos, ET nova)
        //{
        //    ET aux, ant;
        //    double max;

        //    ant = null;

        //    if (pos > 0)
        //    {
        //        if (et[pos] == null)
        //            et[pos] = nova;
        //        else
        //        {
        //            aux = et[pos];

        //            while (aux != null && nova.Ymax >= aux.Ymax)
        //            {
        //                ant = aux;
        //                aux = aux.Proxima;
        //            }

        //            if (aux == null)
        //                ant.Proxima = nova;
        //            else
        //            {
        //                if (ant == null)
        //                {
        //                    nova.Proxima = aux;
        //                    et[pos] = nova;
        //                }
        //                else
        //                {
        //                    ant.Proxima = nova;
        //                    nova.Proxima = aux;
        //                    et[pos] = ant;
        //                }
        //            }
        //        }
        //    }
        //    return et;
        //}
    }
}
