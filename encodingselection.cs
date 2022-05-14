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

namespace Typex_Notepad
{
    public partial class encodingselection : Form
    {
       
        private Form1 form1obj;
       
        public encodingselection(Form1 form1obj)
        {
            InitializeComponent();
            this.form1obj = form1obj;
            Dictionary<string,Encoding> comboSource = new Dictionary<string,Encoding>();
            comboSource.Add("ANSI", Encoding.ASCII);
            comboSource.Add("UTF-16 BE(Big endian)", Encoding.BigEndianUnicode);
            comboSource.Add("UTF-16 LE(Little endian)", Encoding.Unicode);
            comboSource.Add("UTF-8", Encoding.UTF8);
            controlEncodingComboBox.DataSource = new BindingSource(comboSource, null);
            controlEncodingComboBox.DisplayMember = "Key";
            controlEncodingComboBox.ValueMember = "Value";
           
        }
        public Encoding encodingopt
        {
            get { return (Encoding)controlEncodingComboBox.SelectedValue; }
            set { controlEncodingComboBox.SelectedValue = value; }
        }
        
        
        private void encodingselection_Load(object sender, EventArgs e)
        {
            if (form1obj.filepath!=null&&File.Exists(form1obj.filepath))
            {
                using (var streamReader = new StreamReader(form1obj.filepath, Encoding.ASCII, detectEncodingFromByteOrderMarks: true))
                {
                    var text = streamReader.ReadToEnd();
                    controlEncodingComboBox.SelectedValue = streamReader.CurrentEncoding;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void okbut_Click(object sender, EventArgs e)
        {
            form1obj._encoding = encodingopt = (Encoding)controlEncodingComboBox.SelectedValue;
            this.Close();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
            saveFileDialog1.Title = "Save a text file";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllText(saveFileDialog1.FileName, form1obj.TextBox1.Text, form1obj._encoding);
                form1obj.filepath = saveFileDialog1.FileName;
                form1obj.setTitle();
            }
        }

        private void cancelbut_Click(object sender, EventArgs e)
        {
            this.Close();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
            saveFileDialog1.Title = "Save a text file";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllText(saveFileDialog1.FileName, form1obj.TextBox1.Text, form1obj._encoding);
                form1obj.filepath = saveFileDialog1.FileName;
                form1obj.setTitle();
            }
        }

        private void enoding_formclosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void encoding_formclosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
