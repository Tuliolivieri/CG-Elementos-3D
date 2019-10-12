using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            if(opf.ShowDialog() == DialogResult.OK)
            {
                lbTitle.Text = opf.FileName;
            }
        }
    }
}
