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
        public Form1()
        {
            InitializeComponent();
        }

        private void BtAbrir_Click(object sender, EventArgs e)
        {
            if (opf.ShowDialog() == DialogResult.OK)
            {
                lbTitle.Text = opf.FileName;

                StreamReader sr = new StreamReader(opf.FileName);

                carregaObjeto(sr);
            }
        }

        private void carregaObjeto(StreamReader sr)
        {
            String linha = sr.ReadLine();
            while(linha != null)
            {
                Console.WriteLine(linha);

                linha = sr.ReadLine();
            }
        }
    }
}
