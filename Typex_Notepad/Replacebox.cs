using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace Typex_Notepad
{
	public class Replacebox : Form
	{
		private Form1 form1obj;

		public string dir = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "\\Typex Notepad");

		public bool findbutclicked = false;

		public string findtextold = null;

		public string SearchText;

		public string pathfnd = null;

		public string pathdark = null;

		private IContainer components = null;

		private Label findwhat;

		private Label replacewith;

		private TextBox findwhattext;

		private TextBox replacetext;

		public Button findnextbut;

		public Button replacebut;

		public Button replaceallbut;

		private Button cancelbut;

		private CheckBox controlMatchCaseCheckbox;

		private CheckBox controlWraparoundCheckbox;

		public Replacebox(Form1 form1obj)
		{
			InitializeComponent();
			this.form1obj = form1obj;
			pathfnd = string.Concat(dir, "\\\\fndtxt.txt");
			pathdark = string.Concat(dir, "\\\\darkmdlog.txt");
			if (File.Exists(pathfnd))
			{
				findtextold = File.ReadAllText(pathfnd);
				findwhattext.Text = findtextold;
			}
            Hide();
            
		}

		private void Cancelbut_Click(object sender, EventArgs e)
		{
            Close();
		}

		private void cancelbut_keydown(object sender, KeyEventArgs e)
		{
            Close();
		}

		protected override void Dispose(bool disposing)
		{
			if ((!disposing ? false : components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void Findnextbut_Click(object sender, EventArgs e)
		{
			SearchText = findwhattext.Text;
			bool MatchCase = controlMatchCaseCheckbox.Checked;
			if (form1obj.FindNext(SearchText, MatchCase, false))
			{
				UpdateFindNextButton();
				File.WriteAllText(pathfnd, findwhattext.Text);
			}
			else if (MessageBox.Show("Cannot find the specified word", "Error", MessageBoxButtons.OK) == DialogResult.OK)
			{
                Close();
			}
			findbutclicked = true;
		}

		private void findnxt_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				findnextbut.PerformClick();
			}
		}

		private void findwhat_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				findnextbut.PerformClick();
			}
		}

		private void Findwhattext_TextChanged(object sender, EventArgs e)
		{
			SearchText = findwhattext.Text;
		}

		public static List<int> GetIndexes(string pText, string pSearchText, bool pCaseSensitive)
		{
			List<int> Indexes = new List<int>();
			StringComparison eStringComparison = (pCaseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase);
			int StartIndex = 0;
			while (true)
			{
				int Index = pText.IndexOf(pSearchText, StartIndex, eStringComparison);
				if (Index == -1)
				{
					break;
				}
				Indexes.Add(Index);
				StartIndex = Index + pSearchText.Length;
			}
			return Indexes;
		}
        private void darkchange()
        {
           Color bgcolor= ColorTranslator.FromHtml("#2D2D30");
            Color fcolor = Color.White;
            this.BackColor = bgcolor;
            findwhattext.BackColor =replacetext.BackColor=findnextbut.BackColor=replacebut.BackColor=replaceallbut.BackColor=cancelbut.BackColor= Color.Black;
            controlWraparoundCheckbox.ForeColor=controlMatchCaseCheckbox.ForeColor=replacewith.ForeColor=findwhat.ForeColor=findwhattext.ForeColor = replacetext.ForeColor = findnextbut.ForeColor = replacebut.ForeColor = replaceallbut.ForeColor = cancelbut.ForeColor = fcolor;
        }
        private void normalmode()
        {
            Color bgcolor = SystemColors.Control;
            Color fcolor = SystemColors.ControlText;
            this.BackColor = bgcolor;
            findwhattext.BackColor = replacetext.BackColor = SystemColors.Window;
            findnextbut.BackColor = replacebut.BackColor = replaceallbut.BackColor = cancelbut.BackColor = SystemColors.Control;
            controlWraparoundCheckbox.ForeColor = controlMatchCaseCheckbox.ForeColor = replacewith.ForeColor = findwhat.ForeColor = findwhattext.ForeColor = replacetext.ForeColor = findnextbut.ForeColor = replacebut.ForeColor = replaceallbut.ForeColor = cancelbut.ForeColor = fcolor;
        }
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Replacebox));
            this.findwhat = new System.Windows.Forms.Label();
            this.replacewith = new System.Windows.Forms.Label();
            this.findwhattext = new System.Windows.Forms.TextBox();
            this.replacetext = new System.Windows.Forms.TextBox();
            this.findnextbut = new System.Windows.Forms.Button();
            this.replacebut = new System.Windows.Forms.Button();
            this.replaceallbut = new System.Windows.Forms.Button();
            this.cancelbut = new System.Windows.Forms.Button();
            this.controlMatchCaseCheckbox = new System.Windows.Forms.CheckBox();
            this.controlWraparoundCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // findwhat
            // 
            this.findwhat.AutoSize = true;
            this.findwhat.Location = new System.Drawing.Point(12, 22);
            this.findwhat.Name = "findwhat";
            this.findwhat.Size = new System.Drawing.Size(59, 13);
            this.findwhat.TabIndex = 0;
            this.findwhat.Text = "Find what :";
            // 
            // replacewith
            // 
            this.replacewith.AutoSize = true;
            this.replacewith.Location = new System.Drawing.Point(12, 52);
            this.replacewith.Name = "replacewith";
            this.replacewith.Size = new System.Drawing.Size(75, 13);
            this.replacewith.TabIndex = 1;
            this.replacewith.Text = "Replace with :";
            // 
            // findwhattext
            // 
            this.findwhattext.Location = new System.Drawing.Point(93, 19);
            this.findwhattext.Name = "findwhattext";
            this.findwhattext.Size = new System.Drawing.Size(178, 20);
            this.findwhattext.TabIndex = 2;
            this.findwhattext.TextChanged += new System.EventHandler(this.Findwhattext_TextChanged);
            this.findwhattext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.findwhat_keydown);
            // 
            // replacetext
            // 
            this.replacetext.Location = new System.Drawing.Point(93, 49);
            this.replacetext.Name = "replacetext";
            this.replacetext.Size = new System.Drawing.Size(178, 20);
            this.replacetext.TabIndex = 3;
            this.replacetext.KeyDown += new System.Windows.Forms.KeyEventHandler(this.replacewith_keydown);
            // 
            // findnextbut
            // 
            this.findnextbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.findnextbut.Location = new System.Drawing.Point(277, 15);
            this.findnextbut.Name = "findnextbut";
            this.findnextbut.Size = new System.Drawing.Size(75, 23);
            this.findnextbut.TabIndex = 4;
            this.findnextbut.Text = "Find Next";
            this.findnextbut.UseVisualStyleBackColor = true;
            this.findnextbut.Click += new System.EventHandler(this.Findnextbut_Click);
            this.findnextbut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.findnxt_keydown);
            // 
            // replacebut
            // 
            this.replacebut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replacebut.Location = new System.Drawing.Point(277, 41);
            this.replacebut.Name = "replacebut";
            this.replacebut.Size = new System.Drawing.Size(75, 23);
            this.replacebut.TabIndex = 5;
            this.replacebut.Text = "Replace";
            this.replacebut.UseVisualStyleBackColor = true;
            this.replacebut.Click += new System.EventHandler(this.Replacebut_Click);
            this.replacebut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.replacebut_keydown);
            // 
            // replaceallbut
            // 
            this.replaceallbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replaceallbut.Location = new System.Drawing.Point(277, 67);
            this.replaceallbut.Name = "replaceallbut";
            this.replaceallbut.Size = new System.Drawing.Size(75, 23);
            this.replaceallbut.TabIndex = 6;
            this.replaceallbut.Text = "Replace All";
            this.replaceallbut.UseVisualStyleBackColor = true;
            this.replaceallbut.Click += new System.EventHandler(this.Replaceallbut_Click);
            this.replaceallbut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.replaceall_keydown);
            // 
            // cancelbut
            // 
            this.cancelbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbut.Location = new System.Drawing.Point(277, 93);
            this.cancelbut.Name = "cancelbut";
            this.cancelbut.Size = new System.Drawing.Size(75, 23);
            this.cancelbut.TabIndex = 7;
            this.cancelbut.Text = "Cancel";
            this.cancelbut.UseVisualStyleBackColor = true;
            this.cancelbut.Click += new System.EventHandler(this.Cancelbut_Click);
            this.cancelbut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cancelbut_keydown);
            // 
            // controlMatchCaseCheckbox
            // 
            this.controlMatchCaseCheckbox.AutoSize = true;
            this.controlMatchCaseCheckbox.Location = new System.Drawing.Point(4, 128);
            this.controlMatchCaseCheckbox.Name = "controlMatchCaseCheckbox";
            this.controlMatchCaseCheckbox.Size = new System.Drawing.Size(83, 17);
            this.controlMatchCaseCheckbox.TabIndex = 8;
            this.controlMatchCaseCheckbox.Text = "Match Case";
            this.controlMatchCaseCheckbox.UseVisualStyleBackColor = true;
            // 
            // controlWraparoundCheckbox
            // 
            this.controlWraparoundCheckbox.AutoSize = true;
            this.controlWraparoundCheckbox.Location = new System.Drawing.Point(4, 151);
            this.controlWraparoundCheckbox.Name = "controlWraparoundCheckbox";
            this.controlWraparoundCheckbox.Size = new System.Drawing.Size(88, 17);
            this.controlWraparoundCheckbox.TabIndex = 9;
            this.controlWraparoundCheckbox.Text = "Wrap around";
            this.controlWraparoundCheckbox.UseVisualStyleBackColor = true;
            // 
            // Replacebox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 172);
            this.Controls.Add(this.controlWraparoundCheckbox);
            this.Controls.Add(this.controlMatchCaseCheckbox);
            this.Controls.Add(this.cancelbut);
            this.Controls.Add(this.replaceallbut);
            this.Controls.Add(this.replacebut);
            this.Controls.Add(this.findnextbut);
            this.Controls.Add(this.replacetext);
            this.Controls.Add(this.findwhattext);
            this.Controls.Add(this.replacewith);
            this.Controls.Add(this.findwhat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Replacebox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Replacebox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void replaceall_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				replaceallbut.PerformClick();
			}
		}

		private void Replaceallbut_Click(object sender, EventArgs e)
		{
			
			
			if (!findbutclicked)
			{
				findnextbut.PerformClick();
			}
			string Content = form1obj.TextBox1.Text;
			SearchText = findwhattext.Text;
			bool MatchCase = controlMatchCaseCheckbox.Checked;
			List<int> Indexes = GetIndexes(Content, SearchText, MatchCase);
			StringBuilder Builder = new StringBuilder();
			string ReplaceWith = replacetext.Text;
			int LastIndex = -1;
            int TakeStart;
			foreach (int Index in Indexes)
			{
				if (Index != 0)
				{
					TakeStart = (LastIndex != -1 ? LastIndex + SearchText.Length : 0);
					int selLength = Index - 1 - TakeStart + 1;
					Builder.Append(Content.Substring(TakeStart, selLength));
				}
				Builder.Append(ReplaceWith);
				LastIndex = Index;
			}
			TakeStart = (LastIndex != -1 ? LastIndex + SearchText.Length : 0);
			int TakeEnd = Content.Length - 1;
			int Length = TakeEnd - TakeStart + 1;
			Builder.Append(Content.Substring(TakeStart, Length));
			form1obj.TextBox1.Text = Builder.ToString();
			findbutclicked = false;
            Close();
		}

		private void Replacebut_Click(object sender, EventArgs e)
		{
			if (!findbutclicked)
			{
				findnextbut.PerformClick();
			}
			SearchText = findwhattext.Text;
			string ReplaceWithText = replacetext.Text;
			bool MatchCase = controlMatchCaseCheckbox.Checked;
			bool bSearchDown = true;
			if (form1obj.TextBox1.SelectedText.Equals(SearchText))
			{
				form1obj.TextBox1.SelectedText = ReplaceWithText;
                Close();
			}
			if (!form1obj.FindNext(SearchText, MatchCase, bSearchDown))
			{
				if (MessageBox.Show("Cannot find the specified word", "Error", MessageBoxButtons.OK) == DialogResult.OK)
				{
                    Close();
				}
			}
			findbutclicked = false;
		}

		private void replacebut_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				replacebut.PerformClick();
			}
		}

		private void replacewith_keydown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				replacebut.PerformClick();
			}
		}

		private void UpdateFindNextButton()
		{
			findnextbut.Enabled = form1obj.TextBox1.Text.Length > 0;
		}

        private void Replacebox_Load(object sender, EventArgs e)
        {
            if (form1obj.darkyes() == true)
                darkchange();
            else
                normalmode();
        }
    }
}