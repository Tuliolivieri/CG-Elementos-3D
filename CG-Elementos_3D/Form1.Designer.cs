﻿namespace CG_Elementos_3D
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox.SuspendLayout();
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
            this.btAbrir.Size = new System.Drawing.Size(119, 39);
            this.btAbrir.TabIndex = 0;
            this.btAbrir.Text = "Abrir Arquivo";
            this.btAbrir.UseVisualStyleBackColor = false;
            this.btAbrir.Click += new System.EventHandler(this.BtAbrir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(988, 691);
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
            this.lbTitle.Location = new System.Drawing.Point(10, 752);
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
            this.groupBox.Location = new System.Drawing.Point(139, 13);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(200, 39);
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1306, 778);
            this.Controls.Add(this.groupBox);
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
    }
}

