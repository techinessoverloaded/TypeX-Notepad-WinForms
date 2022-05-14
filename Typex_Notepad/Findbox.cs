using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;

namespace Typex_Notepad
{
	public class Findbox : Form
	{
		private Form1 form1obj;

		public string dir = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "\\Typex Notepad");

		public string resdark = null;

		public bool res;

		public string findtextold = null;

		public string pathfnd = null;

		public string pathdark = null;

		private IContainer components = null;

		private TextBox findtext;

		private Button closefind;

		private Button findnext;

		private Label label1;

		private CheckBox controlMatchCaseCheckbox;

		private CheckBox controlWraparoundCheckbox;

		private RadioButton controlUpRadioButton;

		private RadioButton controlDownRadioButton;

		private GroupBox groupBox1;

		public Findbox(Form1 form1obj)
		{
			InitializeComponent();
			this.form1obj = form1obj;
            Hide();
			pathfnd = string.Concat(dir, "\\\\fndtxt.txt");
			pathdark = string.Concat(dir, "\\\\darkmdlog.txt");
			if ((!File.Exists(pathdark) ? false : File.Exists(pathfnd)))
			{
				resdark = File.ReadAllText(pathdark);
				findtextold = File.ReadAllText(pathfnd);
			}
			findtext.Text = findtextold;
			if (resdark != "true")
			{
				BackColor = SystemColors.Control;
				ForeColor = SystemColors.ControlText;
				label1.ForeColor = SystemColors.ControlText;
				controlDownRadioButton.ForeColor = SystemColors.ControlText;
				controlUpRadioButton.ForeColor = SystemColors.ControlText;
				groupBox1.ForeColor = SystemColors.ControlText;
				controlMatchCaseCheckbox.ForeColor = SystemColors.ControlText;
				controlWraparoundCheckbox.ForeColor = SystemColors.ControlText;
				findtext.BackColor = SystemColors.Window;
				findtext.ForeColor = SystemColors.WindowText;
				findnext.BackColor = SystemColors.Control;
				findnext.ForeColor = SystemColors.ControlText;
				closefind.BackColor = SystemColors.Control;
				closefind.ForeColor = SystemColors.ControlText;
			}
			else
			{
				BackColor = ColorTranslator.FromHtml("#1E1E1E");
				ForeColor = Color.White;
				label1.ForeColor = Color.White;
				controlDownRadioButton.ForeColor = Color.White;
				controlUpRadioButton.ForeColor = Color.White;
				groupBox1.ForeColor = Color.White;
				controlMatchCaseCheckbox.ForeColor = Color.White;
				controlWraparoundCheckbox.ForeColor = Color.White;
				findtext.BackColor = ColorTranslator.FromHtml("#2D2D30");
				findtext.ForeColor = Color.White;
				findnext.BackColor = ColorTranslator.FromHtml("#2D2D30");
				findnext.ForeColor = Color.White;
				closefind.BackColor = ColorTranslator.FromHtml("#2D2D30");
				closefind.ForeColor = Color.White;
			}
		}

		private void cancelbut_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				closefind.PerformClick();
			}
		}

		private void Closefind_Click(object sender, EventArgs e)
		{
            Close();
		}

		private void ControlDownRadioButton_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ControlUpRadioButton_CheckedChanged(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void downbutton_click(object sender, EventArgs e)
		{
		}

		private void findbox_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (findnext.Focused)
				{
					findnext.PerformClick();
				}
				else if (closefind.Focused)
				{
					closefind.PerformClick();
				}
			}
		}

		private void Findnext_Click(object sender, EventArgs e)
		{
			bool bSearchDown = controlDownRadioButton.Checked;
			bool MatchCase = controlMatchCaseCheckbox.Checked;
			if (form1obj.TextBox1.SelectionLength > 0)
			{
				findtext.Text = form1obj.TextBox1.SelectedText;
			}
			res = form1obj.FindNext(findtext.Text, MatchCase, bSearchDown);
			if (res)
			{
				UpdateFindNextButton();
                Close();
				File.WriteAllText(pathfnd, findtext.Text);
			}
			else if (MessageBox.Show("Cannot find the specified word", "Error", MessageBoxButtons.OK) == DialogResult.OK)
			{
                Close();
			}
		}

		private void findnxt_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				findnext.PerformClick();
			}
		}

		private void Findtext_TextChanged(object sender, EventArgs e)
		{
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Findbox));
            this.findtext = new System.Windows.Forms.TextBox();
            this.closefind = new System.Windows.Forms.Button();
            this.findnext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.controlMatchCaseCheckbox = new System.Windows.Forms.CheckBox();
            this.controlWraparoundCheckbox = new System.Windows.Forms.CheckBox();
            this.controlUpRadioButton = new System.Windows.Forms.RadioButton();
            this.controlDownRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // findtext
            // 
            this.findtext.Location = new System.Drawing.Point(70, 21);
            this.findtext.Name = "findtext";
            this.findtext.Size = new System.Drawing.Size(165, 20);
            this.findtext.TabIndex = 0;
            this.findtext.TextChanged += new System.EventHandler(this.Findtext_TextChanged);
            this.findtext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox1_keydown);
            // 
            // closefind
            // 
            this.closefind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closefind.Location = new System.Drawing.Point(242, 46);
            this.closefind.Name = "closefind";
            this.closefind.Size = new System.Drawing.Size(75, 23);
            this.closefind.TabIndex = 2;
            this.closefind.Text = "Cancel";
            this.closefind.UseVisualStyleBackColor = true;
            this.closefind.Click += new System.EventHandler(this.Closefind_Click);
            this.closefind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cancelbut_keydown);
            // 
            // findnext
            // 
            this.findnext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findnext.Location = new System.Drawing.Point(242, 20);
            this.findnext.Name = "findnext";
            this.findnext.Size = new System.Drawing.Size(75, 23);
            this.findnext.TabIndex = 3;
            this.findnext.Text = "Find Next";
            this.findnext.UseVisualStyleBackColor = true;
            this.findnext.Click += new System.EventHandler(this.Findnext_Click);
            this.findnext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.findnxt_keydown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Find what :";
            // 
            // controlMatchCaseCheckbox
            // 
            this.controlMatchCaseCheckbox.AutoSize = true;
            this.controlMatchCaseCheckbox.Location = new System.Drawing.Point(9, 76);
            this.controlMatchCaseCheckbox.Name = "controlMatchCaseCheckbox";
            this.controlMatchCaseCheckbox.Size = new System.Drawing.Size(83, 17);
            this.controlMatchCaseCheckbox.TabIndex = 5;
            this.controlMatchCaseCheckbox.Text = "Match Case";
            this.controlMatchCaseCheckbox.UseVisualStyleBackColor = true;
            // 
            // controlWraparoundCheckbox
            // 
            this.controlWraparoundCheckbox.AutoSize = true;
            this.controlWraparoundCheckbox.Location = new System.Drawing.Point(9, 99);
            this.controlWraparoundCheckbox.Name = "controlWraparoundCheckbox";
            this.controlWraparoundCheckbox.Size = new System.Drawing.Size(88, 17);
            this.controlWraparoundCheckbox.TabIndex = 6;
            this.controlWraparoundCheckbox.Text = "Wrap around";
            this.controlWraparoundCheckbox.UseVisualStyleBackColor = true;
            // 
            // controlUpRadioButton
            // 
            this.controlUpRadioButton.AutoSize = true;
            this.controlUpRadioButton.Checked = true;
            this.controlUpRadioButton.Location = new System.Drawing.Point(4, 19);
            this.controlUpRadioButton.Name = "controlUpRadioButton";
            this.controlUpRadioButton.Size = new System.Drawing.Size(39, 17);
            this.controlUpRadioButton.TabIndex = 7;
            this.controlUpRadioButton.TabStop = true;
            this.controlUpRadioButton.Text = "Up";
            this.controlUpRadioButton.UseVisualStyleBackColor = true;
            this.controlUpRadioButton.CheckedChanged += new System.EventHandler(this.ControlUpRadioButton_CheckedChanged);
            this.controlUpRadioButton.Click += new System.EventHandler(this.upbutton_click);
            // 
            // controlDownRadioButton
            // 
            this.controlDownRadioButton.AutoSize = true;
            this.controlDownRadioButton.Location = new System.Drawing.Point(49, 19);
            this.controlDownRadioButton.Name = "controlDownRadioButton";
            this.controlDownRadioButton.Size = new System.Drawing.Size(53, 17);
            this.controlDownRadioButton.TabIndex = 8;
            this.controlDownRadioButton.Text = "Down";
            this.controlDownRadioButton.UseVisualStyleBackColor = true;
            this.controlDownRadioButton.CheckedChanged += new System.EventHandler(this.ControlDownRadioButton_CheckedChanged);
            this.controlDownRadioButton.Click += new System.EventHandler(this.downbutton_click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.controlDownRadioButton);
            this.groupBox1.Controls.Add(this.controlUpRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(117, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(108, 44);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // Findbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 144);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.controlWraparoundCheckbox);
            this.Controls.Add(this.controlMatchCaseCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findnext);
            this.Controls.Add(this.closefind);
            this.Controls.Add(this.findtext);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Findbox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.findbox_keydown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void textbox1_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				findnext.PerformClick();
			}
		}

		private void upbutton_click(object sender, EventArgs e)
		{
		}

		private void UpdateFindNextButton()
		{
			findnext.Enabled = form1obj.TextBox1.Text.Length > 0;
		}
	}
}