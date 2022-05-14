using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace Typex_Notepad
{
	public class about : Form
	{
		private IContainer components = null;
        private PictureBox pictureBox2;
        private Label aboutlabel;
        private Label label1;
        private Label label2;
        private Label yearlabel;
        private Label label3;
        private TextBox textBox1;
        private Label label4;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label7;
        private Button closebut;
        private Form1 form1obj;
        private Color defbutbg;
        private Color defbutfg;
        private bool mouseDown;
        private Point lastLocation;
        public about(Form1 form1obj)
		{
			InitializeComponent();
            this.form1obj = form1obj;
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(about));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.aboutlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.yearlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.closebut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-41, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(2, 313);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 119);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // aboutlabel
            // 
            this.aboutlabel.AutoSize = true;
            this.aboutlabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutlabel.Location = new System.Drawing.Point(280, 76);
            this.aboutlabel.Name = "aboutlabel";
            this.aboutlabel.Size = new System.Drawing.Size(239, 37);
            this.aboutlabel.TabIndex = 2;
            this.aboutlabel.Text = "TypeX Notepad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(230, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "©";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(279, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Techiness Overloaded";
            // 
            // yearlabel
            // 
            this.yearlabel.AutoSize = true;
            this.yearlabel.BackColor = System.Drawing.Color.Transparent;
            this.yearlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearlabel.Location = new System.Drawing.Point(634, 38);
            this.yearlabel.Name = "yearlabel";
            this.yearlabel.Size = new System.Drawing.Size(93, 39);
            this.yearlabel.TabIndex = 5;
            this.yearlabel.Text = "2019";
            this.yearlabel.Click += new System.EventHandler(this.Label3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "License Information :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(256, 144);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(500, 324);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(253, 498);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(359, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "The TypeX Notepad Logo has been created by Nitish Thananjayan";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(253, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Attribution :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 39);
            this.label7.TabIndex = 10;
            this.label7.Text = "About Us";
            // 
            // closebut
            // 
            this.closebut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebut.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebut.Location = new System.Drawing.Point(726, 1);
            this.closebut.Name = "closebut";
            this.closebut.Size = new System.Drawing.Size(55, 33);
            this.closebut.TabIndex = 11;
            this.closebut.Text = "✕";
            this.closebut.UseVisualStyleBackColor = true;
            this.closebut.Click += new System.EventHandler(this.closebut_Click);
            this.closebut.MouseEnter += new System.EventHandler(this.closebut_mouseenter);
            this.closebut.MouseLeave += new System.EventHandler(this.closebut_mouseleave);
            this.closebut.MouseHover += new System.EventHandler(this.closebut_MouseHover);
            // 
            // about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 522);
            this.ControlBox = false;
            this.Controls.Add(this.closebut);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.yearlabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.aboutlabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "about";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Us";
            this.Load += new System.EventHandler(this.About_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.form_mousedown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.form_mousemove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.form_mouseup);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            closebut.FlatAppearance.BorderSize = 0;
            defbutbg = SystemColors.Control;
            defbutfg = SystemColors.ControlText;
            yearlabel.Text = DateTime.Now.Year.ToString();
            if (form1obj.darkyes() == true)
                darkchange();
            textBox1.Select(0, 0);
        }
        private void darkchange()
        {
            defbutbg = ColorTranslator.FromHtml("#1E1E1E");
            defbutfg = Color.White;
            closebut.ForeColor = defbutfg;
            BackColor = defbutbg;
            label7.ForeColor=label1.ForeColor = label2.ForeColor = label3.ForeColor = label4.ForeColor = label5.ForeColor = aboutlabel.ForeColor = yearlabel.ForeColor = Color.White;
            textBox1.ForeColor = Color.White;
            textBox1.BackColor = Color.Black;
        }
        private void normalchange()
        {

        }
        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void closebut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closebut_mouseenter(object sender, EventArgs e)
        {
            closebut.BackColor = Color.Red;
            closebut.ForeColor = Color.White;
        }

        private void closebut_MouseHover(object sender, EventArgs e)
        {
            closebut.BackColor = Color.Red;
            closebut.ForeColor = Color.White;
        }

        private void closebut_mouseleave(object sender, EventArgs e)
        {
            closebut.BackColor = defbutbg;
            closebut.ForeColor = defbutfg;
        }

        private void form_mousedown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void form_mousemove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void form_mouseup(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}