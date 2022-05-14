using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.QrCode;
using System.IO;
using ZXing.Common;
using ZXing;
using AForge.Video.DirectShow;
using AForge.Video;



namespace Typex_Notepad
{
    public partial class memoform : Form
    {
        public Color bgcolor = Color.FromArgb(19, 131, 255);
        public Color defbg = Color.FromArgb(255, 255, 128);
        public Color fcolor = Color.White;
        public Color deftextcol = Color.Black;
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice finalframe;
        private Random rnd = new Random();
        private int id = 1;
        private TextBox focusedTextbox = null;
        private Color focusedTbcolor;
        private string dir = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "\\Typex Notepad\\Memo");
        private DirectoryInfo di;
        string pathmemo = null;
        Form1 form1obj;
        public memoform(Form1 form1obj)
        {
            InitializeComponent();
            this.form1obj = form1obj;
            mainpanel.WrapContents = true;
            mainpanel.FlowDirection = FlowDirection.TopDown;
            
           
        }
        private void finalframe_newframe(object sender, NewFrameEventArgs e)
        {
            pictureBox1.Image = (Image)e.Frame.Clone();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CreateMemo();
        }

        private void memo1_click(object sender, EventArgs e)
        {


        }

        private void memo1_hover(object sender, EventArgs e)
        {

        }

        private void memo1_mouseleave(object sender, EventArgs e)
        {

        }
        private void CreateMemo()

        {
            
            System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
            KnownColor[] allColors = new KnownColor[colorsArray.Length];

            Array.Copy(colorsArray, allColors, colorsArray.Length);
        labelrandom:
            Color randomColor;
            if (id == 1)
            { randomColor = Color.FromArgb(255, 255, 128);
                
            }
            else
                randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
           
                if (randomColor.Equals(Color.Black))
                {
                    goto labelrandom;
                }
               
            
            
            TextBox memo = new TextBox();
            

            memo.Height = 175;

            memo.Width = 175;

            memo.BackColor = randomColor;

            memo.ForeColor = Color.Black;
            memo.ContextMenuStrip = contextMenuStrip1;
            memo.Text = "Type Something";
            memo.Font = new Font("Calibri", 14);
            memo.Multiline = true;
            memo.MaxLength = 4296;
            if(id%2==0)
                mainpanel.SetFlowBreak(memo, true);
            memo.Enter += TextBox_Enter;
            memo.Leave += TextBox_Leave;
            memo.TextChanged += TextBox_TextChanged;
            mainpanel.Controls.Add(memo);
            if (id == 1)
                focusedTextbox = memo;
            memo.Name = "memo" + id;
            var newfile = File.Create(dir + "\\memo" + id + ".txt");
            newfile.Close();
            id++;

        }
        private void LoadMemo(string fname,int uid)
        {
            System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
            KnownColor[] allColors = new KnownColor[colorsArray.Length];

            Array.Copy(colorsArray, allColors, colorsArray.Length);
        labelrandom:
                Color randomColor;
                randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            if (randomColor.Equals(Color.Black))
            {
                goto labelrandom;
            }



            TextBox memo = new TextBox();


            memo.Height = 175;
            
            memo.Width = 175;

            memo.BackColor = randomColor;

            memo.ForeColor = Color.Black;
            memo.ContextMenuStrip = contextMenuStrip1;
            memo.Text = File.ReadAllText(fname);
            memo.Font = new Font("Calibri", 14);
            memo.Multiline = true;
            memo.MaxLength = 4296;
            if (uid % 2 == 0)
                mainpanel.SetFlowBreak(memo, true);
            memo.Enter += TextBox_Enter;
            memo.Leave += TextBox_Leave;
            memo.TextChanged += TextBox_TextChanged;
            mainpanel.Controls.Add(memo);
            if (uid == 1)
                focusedTextbox = memo;
            memo.Name = "memo" + uid;

        }
        private void Exitbut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Genqr_Click(object sender, EventArgs e)
        {

            BarcodeWriter newgen = new BarcodeWriter();
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 250,
                Height = 250,
            };
            if (!String.IsNullOrWhiteSpace(focusedTextbox.Text) || !String.IsNullOrEmpty(focusedTextbox.Text))
            {
                newgen.Format = BarcodeFormat.QR_CODE;
                newgen.Options = options;
                var res = new Bitmap(newgen.Write(focusedTextbox.Text.Trim()));
                genqrlabel.Visible = true;
                webcamlabel.Visible = false;
                bothlabel.Visible = false;
                pictureBox1.Image = res;
            }
            else
            {
                pictureBox1.Image = null;
                MessageBox.Show("Memo is Empty", " Typex Notepad", MessageBoxButtons.OK);
                bothlabel.Visible = true;
                genqrlabel.Hide();
                webcamlabel.Hide();
            }


        }

        private void Scanqr_Click(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            BarcodeReader Reader = new BarcodeReader { AutoRotate = true, TryInverted = true };
            Result result = Reader.Decode((Bitmap)pictureBox1.Image);
            try
            {
                string decoded = result.ToString().Trim();
                if (decoded != "")
                {
                    timer1.Stop();
                    focusedTextbox.Text = decoded;
                    MessageBox.Show("QR Code Decoded", "Typex Notepad", MessageBoxButtons.OK);

                }
            }
            catch (Exception)
            {

            }




        }

        private void Webcamclosebut_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            finalframe.Stop();
        }

        private void Openwebcambut_Click(object sender, EventArgs e)
        {
            if (Openwebcambut.Text.Equals("Open Webcam"))
            {
                finalframe = new VideoCaptureDevice(CaptureDevice[0].MonikerString);
                finalframe.NewFrame += new NewFrameEventHandler(finalframe_newframe);
                finalframe.Start();
                genqrlabel.Visible = false;
                bothlabel.Visible = false;
                webcamlabel.Visible = true;
                Openwebcambut.Text = "Close Webcam";
            }
            else
            {
                timer1.Stop();
                finalframe.Stop();
                pictureBox1.Image = null;
                bothlabel.Text = "Webcam/QR Code";
                bothlabel.Visible = true;
                Openwebcambut.Text = "Open Webcam";
            }
        }
      
        private void Memoform_Load(object sender, EventArgs e)
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            finalframe = new VideoCaptureDevice();
            int i = 1;
            int flag = 0;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Enter += TextBox_Enter;
                tb.Leave += TextBox_Leave;
                tb.TextChanged += TextBox_TextChanged;
                tb.ContextMenuStrip = contextMenuStrip1;
            }

            
                
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                di = new DirectoryInfo(dir);
                DirectoryInfo attributes = di;
                attributes.Attributes = attributes.Attributes | FileAttributes.Normal;
            
                DirectoryInfo getdir = new DirectoryInfo(dir);
                FileInfo[] filenames = getdir.GetFiles("*.txt");
                foreach (FileInfo file in filenames)
                {

                    if (file.Name.StartsWith("memo"))
                    {
                       
                        LoadMemo(file.FullName, i);
                        i++;
                        flag = 1;
                    }



                }
                id = i;
            if (flag == 0)
            { CreateMemo(); }
            if (form1obj.darkyes() == true)
                darkchange();
            else
                normalchange();

        }
        private void darkchange()
        {
            Color bgcolor= ColorTranslator.FromHtml("#2D2D30");
            Color fcolor = Color.White;
            this.BackColor=mainpanel.BackColor=backpanel.BackColor=qrpanel.BackColor=pictureBox1.BackColor = ColorTranslator.FromHtml("#1E1E1E");
            foreach (Button b in this.Controls.OfType<Button>())
            {
                b.BackColor = bgcolor;
                b.ForeColor = fcolor;
            }
            bothlabel.ForeColor = webcamlabel.ForeColor = genqrlabel.ForeColor = fcolor;
            contextMenuStrip1.Renderer = new Renderer();
            contextMenuStrip1.BackColor = bgcolor;
            contextMenuStrip1.ForeColor = fcolor;
        }
        private class Renderer : ToolStripProfessionalRenderer
        {
            public Renderer() : base(new Cols())
            {
            }
        }
        public class Cols : ProfessionalColorTable
        {
            public override Color ImageMarginGradientBegin
            {
                get
                {
                    return ColorTranslator.FromHtml("#2D2D30");
                }
            }

            public override Color ImageMarginGradientEnd
            {
                get
                {
                    return ColorTranslator.FromHtml("#2D2D30");
                }
            }

            public override Color ImageMarginGradientMiddle
            {
                get
                {
                    return ColorTranslator.FromHtml("#2D2D30");
                }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return Color.Black;
                }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get
                {
                    return Color.Black;
                }
            }

            public override Color MenuItemPressedGradientMiddle
            {
                get
                {
                    return Color.Black;
                }
            }

            public override Color MenuItemSelected
            {
                get
                {
                    return ColorTranslator.FromHtml("#191919");
                }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return Color.Black;
                }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return Color.Black;
                }
            }

            public Cols()
            {
            }
        }
        public class Statusren : ProfessionalColorTable
        {

            public override Color ToolStripBorder
            {
                get
                {
                    return ColorTranslator.FromHtml("#2D2D30");
                }
            }

            public Statusren()
            {
            }
        }
        private class staRenderer : ToolStripProfessionalRenderer
        {
            public staRenderer() : base(new Statusren())
            {
            }
        }
        private void normalchange()
        {

        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            focusedTextbox = (TextBox)sender;
            focusedTbcolor = focusedTextbox.BackColor;
            focusedTextbox.BackColor = ColorTranslator.FromHtml("#1383FF");
            focusedTextbox.ForeColor = Color.White;

        }
        private void TextBox_Leave(object sender,EventArgs e)
        {
            focusedTextbox.BackColor = focusedTbcolor;
            focusedTextbox.ForeColor = Color.Black;
        }

        private void TextBox_TextChanged(object sender,EventArgs e)
        {
            pathmemo = dir +"\\"+ focusedTextbox.Name + ".txt";
            
            File.WriteAllText(pathmemo, focusedTextbox.Text);
            if (focusedTextbox.Text.Split('\n').Length > 7)
                    focusedTextbox.ScrollBars = ScrollBars.Vertical;
            else
                    focusedTextbox.ScrollBars = ScrollBars.None;
        }
        private void Memoform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (finalframe.IsRunning == true)
            {
                finalframe.Stop();
                timer1.Stop();
            }
            int i = 1;
        loop1:
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (tb.Name.Equals("memo" + i))
                {
                    pathmemo = dir + "\\" + tb.Name + ".txt";
                    File.WriteAllText(pathmemo, tb.Text);

                }
            }
            i++;
            if (i <= id)
                goto loop1;
            di = new DirectoryInfo(dir);
            DirectoryInfo attributes = di;
            attributes.Attributes = attributes.Attributes | FileAttributes.Hidden;
        }

       

        private void Closewebcambut_Click(object sender, EventArgs e)
        {
            finalframe.Stop();
            timer1.Stop();
            pictureBox1.Image = null;
            Openwebcambut.Text = "Close Webcam";

        }

      

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (finalframe.IsRunning)
                finalframe.Stop();
            Openwebcambut.Text = "Open Webcam";
            openFileDialog1.Filter= "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog1.Title = "Typex Memo - Open QR Code Image";
            openFileDialog1.FileName = "";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                genqrlabel.Hide();
                bothlabel.Text = "QR Code";
                bothlabel.Show();
                webcamlabel.Hide();
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void Saveallbut_Click(object sender, EventArgs e)
        {
                int i = 1;
            loop1:
                    foreach (TextBox tb in Controls.OfType<TextBox>())
                    {
                        if (tb.Name.Equals("memo" + i))
                        {
                            pathmemo = dir + "\\" + tb.Name + ".txt";
                            File.WriteAllText(pathmemo, tb.Text);
                            
                        }
                    }
            i++;
            if (i <= id)
                goto loop1;
            MessageBox.Show("All memos saved successfully!", "Typex Memo", MessageBoxButtons.OK);
            
           
        }

        private void Delbut_Click(object sender, EventArgs e)
        {
            if (File.Exists(dir +"\\"+focusedTextbox.Name + ".txt"))
                File.Delete(dir +"\\"+focusedTextbox.Name + ".txt");
            mainpanel.Controls.Remove(focusedTextbox);
            
        }

        private void datebut_Click(object sender, EventArgs e)
        {
            string dat = null;
            dat = DateTime.Now.ToString("dd/MM/yyyy h:mm tt");
            focusedTextbox.Paste(" "+dat);
            focusedTextbox.Focus();
        }

        private void Addtotextbut_Click(object sender, EventArgs e)
        {
            form1obj.TextBox1.Paste(" " + focusedTextbox.Text);
            MessageBox.Show("Memo Text added successfully to Text File in Typex Notepad !", "Typex Memo", MessageBoxButtons.OK);
        }

        private void mainpanel_dragenter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                // loop through the string array, validating each filename
                bool allow = true;
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) != ".txt")
                    {
                        allow = false;
                        break;
                    }
                }
                e.Effect = (allow ? DragDropEffects.All : DragDropEffects.None);
                
            }
        }

        private void mainpanel_dragdrop(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.FileDrop,false);
            if (data != null)
            {
                string[] Filenames = data as string[];
                
                if (Filenames.Length != 0)
                {
                   LoadMemo(Filenames[0], id);
                    pathmemo = dir + "\\memo" + id + ".txt";
                    if (!File.Exists(pathmemo))
                    { var load = File.Create(pathmemo);
                        load.Close(); }
                    else
                    {
                        id++;
                        pathmemo = dir + "\\memo" + id + ".txt";
                        var load = File.Create(pathmemo);
                        load.Close();
                    }
                    id++;
                   
                }
            }
            else if (MessageBox.Show("Cannot load file as Memo", "Typex Memo", MessageBoxButtons.OK) == DialogResult.OK)
            {
                this.Focus();
            }
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datebut.PerformClick();
        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 1;
        loop1:
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                if (tb.Name.Equals("memo" + i))
                {
                    pathmemo = dir + "\\" + tb.Name + ".txt";
                    File.WriteAllText(pathmemo, tb.Text);

                }
            }
            i++;
            if (i <= id)
                goto loop1;
            MessageBox.Show("Memo saved successfully!", "Typex Memo", MessageBoxButtons.OK);
        }

        private void deleteMemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delbut.PerformClick();
        }

        private void generateQRCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            genqr.PerformClick();
        }
    }
}
