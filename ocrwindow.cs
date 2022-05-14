using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;
using System.Threading;
using System.IO;

namespace Typex_Notepad
{
    
    public partial class ocrwindow : Form
    {
        Form1 form1obj;
        private bool validData;

        private String path = null;
        private Image image;
        private Thread getImageThread;
        public ocrwindow(Form1 form1obj)
        {
            InitializeComponent();
            this.form1obj = form1obj;
            pictureBox1.AllowDrop = true;
        }

        private void Browsebut_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.jpg; *.jpeg; *.bmp; *.png)|*.jpg; *.jpeg; *.bmp; *.png";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            }
        }

        private void Detectbut_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
                    var img = PixConverter.ToPix(new Bitmap(pictureBox1.Image));
                    var page = engine.Process(img);
                    
                    ocrtext.Text = page.GetText();
                   
                        
                   
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void Closebut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Copybut_Click(object sender, EventArgs e)
        {
            if (ocrtext.Text != String.Empty)
            {
                form1obj.TextBox1.Text=ocrtext.Text;
                MessageBox.Show("Text added successfully!", "Typex Notepad", MessageBoxButtons.OK);
                    
            
            }
        }

        private void picturebox_dragenter(object sender, DragEventArgs e)
        {
            string filename;
            validData = GetFilename(out filename, e);
            if (validData)
            {
                path = filename;
                
                getImageThread = new Thread(new ThreadStart(LoadImage));
                getImageThread.Start();
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void picturebox_dragdrop(object sender, DragEventArgs e)
        {
            if (validData)
            {
                while (getImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
                pictureBox1.Image = image;
            }
        }
        protected void LoadImage()

        {
            image = new Bitmap(path);
        }
        private bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".jpeg") || (ext == ".bmp")||(ext==".png"))
                        {
                            ret = true;
                        }
                    }
                }
            }
            return ret;
        }

        private void Appendbut_Click(object sender, EventArgs e)
        {
            if (ocrtext.Text != String.Empty)
            {
                form1obj.TextBox1.AppendText(ocrtext.Text);
                MessageBox.Show("Text appended successfully!", "Typex Notepad", MessageBoxButtons.OK);
            }
        }

        private void Drawbut_Click(object sender, EventArgs e)
        {
            ocrdraw newdraw = new ocrdraw(this);
            newdraw.Show();
        }

        private void Ocrwindow_Load(object sender, EventArgs e)
        {
            if (form1obj.darkyes() == true)
                darkchange();
            

        }
        private void darkchange()
        {
            Color bgcolor= ColorTranslator.FromHtml("#2D2D30");
            Color fcolor = Color.White;
            this.BackColor= ColorTranslator.FromHtml("#1E1E1E");
            pictureBox1.BackColor = ocrtext.BackColor = this.BackColor;
            ocrtext.ForeColor = closebut.ForeColor=openlabel.ForeColor = label1.ForeColor = browsebut.ForeColor = detectbut.ForeColor = addbut.ForeColor = appendbut.ForeColor = fcolor;
            closebut.BackColor= browsebut.BackColor = detectbut.BackColor = addbut.BackColor = appendbut.BackColor = bgcolor;
        }
     public bool darkyesocr()
        {
            if (form1obj.darkyes() == true)
                return true;
            else
                return false;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
