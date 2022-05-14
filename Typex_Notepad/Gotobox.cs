using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Linq;
using System.IO;

namespace Typex_Notepad
{
	public class Gotobox : Form
	{
		public int LineNumber;

		private IContainer components = null;

		private Label label1;

		private TextBox linetext;

		private Button gotobut;

		private Button cancelbut;
        private string dir = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "\\Typex Notepad");
        

        public Gotobox(int pLineNumber)
		{
			InitializeComponent();
			LineNumber = pLineNumber;
			linetext.Text = LineNumber.ToString();
		}

		private void Cancelbut_Click(object sender, EventArgs e)
		{
            Close();
		}

		private void cancelbut_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				cancelbut.PerformClick();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void goto_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				gotobut.PerformClick();
			}
		}

		private void Gotobox_Load(object sender, EventArgs e)
		{
			linetext.SelectAll();
            if (File.ReadAllText(dir + "\\darkmdlog.txt") == "true")
                darkmode();
            else
                normalmode();
		}
        private void darkmode()
        {
            Color bgcolor= ColorTranslator.FromHtml("#2D2D30");
            Color fcolor = Color.White;
            this.BackColor= ColorTranslator.FromHtml("#1E1E1E");
            linetext.BackColor = gotobut.BackColor = cancelbut.BackColor = bgcolor;
            label1.ForeColor= linetext.ForeColor = gotobut.ForeColor = cancelbut.ForeColor = fcolor;
        }
        private void normalmode()
        {
            Color bgcolor = SystemColors.Control;
            Color fcolor = SystemColors.ControlText;
            this.BackColor = bgcolor;
            linetext.BackColor = SystemColors.Window;
            gotobut.BackColor = cancelbut.BackColor = bgcolor;
            label1.ForeColor = linetext.ForeColor = gotobut.ForeColor = cancelbut.ForeColor = fcolor;
        }
		private void Gotobut_Click(object sender, EventArgs e)
		{
			if (linetext.Text != string.Empty)
			{
				int PotentialLineNumber = int.Parse(linetext.Text);
				if (PotentialLineNumber != 0)
				{
					LineNumber = PotentialLineNumber;
                    DialogResult = DialogResult.OK;
                    Close();
				}
				else
				{
					MessageBox.Show(this, "Zero (0) is not a valid line number, line numbers start at 1 !", "Typex Notepad");
				}
			}
			else
			{
				MessageBox.Show(this, "You must enter a value !", "Typex Notepad");
			}
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gotobox));
            this.label1 = new System.Windows.Forms.Label();
            this.linetext = new System.Windows.Forms.TextBox();
            this.gotobut = new System.Windows.Forms.Button();
            this.cancelbut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Line number :";
            // 
            // linetext
            // 
            this.linetext.Location = new System.Drawing.Point(10, 35);
            this.linetext.Name = "linetext";
            this.linetext.Size = new System.Drawing.Size(222, 20);
            this.linetext.TabIndex = 10;
            this.linetext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.linetext_keydown);
            this.linetext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.linetext_keypress);
            // 
            // gotobut
            // 
            this.gotobut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gotobut.Location = new System.Drawing.Point(76, 61);
            this.gotobut.Name = "gotobut";
            this.gotobut.Size = new System.Drawing.Size(75, 23);
            this.gotobut.TabIndex = 11;
            this.gotobut.Text = "Go To";
            this.gotobut.UseVisualStyleBackColor = true;
            this.gotobut.Click += new System.EventHandler(this.Gotobut_Click);
            this.gotobut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.goto_keydown);
            // 
            // cancelbut
            // 
            this.cancelbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbut.Location = new System.Drawing.Point(157, 61);
            this.cancelbut.Name = "cancelbut";
            this.cancelbut.Size = new System.Drawing.Size(75, 23);
            this.cancelbut.TabIndex = 12;
            this.cancelbut.Text = "Cancel";
            this.cancelbut.UseVisualStyleBackColor = true;
            this.cancelbut.Click += new System.EventHandler(this.Cancelbut_Click);
            this.cancelbut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cancelbut_keydown);
            // 
            // Gotobox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 93);
            this.Controls.Add(this.cancelbut);
            this.Controls.Add(this.gotobut);
            this.Controls.Add(this.linetext);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Gotobox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Go To Line";
            this.Load += new System.EventHandler(this.Gotobox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void linetext_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				gotobut.PerformClick();
			}
		}

		private void linetext_keypress(object sender, KeyPressEventArgs e)
		{
		}
	}
}