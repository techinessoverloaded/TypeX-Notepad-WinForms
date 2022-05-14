using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Typex_Notepad
{
    public partial class ocrdraw : Form
    {
        public ocrwindow newocrobj;
        public ocrdraw(ocrwindow newocrobj)
        {
            this.newocrobj = newocrobj;
            InitializeComponent();
            drawbut.Checked = true;
            g = panel1.CreateGraphics();
            bmp=new Bitmap(panel1.Width, panel1.Height);

        }
        public bool drw,erase;
        public int beginX, beginY,endX,endY;
        public Color fcolorglob=Color.Black;
        public Color bgcolorglob = Color.White;
        public float brush = 4;
        public string filepath = null;
        public Bitmap bmp;
        public Graphics g;
        private void ocrdraw_mousedown(object sender, MouseEventArgs e)
        {
            
        }

        private void ocrdraw_mousemove(object sender, MouseEventArgs e)
        {
            
        }

        private void ocrdraw_mouseup(object sender, MouseEventArgs e)
        {
            
        }

        private void Exitbut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_mouseup(object sender, MouseEventArgs e)
        {
            drw = false;
            erase = false;
        }

        private void panel1_mousedown(object sender, MouseEventArgs e)
        {
            if (drawbut.Checked == true)
                drw = true;
            else if (erasebut.Checked == true)
                erase = true;
            else
            {
                erase = false;
                drw = false;
            }
            beginX = e.X;
            beginY = e.Y;
        }

        private void panel1_mousemove(object sender, MouseEventArgs e)
        {

            if (e.Button==MouseButtons.Left)
            {
                endX = e.X;
                endY = e.Y;
            }

        }

        private void Drawbut_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void drawbut_click(object sender, EventArgs e)
        {
           
        }

        private void erasebut_checkchanged(object sender, EventArgs e)
        {
            
        }

        private void Newbut_Click(object sender, EventArgs e)
        {
            ocrdraw newocr = new ocrdraw(newocrobj);
            newocr.Show();
            this.Close();
        }

        private void Savebut_Click(object sender, EventArgs e)
        {
            
            if (filepath==null)
            {
                
                saveFileDialog1.Filter = "JPEG Image(*.jpg)|*.jpg|Bitmap Image(*.bmp)| *.bmp";
                saveFileDialog1.Title = "Save an image file";
                saveFileDialog1.FileName = "";
                System.Drawing.Imaging.ImageFormat imageFormat= System.Drawing.Imaging.ImageFormat.Jpeg; 
                if (saveFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    

                    switch (saveFileDialog1.FilterIndex)
                    {
                        case 1:
                            imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                            break;
                        case 2:
                            imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                            break;

                    }
                  
                    bmp.Save(saveFileDialog1.FileName,imageFormat);
                    filepath = saveFileDialog1.FileName;
                }
               
            }
            else
            {
                
                bmp.Save(filepath);
            }
        }

        private void Erasebut_Click(object sender, EventArgs e)
        {
            
        }

        private void Ocrdraw_Load(object sender, EventArgs e)
        {
            
            if (newocrobj.darkyesocr() == true)
                darkchange();
            else
                normalchange();
        }

        private void panel1_paint(object sender, PaintEventArgs e)
        {
            
        }

        private void darkchange()
        {
          this.BackColor=panel1.BackColor=ColorTranslator.FromHtml("#1E1E1E");
            Color bgcolor = ColorTranslator.FromHtml("#2D2D30");
            Color fcolor = Color.White;
            groupBox1.BackColor =ColorTranslator.FromHtml("#000000");
            groupBox1.ForeColor = fcolor;
            savebut.BackColor = newbut.BackColor = detbut.BackColor = exitbut.BackColor = bgcolor;
            savebut.ForeColor = newbut.ForeColor = detbut.ForeColor = exitbut.ForeColor = drawbut.ForeColor = erasebut.ForeColor = fcolor;
            fcolorglob = Color.White;
        }
        private void normalchange()
        {
            panel1.BackColor = bgcolorglob;

        }

    }
}
