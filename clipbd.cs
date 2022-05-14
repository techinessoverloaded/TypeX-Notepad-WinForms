using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Typex_Notepad
{
    public partial class clipbd : Form
    {
        private string pathclipbd = null;
        private string dir1 = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "\\Typex Notepad");
        private string content = null;
        private Form1 form1obj;
        public clipbd(Form1 form1obj)
        {
            InitializeComponent();
            this.form1obj = form1obj;
           
            pathclipbd = string.Concat(dir1, "\\cliplog.txt");
            listBox1.Text = String.Empty;
            content = File.ReadAllText(pathclipbd);
            if (content!=String.Empty)
            {
                string[] lines = content.Split('\n');
                foreach (string ln in lines)
                {
                    listBox1.Items.Add(ln.Trim());
                }
            }
            timer1.Enabled = true;
         
            addfromclipboard();
           
        }
        public class ClipboardChangedEventArgs : EventArgs
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (object row in listBox1.SelectedItems)
                {
                    sb.Append(row.ToString());
                    sb.AppendLine();
                }
                sb.Remove(sb.Length - 1, 1); 
                Clipboard.SetData(DataFormats.Text, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Closebut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clipbd_Load(object sender, EventArgs e)
        {
            if (form1obj.darkyes() == true)
                darkchange();
            else
                normalchange();
        }
        private void darkchange()
        {
            Color bgcolor1=ColorTranslator.FromHtml("#1E1E1E");
            Color fcolor = Color.White;
            clearbut.BackColor = selectallbut.BackColor = closebut.BackColor = copybut.BackColor = bgcolor1;
            this.BackColor= ColorTranslator.FromHtml("#2D2D30");
            listBox1.BackColor = bgcolor1;
            listBox1.ForeColor=clearbut.ForeColor = selectallbut.ForeColor = closebut.ForeColor = copybut.ForeColor = fcolor;

        }
        private void normalchange()
        {
            Color bgcolor1 = SystemColors.Control;
            Color fcolor = SystemColors.ControlText;
            clearbut.BackColor = selectallbut.BackColor = closebut.BackColor = copybut.BackColor = bgcolor1;
            this.BackColor = SystemColors.Control;
            listBox1.BackColor = SystemColors.Window;
            listBox1.ForeColor = clearbut.ForeColor = selectallbut.ForeColor = closebut.ForeColor = copybut.ForeColor = fcolor;

        }
        private void Selectallbut_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.SelectedItems.Clear();
                listBox1.BeginUpdate();
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SetSelected(i, true);
                }
                listBox1.EndUpdate();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clearbut_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        public void addfromclipboard()
        {
            if (Clipboard.ContainsText() == true)
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                foreach (string ln in lines)
                {
                    listBox1.Items.Add(ln.Trim());
                }
            }
        }

        private void clipbd_close(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            pathclipbd =dir1+"//cliplog.txt";
          
                StreamWriter SaveFile = new StreamWriter(pathclipbd);
                foreach (var item in listBox1.Items)
                {
                    SaveFile.WriteLine(item);
                }

                SaveFile.Close();
            
           



        }

        private void timer1_tick(object sender, EventArgs e)
        {
            if (form1obj.iscopyret() == true || form1obj.iscutret() == true)
                addfromclipboard();
            form1obj.setcopycutfalse();
        }

       
    }
}
