
namespace _59_vlastnIHra
{
    partial class cakeRun
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btN = new System.Windows.Forms.Button();
            this.btD = new System.Windows.Forms.Button();
            this.btS = new System.Windows.Forms.Button();
            this.btA = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reset = new System.Windows.Forms.Button();
            this.mousetimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Location = new System.Drawing.Point(22, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 800);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btN
            // 
            this.btN.BackColor = System.Drawing.Color.RosyBrown;
            this.btN.Location = new System.Drawing.Point(990, 488);
            this.btN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btN.Name = "btN";
            this.btN.Size = new System.Drawing.Size(81, 76);
            this.btN.TabIndex = 1;
            this.btN.Text = "W";
            this.btN.UseVisualStyleBackColor = false;
            this.btN.Click += new System.EventHandler(this.btN_Click);
            // 
            // btD
            // 
            this.btD.BackColor = System.Drawing.Color.RosyBrown;
            this.btD.Location = new System.Drawing.Point(1076, 564);
            this.btD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btD.Name = "btD";
            this.btD.Size = new System.Drawing.Size(81, 76);
            this.btD.TabIndex = 2;
            this.btD.Text = "D";
            this.btD.UseVisualStyleBackColor = false;
            this.btD.Click += new System.EventHandler(this.btD_Click);
            // 
            // btS
            // 
            this.btS.BackColor = System.Drawing.Color.RosyBrown;
            this.btS.Location = new System.Drawing.Point(990, 644);
            this.btS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btS.Name = "btS";
            this.btS.Size = new System.Drawing.Size(81, 76);
            this.btS.TabIndex = 3;
            this.btS.Text = "S";
            this.btS.UseVisualStyleBackColor = false;
            this.btS.Click += new System.EventHandler(this.btS_Click);
            // 
            // btA
            // 
            this.btA.BackColor = System.Drawing.Color.RosyBrown;
            this.btA.Location = new System.Drawing.Point(903, 564);
            this.btA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btA.Name = "btA";
            this.btA.Size = new System.Drawing.Size(81, 76);
            this.btA.TabIndex = 4;
            this.btA.Text = "A";
            this.btA.UseVisualStyleBackColor = false;
            this.btA.Click += new System.EventHandler(this.btA_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.RosyBrown;
            this.panel2.Location = new System.Drawing.Point(840, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 400);
            this.panel2.TabIndex = 5;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // reset
            // 
            this.reset.BackColor = System.Drawing.Color.RosyBrown;
            this.reset.Font = new System.Drawing.Font("Stencil", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.reset.ForeColor = System.Drawing.SystemColors.Desktop;
            this.reset.Location = new System.Drawing.Point(840, 488);
            this.reset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(400, 263);
            this.reset.TabIndex = 6;
            this.reset.Text = "reset?";
            this.reset.UseCompatibleTextRendering = true;
            this.reset.UseVisualStyleBackColor = false;
            this.reset.Visible = false;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // mousetimer
            // 
            this.mousetimer.Enabled = true;
            this.mousetimer.Interval = 150;
            this.mousetimer.Tick += new System.EventHandler(this.mousetimer_Tick);
            // 
            // cakeRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1249, 831);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btA);
            this.Controls.Add(this.btS);
            this.Controls.Add(this.btD);
            this.Controls.Add(this.btN);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "cakeRun";
            this.Text = "Cake Run";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btN;
        private System.Windows.Forms.Button btD;
        private System.Windows.Forms.Button btS;
        private System.Windows.Forms.Button btA;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Timer mousetimer;
    }
}

