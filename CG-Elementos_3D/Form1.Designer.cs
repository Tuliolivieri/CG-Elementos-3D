namespace CG_Elementos_3D
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btAbrir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.opf = new System.Windows.Forms.OpenFileDialog();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbEscala = new System.Windows.Forms.Label();
            this.lbTranslacao = new System.Windows.Forms.Label();
            this.lbRotacao = new System.Windows.Forms.Label();
            this.lbTX = new System.Windows.Forms.Label();
            this.lbTY = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.cbBackCull = new System.Windows.Forms.CheckBox();
            this.pbPXY = new System.Windows.Forms.PictureBox();
            this.pbPYZ = new System.Windows.Forms.PictureBox();
            this.pbPXZ = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cdCorFundo = new System.Windows.Forms.ColorDialog();
            this.cdCorObj = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btCorFundo = new System.Windows.Forms.Button();
            this.btCorObj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPXY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPYZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPXZ)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btAbrir
            // 
            this.btAbrir.BackColor = System.Drawing.Color.Blue;
            this.btAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btAbrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAbrir.ForeColor = System.Drawing.Color.White;
            this.btAbrir.Location = new System.Drawing.Point(13, 13);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(291, 39);
            this.btAbrir.TabIndex = 0;
            this.btAbrir.Text = "Abrir Arquivo";
            this.btAbrir.UseVisualStyleBackColor = false;
            this.btAbrir.Click += new System.EventHandler(this.BtAbrir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(310, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(988, 699);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // opf
            // 
            this.opf.FileName = "openFileDialog1";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.White;
            this.lbTitle.Location = new System.Drawing.Point(310, 761);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(169, 17);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "Nenhum arquivo aberto,,,";
            // 
            // lbEscala
            // 
            this.lbEscala.AutoSize = true;
            this.lbEscala.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEscala.ForeColor = System.Drawing.Color.White;
            this.lbEscala.Location = new System.Drawing.Point(386, 13);
            this.lbEscala.Name = "lbEscala";
            this.lbEscala.Size = new System.Drawing.Size(61, 20);
            this.lbEscala.TabIndex = 3;
            this.lbEscala.Text = "Escala:";
            // 
            // lbTranslacao
            // 
            this.lbTranslacao.AutoSize = true;
            this.lbTranslacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTranslacao.ForeColor = System.Drawing.Color.White;
            this.lbTranslacao.Location = new System.Drawing.Point(546, 13);
            this.lbTranslacao.Name = "lbTranslacao";
            this.lbTranslacao.Size = new System.Drawing.Size(87, 20);
            this.lbTranslacao.TabIndex = 4;
            this.lbTranslacao.Text = "Translação";
            // 
            // lbRotacao
            // 
            this.lbRotacao.AutoSize = true;
            this.lbRotacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRotacao.ForeColor = System.Drawing.Color.White;
            this.lbRotacao.Location = new System.Drawing.Point(742, 13);
            this.lbRotacao.Name = "lbRotacao";
            this.lbRotacao.Size = new System.Drawing.Size(74, 20);
            this.lbRotacao.TabIndex = 5;
            this.lbRotacao.Text = "Rotação:";
            // 
            // lbTX
            // 
            this.lbTX.AutoSize = true;
            this.lbTX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTX.ForeColor = System.Drawing.Color.White;
            this.lbTX.Location = new System.Drawing.Point(639, 13);
            this.lbTX.Name = "lbTX";
            this.lbTX.Size = new System.Drawing.Size(24, 20);
            this.lbTX.TabIndex = 6;
            this.lbTX.Text = "X:";
            // 
            // lbTY
            // 
            this.lbTY.AutoSize = true;
            this.lbTY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTY.ForeColor = System.Drawing.Color.White;
            this.lbTY.Location = new System.Drawing.Point(639, 32);
            this.lbTY.Name = "lbTY";
            this.lbTY.Size = new System.Drawing.Size(24, 20);
            this.lbTY.TabIndex = 7;
            this.lbTY.Text = "Y:";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.cbBackCull);
            this.groupBox.ForeColor = System.Drawing.Color.White;
            this.groupBox.Location = new System.Drawing.Point(3, 4);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(283, 39);
            this.groupBox.TabIndex = 8;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Funções";
            // 
            // cbBackCull
            // 
            this.cbBackCull.AutoSize = true;
            this.cbBackCull.Location = new System.Drawing.Point(7, 20);
            this.cbBackCull.Name = "cbBackCull";
            this.cbBackCull.Size = new System.Drawing.Size(106, 17);
            this.cbBackCull.TabIndex = 0;
            this.cbBackCull.Text = "Backface Culling";
            this.cbBackCull.UseVisualStyleBackColor = true;
            this.cbBackCull.CheckedChanged += new System.EventHandler(this.CbBackCull_CheckedChanged);
            // 
            // pbPXY
            // 
            this.pbPXY.AccessibleName = "";
            this.pbPXY.BackColor = System.Drawing.Color.Black;
            this.pbPXY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPXY.Location = new System.Drawing.Point(1307, 81);
            this.pbPXY.Name = "pbPXY";
            this.pbPXY.Size = new System.Drawing.Size(414, 200);
            this.pbPXY.TabIndex = 9;
            this.pbPXY.TabStop = false;
            // 
            // pbPYZ
            // 
            this.pbPYZ.AccessibleName = "";
            this.pbPYZ.BackColor = System.Drawing.Color.Black;
            this.pbPYZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPYZ.Location = new System.Drawing.Point(1307, 320);
            this.pbPYZ.Name = "pbPYZ";
            this.pbPYZ.Size = new System.Drawing.Size(414, 200);
            this.pbPYZ.TabIndex = 10;
            this.pbPYZ.TabStop = false;
            // 
            // pbPXZ
            // 
            this.pbPXZ.AccessibleName = "";
            this.pbPXZ.BackColor = System.Drawing.Color.Black;
            this.pbPXZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPXZ.Location = new System.Drawing.Point(1308, 557);
            this.pbPXZ.Name = "pbPXZ";
            this.pbPXZ.Size = new System.Drawing.Size(414, 200);
            this.pbPXZ.TabIndex = 11;
            this.pbPXZ.TabStop = false;
            // 
            // label1
            // 
            this.label1.AccessibleName = "pbPXY";
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1304, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Projeção X, Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1303, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Projeção Y, Z";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1303, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Projeção X, Y";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.groupBox);
            this.panel1.Location = new System.Drawing.Point(13, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 699);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btCorObj);
            this.panel2.Controls.Add(this.btCorFundo);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(3, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(283, 118);
            this.panel2.TabIndex = 9;
            this.panel2.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cor de fundo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(99, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cor do Objeto";
            // 
            // btCorFundo
            // 
            this.btCorFundo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCorFundo.Image = global::CG_Elementos_3D.Properties.Resources.cpick;
            this.btCorFundo.Location = new System.Drawing.Point(6, 16);
            this.btCorFundo.Name = "btCorFundo";
            this.btCorFundo.Size = new System.Drawing.Size(85, 85);
            this.btCorFundo.TabIndex = 2;
            this.btCorFundo.UseVisualStyleBackColor = true;
            this.btCorFundo.Click += new System.EventHandler(this.BtCorFundo_Click);
            // 
            // btCorObj
            // 
            this.btCorObj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCorObj.Image = global::CG_Elementos_3D.Properties.Resources.cpick;
            this.btCorObj.Location = new System.Drawing.Point(102, 16);
            this.btCorObj.Name = "btCorObj";
            this.btCorObj.Size = new System.Drawing.Size(85, 85);
            this.btCorObj.TabIndex = 3;
            this.btCorObj.UseVisualStyleBackColor = true;
            this.btCorObj.Click += new System.EventHandler(this.BtCorObj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1736, 787);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbPXZ);
            this.Controls.Add(this.pbPYZ);
            this.Controls.Add(this.pbPXY);
            this.Controls.Add(this.lbTY);
            this.Controls.Add(this.lbTX);
            this.Controls.Add(this.lbRotacao);
            this.Controls.Add(this.lbTranslacao);
            this.Controls.Add(this.lbEscala);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btAbrir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Elementos 3D";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPXY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPYZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPXZ)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAbrir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog opf;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbEscala;
        private System.Windows.Forms.Label lbTranslacao;
        private System.Windows.Forms.Label lbRotacao;
        private System.Windows.Forms.Label lbTX;
        private System.Windows.Forms.Label lbTY;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.CheckBox cbBackCull;
        private System.Windows.Forms.PictureBox pbPXY;
        private System.Windows.Forms.PictureBox pbPYZ;
        private System.Windows.Forms.PictureBox pbPXZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog cdCorFundo;
        private System.Windows.Forms.ColorDialog cdCorObj;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btCorObj;
        private System.Windows.Forms.Button btCorFundo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

