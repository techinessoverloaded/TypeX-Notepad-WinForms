using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Typex_Notepad.Properties;


namespace Typex_Notepad
{
    public class Form1 :  Form
    {
        public DirectoryInfo di;

        public string dir = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "\\Typex Notepad");
       

        public string filepath=null;

        public string pathfnd = null;
        public string pathclip = null;

        private float i = 2f;

        private string fonttype = null;

        private string dat = null;

        private int origzoom = 0;

        private string textboxdef = "Drag and drop a file here or start typing";

        public static string EnteredKey;

        public static string EnteredString;

        public static bool Is_LessThanKeyPressed;

        public static bool Is_GreaterThanKeyPressed;

        public static bool Is_AutoCompleteCharacterPressed;

        public bool Is_SpaceBarKeyPressed = false;
        public bool Is_TKeyPressed = false;

        public bool Is_TagClosedKeyPressed = false;

        public static Color backcolor;

        public static Color forecolor;

        public static string CompleteBox_EnteredString;

        public string[] tagslist = new string[] { "html", "head", "title", "body", "h1", "h2", "h3", "h4", "h5", "h6", "b", "u", "i", "sub", "sup", "center", "strike", "font", "p", "style", "pre", "marquee", "ul", "ol", "a", "img", "table", "tr", "th", "td", "frameset", "iframe", "form", "button", "textarea", "select", "div", "fieldset", "span", "strong", "em", "big", "small","li" };

        public string[] keywordslist = new string[] { "input","li","html", "head", "title", "body", "h1", "h2", "h3", "h4", "h5", "h6", "b", "u", "i", "sub", "sup", "center", "strike", "font", "p", "style", "pre", "marquee", "ul", "ol", "a", "img", "table", "tr", "th", "td", "frameset", "iframe", "form", "button", "textarea", "select", "div", "fieldset", "span", "strong", "em", "big", "small" };

        public static bool isCodeCompleteBoxAdded;

        private IContainer components = null;

        private MenuStrip menuStrip1;
        private bool ishtmlsave=true;

        private ToolStripMenuItem fileToolStripMenuItem;
        private Point lastLocation;
        private bool mouseDown;
        private ToolStripMenuItem editToolStripMenuItem;

        private ToolStripMenuItem newToolStripMenuItem;

        private ToolStripMenuItem openToolStripMenuItem;

        private ToolStripMenuItem saveToolStripMenuItem;

        private ToolStripMenuItem saveAsToolStripMenuItem;

        private ToolStripMenuItem pageSetupToolStripMenuItem;

        private ToolStripMenuItem printToolStripMenuItem;

        private ToolStripMenuItem exitToolStripMenuItem;

        private ToolStripMenuItem undoToolStripMenuItem;

        private ToolStripMenuItem cutToolStripMenuItem;

        private ToolStripMenuItem copyToolStripMenuItem;

        private ToolStripMenuItem pasteToolStripMenuItem;

        private ToolStripMenuItem deleteToolStripMenuItem;

        private ToolStripMenuItem findToolStripMenuItem;

        private ToolStripMenuItem findNextToolStripMenuItem;

        private ToolStripMenuItem replaceToolStripMenuItem;

        private ToolStripMenuItem selectAllToolStripMenuItem;

        private ToolStripMenuItem timeDateToolStripMenuItem;

        private ToolStripMenuItem formatToolStripMenuItem;

        private ToolStripMenuItem fontToolStripMenuItem;

        private ToolStripMenuItem wordWrapToolStripMenuItem;

        private ToolStripMenuItem viewToolStripMenuItem;

        private ToolStripMenuItem helpToolStripMenuItem;

        private ToolStripMenuItem aboutTypexNotepadToolStripMenuItem;

        public ToolStripMenuItem Darkmodeswitch;

        private SaveFileDialog saveFileDialog1;

        private ToolStripMenuItem zoomInToolStripMenuItem;

        private ToolStripMenuItem zoomOutToolStripMenuItem;

        public ToolStripMenuItem autosaveToolStripMenuItem;
        char[] delimiters = new char[] { ' ', '\r', '\n' };
        
        private OpenFileDialog openFileDialog1;

        private PrintDialog printDialog1;

        private PageSetupDialog pageSetupDialog1;

        private ColorDialog colorDialog1;

        private FontDialog fontDialog1;

        private ToolStripMenuItem restoreDefaultZoomToolStripMenuItem;

        private PrintPreviewDialog printPreviewDialog1;

        private PrintDocument printDocument1;

        private ToolStripMenuItem printPreviewToolStripMenuItem;

        private ContextMenuStrip contextMenuStrip1;

        private ToolStripMenuItem searchWithGoogleToolStripMenuItem;

        private ToolStripMenuItem undoToolStripMenuItem1;

        private ToolStripSeparator toolStripMenuItem1;

        private ToolStripMenuItem cutToolStripMenuItem1;

        private ToolStripMenuItem copyToolStripMenuItem1;

        private ToolStripMenuItem pasteToolStripMenuItem1;

        private ToolStripMenuItem deleteToolStripMenuItem1;

        private ToolStripSeparator toolStripMenuItem2;

        private ToolStripMenuItem selectAllToolStripMenuItem1;

        private ToolStripSeparator toolStripMenuItem3;

        private ToolStripMenuItem searchWithBingToolStripMenuItem;

        private ToolStripMenuItem goToToolStripMenuItem;

        private ToolStripMenuItem searchWithGoogleToolStripMenuItem1;

        private ToolStripMenuItem searchWithBingToolStripMenuItem1;

        private ToolStripSeparator toolStripMenuItem4;

        private ToolStripSeparator toolStripMenuItem5;

        private ToolStripSeparator toolStripMenuItem6;

        private StatusStrip statusStrip1;

        private ToolStripStatusLabel Linelabel;
        public static Boolean isCurslyBracesKeyPressed = false;
        private ToolStripStatusLabel zoomlabel;
        public Encoding _encoding = Encoding.ASCII;
        private ToolStripMenuItem statusBarToolStripMenuItem;

        private ToolStripMenuItem helpToolStripMenuItem1;
        public TextBox TextBox1;
        private ToolStripMenuItem clipboardToolStripMenuItem;
        private ToolTip toolTip1;
        public bool iscopy=true;
        private ToolStripMenuItem oCRToolStripMenuItem;
        private ToolStripMenuItem memoToolStripMenuItem;
        private ToolStripStatusLabel autosavelabel;
        private ToolStripStatusLabel wordcountlabel;
        private Panel toolbox;
        private Button closetoolbut;
        private ToolStripMenuItem toolboxtoggle;
        private Button cutbuttool;
        private Button copybuttool;
        private Button pastebuttool;
        private Button clipboardtool;
        private Button selectalltool;
        private ToolStripMenuItem clipBoardToolStripMenuItem1;
        private ToolStripMenuItem showEncodingOptionsToolStripMenuItem;
        public bool iscut=true;
        

        private ContentPosition CaretPosition
        {
            get
            {
                return CharIndexToPosition(SelectionStart);
            }
        }

        public string Content
        {
            get
            {
                return TextBox1.Text;
            }
            set
            {
                TextBox1.Text = value;
            }
        }



        public string[] HTMLTagsList
        {
            get
            {
                return tagslist;
            }
            set
            {
                tagslist = value;
                Invalidate();
            }
        }

        public string[] KeywordsList
        {
            get
            {
                return keywordslist;
            }
            set
            {
                keywordslist = value;
                Invalidate();
            }
        }

        private int LineIndex
        {
            get
            {
                return CaretPosition.LineIndex;
            }
            set
            {
                int TargetLineIndex = value;
                if (TargetLineIndex < 0)
                {
                    TargetLineIndex = 0;
                }
                if (TargetLineIndex >= (int)TextBox1.Lines.Length)
                {
                    TargetLineIndex = (int)TextBox1.Lines.Length - 1;
                }
                int CharIndex = 0;
                for (int CurrentLineIndex = 0; CurrentLineIndex < TargetLineIndex; CurrentLineIndex++)
                {
                    CharIndex = CharIndex + TextBox1.Lines[CurrentLineIndex].Length + Environment.NewLine.Length;
                }
                SelectionStart = CharIndex;
                TextBox1.ScrollToCaret();
            }
        }

        public int SelectionEnd
        {
            get
            {
                return SelectionStart + SelectionLength;
            }
        }

        public int SelectionLength
        {
            get
            {
                return TextBox1.SelectionLength;
            }
            set
            {
                TextBox1.SelectionLength = value;
            }
        }

        public int SelectionStart
        {
            get
            {
                return TextBox1.SelectionStart;
            }
            set
            {
                TextBox1.SelectionStart = value;
                TextBox1.ScrollToCaret();
            }
        }

        static Form1()
        {
            EnteredKey = "";
            EnteredString = "";
            Is_LessThanKeyPressed = false;
            Is_GreaterThanKeyPressed = false;
            Is_AutoCompleteCharacterPressed = false;
            backcolor = Color.White;
            forecolor = Color.Black;
            CompleteBox_EnteredString = "";
            isCodeCompleteBoxAdded = false;
        }

        public Form1()
        {
            
            InitializeComponent();
            ishtmlsave = true;
            if(Settings.Default.encodingset==true)
            {
                showEncodingOptionsToolStripMenuItem.Checked = true;
            }
            else
            {
                showEncodingOptionsToolStripMenuItem.Checked = false;
            }
            if(Settings.Default.toolboxset==true)
            {
                toolbox.Show();
                toolboxtoggle.Checked = true;
            }
            else
            {
                toolbox.Hide();
                toolboxtoggle.Checked = false;
            }
            menuStrip1.CanOverflow = true;
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                clipboardtool.Enabled = true;
                clipboardToolStripMenuItem.Enabled = true;
                clipBoardToolStripMenuItem1.Enabled = true;
                pastebuttool.Enabled = true;
                pasteToolStripMenuItem.Enabled = true;
                pasteToolStripMenuItem1.Enabled = true;
            }
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            di = new DirectoryInfo(dir);
            DirectoryInfo attributes = di;
            attributes.Attributes = attributes.Attributes | FileAttributes.Normal;
            pathfnd = string.Concat(dir, "\\fndtxt.txt");
            pathclip = string.Concat(dir, "\\cliplog.txt");
            TextBox1.Font = Settings.Default.txtfontset;
            
            if (!File.Exists(pathfnd))
            {
                var newf=File.Create(pathfnd);
                newf.Close();
            }
            if (!File.Exists(pathclip))
            {
                var newf=File.Create(pathclip);
                newf.Close();
            }
            
            File.SetAttributes(pathfnd, FileAttributes.Normal);
            File.SetAttributes(pathclip, FileAttributes.Normal);

            if (Settings.Default.statusbarset == true)
            {
                statusBarToolStripMenuItem.Checked = true;
                statusStrip1.Show();
                TextBox1.Height = TextBox1.Height - statusStrip1.Height;
            }
            else
            {
                statusBarToolStripMenuItem.Checked = false;
                statusStrip1.Hide();
                TextBox1.Height = TextBox1.Height + statusStrip1.Height;
            }
            zoomlabel.Text = "100%";
            origzoom = (int)TextBox1.Font.Size;
            if (Settings.Default.wordwrapset == true)
            {
                wordWrapToolStripMenuItem.Checked = true;
                TextBox1.WordWrap = true;
            }
            else
            {
                wordWrapToolStripMenuItem.Checked = false;
                TextBox1.WordWrap = false;
            }
            
            if (filepath != null)
            {
                setTitle();
            }
            else
            {
                setTitle();
                if (TextBox1.Text == "")
                {
                    TextBox1.Text = textboxdef;
                    if (TextBox1.Focused)
                    {
                        TextBox1.SelectAll();
                    }
                }
            }

            Findbox newfind = new Findbox(this);
            Form3 newerrautosave = new Form3();
            Replacebox newreplacebox = new Replacebox(this);
            clipbd newclip = new clipbd(this);
            AddOwnedForm(newfind);
            AddOwnedForm(newerrautosave);
            AddOwnedForm(newreplacebox);
            AddOwnedForm(newclip);
             
            if (Settings.Default["copycut"].Equals("true"))
                iscopy = iscut = true;
            
            if (TextBox1.Text == "")
            {
                findToolStripMenuItem.Enabled = false;
                findNextToolStripMenuItem.Enabled = false;
            }
            else
            {
                findNextToolStripMenuItem.Enabled = true;
                findToolStripMenuItem.Enabled = true;
            }
           
                if (Settings.Default["darkmodeset"].Equals(true))
                {
                    Darkmodeswitch.Checked = true;
                    darkmodemenuchangecolor();
                }
                else
                {
                    Darkmodeswitch.Checked = false;
                    normalmodechangecolor();
                }
            

        }

        private void AutosaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autosaveToolStripMenuItem.Checked==true)
            {
                autosaveToolStripMenuItem.Checked = false;
                Settings.Default.autosaveset = false;
                Settings.Default.Save();
                setTitle();
            }
            else if (filepath == null)
            {
                Form3 newform3 = new Form3();
                newform3.ShowDialog();
                if (newform3.val == 1)
                {
                    if (showEncodingOptionsToolStripMenuItem.Checked == true)
                    {
                        encodingselection newenc = new encodingselection(this);
                        newenc.Show();
                        autosaveToolStripMenuItem.Checked =
                        Settings.Default.autosaveset = (filepath != null) ? true : false;
                        Settings.Default.Save();
                        setTitle();
                    }
                    else
                    {
                        saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                        saveFileDialog1.Title = "Save a text file";
                        saveFileDialog1.ShowDialog();
                        if (saveFileDialog1.FileName != "")
                        {
                            File.WriteAllText(saveFileDialog1.FileName, TextBox1.Text, _encoding);
                            filepath = saveFileDialog1.FileName;
                            setTitle();
                        }
                        autosaveToolStripMenuItem.Checked =
                        Settings.Default.autosaveset = (filepath != null) ? true : false;
                        Settings.Default.Save();
                        setTitle();

                    }
                    
                     
                }
                else
                {
                    MessageBox.Show("AutoSave has been disabled since the file was not saved even once !", "Typex Notepad - AutoSave Disabled !", MessageBoxButtons.OK);
                    autosaveToolStripMenuItem.Checked = false;
                    Settings.Default.autosaveset = false;
                    Settings.Default.Save();
                }
            }
            else
            {
                autosaveToolStripMenuItem.Checked = true;
                Settings.Default.autosaveset = true;
                Settings.Default.Save();
                setTitle();
            }
        }

        private ContentPosition CharIndexToPosition(int pCharIndex)
        {
            ContentPosition contentPosition;
            int CurrentCharIndex = 0;
            if ((TextBox1.Lines.Length != 0 ? true : CurrentCharIndex != 0))
            {
                int CurrentLineIndex = 0;
                while (CurrentLineIndex < (int)TextBox1.Lines.Length)
                {
                    int LineStartCharIndex = CurrentCharIndex;
                    string Line = TextBox1.Lines[CurrentLineIndex];
                    int LineEndCharIndex = LineStartCharIndex + Line.Length + 1;
                    if ((pCharIndex < LineStartCharIndex ? true : pCharIndex > LineEndCharIndex))
                    {
                        CurrentCharIndex = CurrentCharIndex + TextBox1.Lines[CurrentLineIndex].Length + Environment.NewLine.Length;
                        CurrentLineIndex++;
                    }
                    else
                    {
                        int ColumnIndex = pCharIndex - LineStartCharIndex;
                        contentPosition = new ContentPosition()
                        {
                            LineIndex = CurrentLineIndex,
                            ColumnIndex = ColumnIndex
                        };
                        return contentPosition;
                    }
                }
                contentPosition = null;
            }
            else
            {
                contentPosition = new ContentPosition()
                {
                    LineIndex = 0,
                    ColumnIndex = 0
                };
            }
            return contentPosition;
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TextBox1.Copy();
            iscopy = true;
            iscut = false;
            
            
        }

        private void CopyToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            TextBox1.Copy();
            iscopy = true;
            iscut = false;
            
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TextBox1.Cut();
            iscut = true;
            iscopy = false;
           

        }

        private void CutToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            TextBox1.Cut();
            iscut = true;
            iscopy = false;
           
        }
        public string returnseltext()
        {
            return TextBox1.SelectedText;
        }
        public void darkmodemenuchangecolor()
        {
            Color bgcolor = ColorTranslator.FromHtml("#2D2D30");
            Color fcolor = Color.White;
            ToolStripDropDownMenu filedropdown = (ToolStripDropDownMenu)fileToolStripMenuItem.DropDown;
            ToolStripDropDownMenu editdropdown = (ToolStripDropDownMenu)editToolStripMenuItem.DropDown;
            ToolStripDropDownMenu formatdropdown = (ToolStripDropDownMenu)formatToolStripMenuItem.DropDown;
            ToolStripDropDownMenu viewdropdown = (ToolStripDropDownMenu)viewToolStripMenuItem.DropDown;
            ToolStripDropDownMenu helpdropdown = (ToolStripDropDownMenu)helpToolStripMenuItem.DropDown;
            menuStrip1.Renderer = new Renderer();
            contextMenuStrip1.Renderer = new Renderer();
            contextMenuStrip1.BackColor = bgcolor;
            contextMenuStrip1.ForeColor = fcolor;
            helpdropdown.BackColor = viewdropdown.BackColor = formatdropdown.BackColor = editdropdown.BackColor = filedropdown.BackColor = bgcolor;
            helpdropdown.ForeColor = viewdropdown.ForeColor = formatdropdown.ForeColor = editdropdown.ForeColor = filedropdown.ForeColor = fcolor;
            helpdropdown.ShowCheckMargin = true;
            helpdropdown.ShowImageMargin = false;
            viewdropdown.ShowCheckMargin = true;
            viewdropdown.ShowImageMargin = false;
            formatdropdown.ShowCheckMargin = true;
            formatdropdown.ShowImageMargin = false;
            editdropdown.ShowCheckMargin = true;
            editdropdown.ShowImageMargin = false;
            filedropdown.ShowCheckMargin = true;
            filedropdown.ShowImageMargin = false;
        }

        private void Darkmodeswitch_CheckedChanged(object sender, EventArgs e)
        {
            if (!Darkmodeswitch.Checked)
            {
                normalmodechangecolor();
                menuStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
                statusStrip1.BackColor = Color.White;
                statusStrip1.ForeColor = Color.Black;
                TextBox1.BackColor = Color.White;
                TextBox1.ForeColor = Color.Black;
                menuStrip1.BackColor = Color.White;
                menuStrip1.ForeColor = Color.Black;
                BackColor = Color.White;
                ForeColor = Color.Black;
                Settings.Default["darkmodeset"] = false;
                Settings.Default.Save();
            }
            if (Darkmodeswitch.Checked)
            {
                darkmodemenuchangecolor();
                statusStrip1.BackColor = ColorTranslator.FromHtml("#2D2D30");
                statusStrip1.ForeColor = Color.White;
                TextBox1.BackColor = ColorTranslator.FromHtml("#1E1E1E");
                TextBox1.ForeColor = Color.White;
                menuStrip1.BackColor = ColorTranslator.FromHtml("#2D2D30");
                menuStrip1.ForeColor = Color.White;
                BackColor = ColorTranslator.FromHtml("#1E1E1E");
                ForeColor = Color.White;
                Settings.Default["darkmodeset"] = true;
                Settings.Default.Save();
            }
        }

        private void Darkmodeswitch_Click(object sender, EventArgs e)
        {
            if (!Darkmodeswitch.Checked)
            {
                Darkmodeswitch.Checked = true;
                Settings.Default["darkmodeset"] = true;
                Settings.Default.Save();
            }
            else
            {
                Darkmodeswitch.Checked = false;
                Settings.Default["darkmodeset"] = false;
                Settings.Default.Save();
            }
        }

        public bool darkyes()
        {
            return (!Darkmodeswitch.Checked ? false : true);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox1.SelectedText = string.Empty;
        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox1.SelectedText = "";
        }

        protected override void Dispose(bool disposing)
        {
            if ((!disposing ? false : components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((!(TextBox1.Text != string.Empty) || filepath != null ? false : TextBox1.Text != textboxdef))
            {
                if (MessageBox.Show("Do you save the Untitled file before closing ?", "Typex Notepad", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (showEncodingOptionsToolStripMenuItem.Checked == true)
                    {
                        encodingselection newenc = new encodingselection(this);
                        newenc.Show();
                    }
                    else
                    {
                        saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                        saveFileDialog1.Title = "Save a text file";
                        saveFileDialog1.ShowDialog();
                        if (saveFileDialog1.FileName != "")
                        {
                            File.WriteAllText(saveFileDialog1.FileName, TextBox1.Text, _encoding);
                            filepath = saveFileDialog1.FileName;
                            setTitle();
                        }
                    }
                }
            }

            Close();
        }

        private void filedropdown_open(object sender, EventArgs e)
        {
        }

        private void filemenu_hover(object sender, EventArgs e)
        {
        }

        private void filemenu_leave(object sender, EventArgs e)
        {
        }

        public bool FindNext(string TextToFind, bool MatchCase, bool pSearchDown)
        {
            int Index;
            bool flag;
            StringComparison mode = (MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase);
            Index = (!pSearchDown ? TextBox1.Text.LastIndexOf(TextToFind, SelectionStart, SelectionStart, mode) : TextBox1.Text.IndexOf(TextToFind, SelectionEnd, mode));
            if (Index != -1)
            {
                TextBox1.SelectionStart = Index;
                TextBox1.SelectionLength = TextToFind.Length;
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;
        }
       

    private void FindNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Findbox(this)).ShowDialog();
            Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);
        }

        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Findbox(this)).ShowDialog();
            Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = TextBox1.Font;
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                TextBox1.Font = fontDialog1.Font;
                Settings.Default.txtfontset = fontDialog1.Font;
                Settings.Default.Save();
                origzoom = (int)TextBox1.Font.Size;
            }
        }

        private void form1_sizechanged(object sender, EventArgs e)
        {
            Update();
            UpdateBounds();
            UpdateStyles();
        }
        public void setcopycutfalse()
        {
            iscopy = false;
            iscut = false;
            Settings.Default.copycut = false;
            Settings.Default.Save();
        }
        private void formclose(object sender, FormClosingEventArgs e)
        {
            if ((!(TextBox1.Text != string.Empty) || filepath != null ? false : TextBox1.Text != textboxdef))
            {
                if (MessageBox.Show("Do you save the Untitled file before closing ?", "Typex Notepad", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (showEncodingOptionsToolStripMenuItem.Checked == true)
                    {
                        encodingselection newenc = new encodingselection(this);
                        newenc.Show();
                    }
                    else
                    {
                        saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                        saveFileDialog1.Title = "Save a text file";
                        saveFileDialog1.ShowDialog();
                        if (saveFileDialog1.FileName != "")
                        {
                            File.WriteAllText(saveFileDialog1.FileName, TextBox1.Text, _encoding);
                            filepath = saveFileDialog1.FileName;
                            setTitle();
                        }
                    }
                }
            }
            if (!Darkmodeswitch.Checked)
            {
                Settings.Default["darkmodeset"] = false;
                Settings.Default.Save();
            }
            else
            {
                Settings.Default["darkmodeset"] = true;
                Settings.Default.Save();
            }
            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1)
            {

            }
            else
            {

                Settings.Default.clipbdset = String.Empty;
                Settings.Default.Save();
            }
        }

        private void GoToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gotobox GoToLinePrompt = new Gotobox(LineIndex + 1)
            {
                Left = Left + 5,
                Top = Top + 44
            };
            if (GoToLinePrompt.ShowDialog(this) == DialogResult.OK)
            {
                int TargetLineIndex = GoToLinePrompt.LineNumber - 1;
                if (TargetLineIndex <= (int)TextBox1.Lines.Length)
                {
                    LineIndex = TargetLineIndex;
                }
                else
                {
                    MessageBox.Show(this, "The line number is beyond the total number of lines !", "Typex Notepad");
                }
                Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);
            }
        }

        private void HelpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autosaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showEncodingOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchWithGoogleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.searchWithBingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.timeDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDefaultZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Darkmodeswitch = new System.Windows.Forms.ToolStripMenuItem();
            this.toolboxtoggle = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oCRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTypexNotepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clipBoardToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.searchWithGoogleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchWithBingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Linelabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.wordcountlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.autosavelabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolbox = new System.Windows.Forms.Panel();
            this.selectalltool = new System.Windows.Forms.Button();
            this.clipboardtool = new System.Windows.Forms.Button();
            this.pastebuttool = new System.Windows.Forms.Button();
            this.copybuttool = new System.Windows.Forms.Button();
            this.cutbuttool = new System.Windows.Forms.Button();
            this.closetoolbut = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(800, 23);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.SizeChanged += new System.EventHandler(this.menustrip_sizechanged);
            this.menuStrip1.Resize += new System.EventHandler(this.menustrip_resize);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.autosaveToolStripMenuItem,
            this.showEncodingOptionsToolStripMenuItem,
            this.pageSetupToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownOpened += new System.EventHandler(this.filedropdown_open);
            this.fileToolStripMenuItem.MouseLeave += new System.EventHandler(this.filemenu_leave);
            this.fileToolStripMenuItem.MouseHover += new System.EventHandler(this.filemenu_hover);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // autosaveToolStripMenuItem
            // 
            this.autosaveToolStripMenuItem.Name = "autosaveToolStripMenuItem";
            this.autosaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.autosaveToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.autosaveToolStripMenuItem.Text = "Autosave";
            this.autosaveToolStripMenuItem.Click += new System.EventHandler(this.AutosaveToolStripMenuItem_Click);
            // 
            // showEncodingOptionsToolStripMenuItem
            // 
            this.showEncodingOptionsToolStripMenuItem.Checked = true;
            this.showEncodingOptionsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showEncodingOptionsToolStripMenuItem.Name = "showEncodingOptionsToolStripMenuItem";
            this.showEncodingOptionsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.showEncodingOptionsToolStripMenuItem.Text = "Show Encoding Options";
            this.showEncodingOptionsToolStripMenuItem.Click += new System.EventHandler(this.ShowEncodingOptionsToolStripMenuItem_Click);
            // 
            // pageSetupToolStripMenuItem
            // 
            this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            this.pageSetupToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.pageSetupToolStripMenuItem.Text = "Page Setup";
            this.pageSetupToolStripMenuItem.Click += new System.EventHandler(this.PageSetupToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.PrintPreviewToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripMenuItem4,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.clipboardToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem5,
            this.findToolStripMenuItem,
            this.findNextToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.goToToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.searchWithGoogleToolStripMenuItem1,
            this.searchWithBingToolStripMenuItem1,
            this.toolStripMenuItem6,
            this.timeDateToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 19);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(222, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.cutToolStripMenuItem.Text = "Cut ";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
            // 
            // clipboardToolStripMenuItem
            // 
            this.clipboardToolStripMenuItem.Name = "clipboardToolStripMenuItem";
            this.clipboardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.clipboardToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.clipboardToolStripMenuItem.Text = "Clipboard";
            this.clipboardToolStripMenuItem.Click += new System.EventHandler(this.ClipboardToolStripMenuItem_Click_1);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(222, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.FindToolStripMenuItem_Click);
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            this.findNextToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.findNextToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.findNextToolStripMenuItem.Text = "Find Next";
            this.findNextToolStripMenuItem.Click += new System.EventHandler(this.FindNextToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.ReplaceToolStripMenuItem_Click);
            // 
            // goToToolStripMenuItem
            // 
            this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
            this.goToToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.goToToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.goToToolStripMenuItem.Text = "Go To..";
            this.goToToolStripMenuItem.Click += new System.EventHandler(this.GoToToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItem_Click);
            // 
            // searchWithGoogleToolStripMenuItem1
            // 
            this.searchWithGoogleToolStripMenuItem1.Name = "searchWithGoogleToolStripMenuItem1";
            this.searchWithGoogleToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.searchWithGoogleToolStripMenuItem1.Size = new System.Drawing.Size(225, 22);
            this.searchWithGoogleToolStripMenuItem1.Text = "Search with Google...";
            this.searchWithGoogleToolStripMenuItem1.Click += new System.EventHandler(this.SearchWithGoogleToolStripMenuItem1_Click);
            // 
            // searchWithBingToolStripMenuItem1
            // 
            this.searchWithBingToolStripMenuItem1.Name = "searchWithBingToolStripMenuItem1";
            this.searchWithBingToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.searchWithBingToolStripMenuItem1.Size = new System.Drawing.Size(225, 22);
            this.searchWithBingToolStripMenuItem1.Text = "Search with Bing...";
            this.searchWithBingToolStripMenuItem1.Click += new System.EventHandler(this.SearchWithBingToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(222, 6);
            // 
            // timeDateToolStripMenuItem
            // 
            this.timeDateToolStripMenuItem.Name = "timeDateToolStripMenuItem";
            this.timeDateToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.timeDateToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.timeDateToolStripMenuItem.Text = "Time/Date";
            this.timeDateToolStripMenuItem.Click += new System.EventHandler(this.TimeDateToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontToolStripMenuItem,
            this.wordWrapToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(57, 19);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItem_Click);
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.Checked = true;
            this.wordWrapToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.wordWrapToolStripMenuItem.Text = "Word Wrap";
            this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.WordWrapToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.restoreDefaultZoomToolStripMenuItem,
            this.Darkmodeswitch,
            this.toolboxtoggle,
            this.statusBarToolStripMenuItem,
            this.oCRToolStripMenuItem,
            this.memoToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.ViewToolStripMenuItem_Click);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Plus";
            this.zoomInToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.ZoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Minus";
            this.zoomOutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.ZoomOutToolStripMenuItem_Click);
            // 
            // restoreDefaultZoomToolStripMenuItem
            // 
            this.restoreDefaultZoomToolStripMenuItem.Name = "restoreDefaultZoomToolStripMenuItem";
            this.restoreDefaultZoomToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.restoreDefaultZoomToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.restoreDefaultZoomToolStripMenuItem.Text = "Restore Default Zoom";
            this.restoreDefaultZoomToolStripMenuItem.Click += new System.EventHandler(this.RestoreDefaultZoomToolStripMenuItem_Click);
            // 
            // Darkmodeswitch
            // 
            this.Darkmodeswitch.Name = "Darkmodeswitch";
            this.Darkmodeswitch.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.Darkmodeswitch.Size = new System.Drawing.Size(229, 22);
            this.Darkmodeswitch.Text = "Dark Mode";
            this.Darkmodeswitch.CheckedChanged += new System.EventHandler(this.Darkmodeswitch_CheckedChanged);
            this.Darkmodeswitch.Click += new System.EventHandler(this.Darkmodeswitch_Click);
            // 
            // toolboxtoggle
            // 
            this.toolboxtoggle.Checked = true;
            this.toolboxtoggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolboxtoggle.Name = "toolboxtoggle";
            this.toolboxtoggle.Size = new System.Drawing.Size(229, 22);
            this.toolboxtoggle.Text = "ToolBox";
            this.toolboxtoggle.Click += new System.EventHandler(this.toolboxtoggle_Click);
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.statusBarToolStripMenuItem.Text = "Status Bar";
            this.statusBarToolStripMenuItem.CheckedChanged += new System.EventHandler(this.statusbartool_checkchanged);
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // oCRToolStripMenuItem
            // 
            this.oCRToolStripMenuItem.Name = "oCRToolStripMenuItem";
            this.oCRToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.oCRToolStripMenuItem.Text = "OCR";
            this.oCRToolStripMenuItem.Click += new System.EventHandler(this.OCRToolStripMenuItem_Click);
            // 
            // memoToolStripMenuItem
            // 
            this.memoToolStripMenuItem.Name = "memoToolStripMenuItem";
            this.memoToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.memoToolStripMenuItem.Text = "Memo";
            this.memoToolStripMenuItem.Click += new System.EventHandler(this.MemoToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutTypexNotepadToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.HelpToolStripMenuItem1_Click);
            // 
            // aboutTypexNotepadToolStripMenuItem
            // 
            this.aboutTypexNotepadToolStripMenuItem.Name = "aboutTypexNotepadToolStripMenuItem";
            this.aboutTypexNotepadToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.aboutTypexNotepadToolStripMenuItem.Text = "About Typex Notepad";
            this.aboutTypexNotepadToolStripMenuItem.Click += new System.EventHandler(this.AboutTypexNotepadToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.DropShadowEnabled = false;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.cutToolStripMenuItem1,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1,
            this.clipBoardToolStripMenuItem1,
            this.deleteToolStripMenuItem1,
            this.toolStripMenuItem2,
            this.selectAllToolStripMenuItem1,
            this.toolStripMenuItem3,
            this.searchWithGoogleToolStripMenuItem,
            this.searchWithBingToolStripMenuItem});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 242);
            // 
            // undoToolStripMenuItem1
            // 
            this.undoToolStripMenuItem1.Enabled = false;
            this.undoToolStripMenuItem1.Name = "undoToolStripMenuItem1";
            this.undoToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.undoToolStripMenuItem1.Text = "Undo";
            this.undoToolStripMenuItem1.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 6);
            // 
            // cutToolStripMenuItem1
            // 
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.cutToolStripMenuItem1.Text = "Cut";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.CutToolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.CopyToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.PasteToolStripMenuItem1_Click);
            // 
            // clipBoardToolStripMenuItem1
            // 
            this.clipBoardToolStripMenuItem1.Name = "clipBoardToolStripMenuItem1";
            this.clipBoardToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.clipBoardToolStripMenuItem1.Text = "Clipboard";
            this.clipBoardToolStripMenuItem1.Click += new System.EventHandler(this.clipBoardToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 6);
            // 
            // selectAllToolStripMenuItem1
            // 
            this.selectAllToolStripMenuItem1.Name = "selectAllToolStripMenuItem1";
            this.selectAllToolStripMenuItem1.Size = new System.Drawing.Size(185, 22);
            this.selectAllToolStripMenuItem1.Text = "Select All";
            this.selectAllToolStripMenuItem1.Click += new System.EventHandler(this.SelectAllToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(182, 6);
            // 
            // searchWithGoogleToolStripMenuItem
            // 
            this.searchWithGoogleToolStripMenuItem.Name = "searchWithGoogleToolStripMenuItem";
            this.searchWithGoogleToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.searchWithGoogleToolStripMenuItem.Text = "Search with Google...";
            this.searchWithGoogleToolStripMenuItem.Click += new System.EventHandler(this.SearchWithGoogleToolStripMenuItem_Click);
            // 
            // searchWithBingToolStripMenuItem
            // 
            this.searchWithBingToolStripMenuItem.Name = "searchWithBingToolStripMenuItem";
            this.searchWithBingToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.searchWithBingToolStripMenuItem.Text = "Search with Bing...";
            this.searchWithBingToolStripMenuItem.Click += new System.EventHandler(this.SearchWithBingToolStripMenuItem_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Linelabel,
            this.wordcountlabel,
            this.zoomlabel,
            this.autosavelabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Linelabel
            // 
            this.Linelabel.Name = "Linelabel";
            this.Linelabel.Size = new System.Drawing.Size(0, 17);
            // 
            // wordcountlabel
            // 
            this.wordcountlabel.Name = "wordcountlabel";
            this.wordcountlabel.Size = new System.Drawing.Size(47, 17);
            this.wordcountlabel.Text = "Words :";
            // 
            // zoomlabel
            // 
            this.zoomlabel.Name = "zoomlabel";
            this.zoomlabel.Size = new System.Drawing.Size(0, 17);
            // 
            // autosavelabel
            // 
            this.autosavelabel.Name = "autosavelabel";
            this.autosavelabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolbox
            // 
            this.toolbox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.toolbox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.toolbox.BackColor = System.Drawing.Color.DarkMagenta;
            this.toolbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolbox.Controls.Add(this.selectalltool);
            this.toolbox.Controls.Add(this.clipboardtool);
            this.toolbox.Controls.Add(this.pastebuttool);
            this.toolbox.Controls.Add(this.copybuttool);
            this.toolbox.Controls.Add(this.cutbuttool);
            this.toolbox.Controls.Add(this.closetoolbut);
            this.toolbox.Location = new System.Drawing.Point(729, 39);
            this.toolbox.Name = "toolbox";
            this.toolbox.Size = new System.Drawing.Size(53, 375);
            this.toolbox.TabIndex = 3;
            this.toolTip1.SetToolTip(this.toolbox, "ToolBox");
            this.toolbox.Paint += new System.Windows.Forms.PaintEventHandler(this.toolbox_Paint);
            this.toolbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolbox_mousedown);
            this.toolbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolbox_mousemove);
            this.toolbox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolbox_mouseup);
            // 
            // selectalltool
            // 
            this.selectalltool.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.selectalltool.BackColor = System.Drawing.Color.DarkMagenta;
            this.selectalltool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("selectalltool.BackgroundImage")));
            this.selectalltool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selectalltool.FlatAppearance.BorderSize = 0;
            this.selectalltool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectalltool.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectalltool.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.selectalltool.Location = new System.Drawing.Point(2, 8);
            this.selectalltool.Name = "selectalltool";
            this.selectalltool.Size = new System.Drawing.Size(47, 52);
            this.selectalltool.TabIndex = 5;
            this.toolTip1.SetToolTip(this.selectalltool, "Select All");
            this.selectalltool.UseVisualStyleBackColor = false;
            this.selectalltool.Click += new System.EventHandler(this.selectalltool_Click);
            // 
            // clipboardtool
            // 
            this.clipboardtool.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.clipboardtool.BackColor = System.Drawing.Color.DarkMagenta;
            this.clipboardtool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clipboardtool.BackgroundImage")));
            this.clipboardtool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clipboardtool.Enabled = false;
            this.clipboardtool.FlatAppearance.BorderSize = 0;
            this.clipboardtool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clipboardtool.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clipboardtool.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.clipboardtool.Location = new System.Drawing.Point(2, 253);
            this.clipboardtool.Name = "clipboardtool";
            this.clipboardtool.Size = new System.Drawing.Size(47, 52);
            this.clipboardtool.TabIndex = 4;
            this.toolTip1.SetToolTip(this.clipboardtool, "Show ClipBoard");
            this.clipboardtool.UseVisualStyleBackColor = false;
            this.clipboardtool.Click += new System.EventHandler(this.clipboardtool_Click);
            // 
            // pastebuttool
            // 
            this.pastebuttool.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pastebuttool.BackColor = System.Drawing.Color.DarkMagenta;
            this.pastebuttool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pastebuttool.BackgroundImage")));
            this.pastebuttool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pastebuttool.Enabled = false;
            this.pastebuttool.FlatAppearance.BorderSize = 0;
            this.pastebuttool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pastebuttool.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pastebuttool.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.pastebuttool.Location = new System.Drawing.Point(2, 191);
            this.pastebuttool.Name = "pastebuttool";
            this.pastebuttool.Size = new System.Drawing.Size(47, 52);
            this.pastebuttool.TabIndex = 3;
            this.toolTip1.SetToolTip(this.pastebuttool, "Paste");
            this.pastebuttool.UseVisualStyleBackColor = false;
            this.pastebuttool.Click += new System.EventHandler(this.pastebuttool_Click);
            // 
            // copybuttool
            // 
            this.copybuttool.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.copybuttool.BackColor = System.Drawing.Color.DarkMagenta;
            this.copybuttool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("copybuttool.BackgroundImage")));
            this.copybuttool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.copybuttool.FlatAppearance.BorderSize = 0;
            this.copybuttool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copybuttool.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copybuttool.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.copybuttool.Location = new System.Drawing.Point(2, 129);
            this.copybuttool.Name = "copybuttool";
            this.copybuttool.Size = new System.Drawing.Size(47, 52);
            this.copybuttool.TabIndex = 2;
            this.toolTip1.SetToolTip(this.copybuttool, "Copy");
            this.copybuttool.UseVisualStyleBackColor = false;
            this.copybuttool.Click += new System.EventHandler(this.copybuttool_Click);
            // 
            // cutbuttool
            // 
            this.cutbuttool.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cutbuttool.BackColor = System.Drawing.Color.DarkMagenta;
            this.cutbuttool.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cutbuttool.BackgroundImage")));
            this.cutbuttool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cutbuttool.FlatAppearance.BorderSize = 0;
            this.cutbuttool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cutbuttool.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cutbuttool.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cutbuttool.Location = new System.Drawing.Point(2, 69);
            this.cutbuttool.Name = "cutbuttool";
            this.cutbuttool.Size = new System.Drawing.Size(47, 52);
            this.cutbuttool.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cutbuttool, "Cut");
            this.cutbuttool.UseVisualStyleBackColor = false;
            this.cutbuttool.Click += new System.EventHandler(this.cutbuttool_Click);
            this.cutbuttool.MouseEnter += new System.EventHandler(this.cutbuttool_mouseenter);
            this.cutbuttool.MouseHover += new System.EventHandler(this.cutbuttool_mousehover);
            // 
            // closetoolbut
            // 
            this.closetoolbut.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.closetoolbut.BackColor = System.Drawing.Color.DarkMagenta;
            this.closetoolbut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.closetoolbut.FlatAppearance.BorderSize = 0;
            this.closetoolbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closetoolbut.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closetoolbut.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.closetoolbut.Location = new System.Drawing.Point(2, 314);
            this.closetoolbut.Name = "closetoolbut";
            this.closetoolbut.Size = new System.Drawing.Size(47, 52);
            this.closetoolbut.TabIndex = 0;
            this.closetoolbut.Text = "✕";
            this.toolTip1.SetToolTip(this.closetoolbut, "Close ToolBox");
            this.closetoolbut.UseVisualStyleBackColor = false;
            this.closetoolbut.Click += new System.EventHandler(this.closetoolbut_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.AllowDrop = true;
            this.TextBox1.BackColor = System.Drawing.Color.White;
            this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox1.HideSelection = false;
            this.TextBox1.Location = new System.Drawing.Point(0, 23);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox1.Size = new System.Drawing.Size(800, 412);
            this.TextBox1.TabIndex = 1;
            this.TextBox1.Click += new System.EventHandler(this.textbox1_click);
            this.TextBox1.CursorChanged += new System.EventHandler(this.textbox1_cursorchanged);
            this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.TextBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textbox_dragdrop);
            this.TextBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textbox_dragenter);
            this.TextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox1_keydown);
            this.TextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox1_keypress);
            this.TextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textbox1_keyup);
            this.TextBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextBox1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 457);
            this.Controls.Add(this.toolbox);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Typex Notepad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formclose);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Shown += new System.EventHandler(this.form1_shown);
            this.ResizeBegin += new System.EventHandler(this.form1_resizebegin);
            this.ResizeEnd += new System.EventHandler(this.form1_resizeend);
            this.SizeChanged += new System.EventHandler(this.form1_sizechanged);
            this.Resize += new System.EventHandler(this.form1_resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolbox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if ((!(TextBox1.Text != string.Empty) || filepath != null ? false : TextBox1.Text != textboxdef))
            {
                if (MessageBox.Show("Do you save the Untitled file before opening new file ?", "Typex Notepad", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (showEncodingOptionsToolStripMenuItem.Checked == true)
                    {
                        encodingselection newenc = new encodingselection(this);
                        newenc.Show();
                    }
                    else
                    {
                        saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                        saveFileDialog1.Title = "Save a text file";
                        saveFileDialog1.ShowDialog();
                        if (saveFileDialog1.FileName != "")
                        {
                            File.WriteAllText(saveFileDialog1.FileName, TextBox1.Text, _encoding);
                            filepath = saveFileDialog1.FileName;
                            setTitle();
                        }
                    }
                }
            }
            filepath = null;
            setTitle();
            ishtmlsave = true;
            TextBox1.Text = "Drag and drop a file here or start typing";
            TextBox1.SelectAll();
            if (Settings.Default.autosaveset == true)
            {
                if (filepath == null)
                {
                    Form3 newform3 = new Form3();
                    newform3.ShowDialog();
                    if (newform3.val == 1)
                    {
                        if (showEncodingOptionsToolStripMenuItem.Checked == true)
                        {
                            encodingselection newenc = new encodingselection(this);
                            newenc.Show();
                        }
                        else
                        {
                            saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                            saveFileDialog1.Title = "Save a text file";
                            saveFileDialog1.ShowDialog();
                            if (saveFileDialog1.FileName != "")
                            {
                                File.WriteAllText(saveFileDialog1.FileName, TextBox1.Text, _encoding);
                                filepath = saveFileDialog1.FileName;
                                setTitle();
                            }
                            
                        }
                        if (filepath != null)
                        {
                            setTitle();
                        }
                        autosaveToolStripMenuItem.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("AutoSave has been disabled since the file was not saved even once !", "Typex Notepad - AutoSave Disabled !", MessageBoxButtons.OK);
                        autosaveToolStripMenuItem.Checked = false;
                        Settings.Default.autosaveset = false;
                        Settings.Default.Save();
                    }
                }
                else
                {
                    autosaveToolStripMenuItem.Checked = true;
                    setTitle();
                }
            }
            else
            {
                autosaveToolStripMenuItem.Checked = false;
                setTitle();
            }
        }
        public void setTitle()
        {
            if(filepath==null)
            {
                Text = "Typex Notepad - Untitled";
            }
            else
            { 
            if(autosaveToolStripMenuItem.Checked==true)
                {
                    Text = string.Concat("Typex Notepad - ",filepath," (Autosave Enabled)");
                }
            else
                {
                    Text = string.Concat("Typex Notepad - ",filepath);
                }

            }
        }
        public void normalmodechangecolor()
        {
            Color bgcolor = Color.White;
            Color fcolor = Color.Black;
            ToolStripDropDownMenu filedropdown = (ToolStripDropDownMenu)fileToolStripMenuItem.DropDown;
            ToolStripDropDownMenu editdropdown = (ToolStripDropDownMenu)editToolStripMenuItem.DropDown;
            ToolStripDropDownMenu formatdropdown = (ToolStripDropDownMenu)formatToolStripMenuItem.DropDown;
            ToolStripDropDownMenu viewdropdown = (ToolStripDropDownMenu)viewToolStripMenuItem.DropDown;
            ToolStripDropDownMenu helpdropdown = (ToolStripDropDownMenu)helpToolStripMenuItem.DropDown;
            menuStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            contextMenuStrip1.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            contextMenuStrip1.BackColor = bgcolor;
            contextMenuStrip1.ForeColor = fcolor;
            helpdropdown.ShowCheckMargin = true;
            helpdropdown.ShowImageMargin = false;
            viewdropdown.ShowCheckMargin = true;
            viewdropdown.ShowImageMargin = false;
            formatdropdown.ShowCheckMargin = true;
            formatdropdown.ShowImageMargin = false;
            editdropdown.ShowCheckMargin = true;
            editdropdown.ShowImageMargin = false;
            filedropdown.ShowCheckMargin = true;
            filedropdown.ShowImageMargin = false;
            helpdropdown.BackColor = bgcolor;

            viewdropdown.BackColor = bgcolor;

            formatdropdown.BackColor = bgcolor;

            editdropdown.BackColor = bgcolor;
            filedropdown.BackColor = bgcolor;

            helpdropdown.ForeColor = fcolor;

            viewdropdown.ForeColor = fcolor;

            formatdropdown.ForeColor = fcolor;

            editdropdown.ForeColor = fcolor;
            filedropdown.ForeColor = fcolor;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((!(TextBox1.Text != string.Empty) || filepath != null ? false : TextBox1.Text != textboxdef))
            {
                if (MessageBox.Show("Do you save the current file first before opening new file?", "Typex Notepad", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (showEncodingOptionsToolStripMenuItem.Checked == true)
                    {
                        encodingselection newenc = new encodingselection(this);
                        newenc.Show();
                    }
                    else
                    {
                        saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                        saveFileDialog1.Title = "Save a text file";
                        saveFileDialog1.ShowDialog();
                        if (saveFileDialog1.FileName != "")
                        {
                            File.WriteAllText(saveFileDialog1.FileName, TextBox1.Text, _encoding);

                            filepath = saveFileDialog1.FileName;
                            setTitle();
                        }

                    }
                }
            }
            openFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader objReader = new StreamReader(openFileDialog1.FileName);
                TextBox1.Text = objReader.ReadToEnd();
                objReader.Close();
                filepath = openFileDialog1.FileName;
                setTitle();
            }
        }

        private void PageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {

            pageSetupDialog1.Document = printDocument1;
            pageSetupDialog1.PageSettings = printDocument1.DefaultPageSettings;
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox1.Paste();
        }

        private void PasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox1.Paste();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            TextBox1.WordWrap = false;
            fonttype = TextBox1.Font.Name;
            e.Graphics.DrawString(TextBox1.Text, new Font(fonttype, 14f, FontStyle.Regular), Brushes.Black, new PointF(100f, 100f));
            TextBox1.WordWrap = true;
        }

        private void PrintPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        public void ProcessAutoCompleteBrackets(string s)
        {
            int sel = TextBox1.SelectionStart;
            string str = s;
            if (str != null)
            {
                if (str == "(")
                {
                    TextBox1.Text = TextBox1.Text.Insert(sel, ")");
                    TextBox1.SelectionStart = sel;
                    TextBox1.ScrollToCaret();
                    Is_AutoCompleteCharacterPressed = true;
                }
                else if (str == "[")
                {
                    TextBox1.Text = TextBox1.Text.Insert(sel, "]");
                    TextBox1.SelectionStart = sel;
                    TextBox1.ScrollToCaret();
                    Is_AutoCompleteCharacterPressed = true;
                }
                else if (str == "\"")
                {
                    Is_AutoCompleteCharacterPressed = true;
                    TextBox1.Text = TextBox1.Text.Insert(sel, "\"");
                    TextBox1.ScrollToCaret();
                    TextBox1.SelectionStart = sel;
                }
                else if (str == "'")
                {
                    TextBox1.Text = TextBox1.Text.Insert(sel, "'");
                    TextBox1.SelectionStart = sel;
                    TextBox1.ScrollToCaret();
                    Is_AutoCompleteCharacterPressed = true;
                }
            }
        }

        private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Replacebox(this)).ShowDialog();
            Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);
        }

        private void RestoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fonttype = TextBox1.Font.Name;
            TextBox1.Font = new Font(fonttype, 20.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
            zoomlabel.Text = "100%";
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showEncodingOptionsToolStripMenuItem.Checked == true)
            {
                encodingselection newenc = new encodingselection(this);
                newenc.Show();
            }
            else
            {
                saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                saveFileDialog1.Title = "Save a text file";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    File.WriteAllText(saveFileDialog1.FileName, TextBox1.Text, _encoding);
                    filepath = saveFileDialog1.FileName;
                    setTitle();
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filepath != null)
            {
                File.WriteAllText(filepath, TextBox1.Text);
            }
            else
            {
                if (showEncodingOptionsToolStripMenuItem.Checked == true)
                {
                    encodingselection newenc = new encodingselection(this);
                    newenc.Show();
                }
                else
                {
                    saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                    saveFileDialog1.Title = "Save a text file";
                    saveFileDialog1.ShowDialog();
                    if (saveFileDialog1.FileName != "")
                    {
                        File.WriteAllText(saveFileDialog1.FileName, TextBox1.Text, _encoding);

                        filepath = saveFileDialog1.FileName;
                        setTitle();
                    }
                }
            }
        }

        private void SearchWithBingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(string.Concat("www.bing.com/search?q=", TextBox1.SelectedText));
        }

        private void SearchWithBingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start(string.Concat("www.bing.com/search?q=", TextBox1.SelectedText));
        }

        private void searchwithgg_Click(object sender, EventArgs e)
        {
            string url = string.Concat("www.google.com/search?q=", TextBox1.SelectedText);
            Process.Start(url);
        }

        private void SearchWithGoogleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(string.Concat("www.google.com/search?q=", TextBox1.SelectedText));
        }

        private void SearchWithGoogleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start(string.Concat("www.google.com/search?q=", TextBox1.SelectedText));
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox1.SelectAll();
            cutbuttool.Enabled = true;
            cutToolStripMenuItem.Enabled = true;
            cutToolStripMenuItem1.Enabled = true;
            copybuttool.Enabled = true;
            copyToolStripMenuItem.Enabled = true;
            copyToolStripMenuItem1.Enabled = true;
        }

        private void SelectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBox1.SelectAll();
            cutbuttool.Enabled = true;
            cutToolStripMenuItem.Enabled = true;
            cutToolStripMenuItem1.Enabled = true;
            copybuttool.Enabled = true;
            copyToolStripMenuItem.Enabled = true;
            copyToolStripMenuItem1.Enabled = true;
        }

        private void statusbartool_checkchanged(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked)
            {
                statusStrip1.Show();
                TextBox1.Height = TextBox1.Height - statusStrip1.Height;
                Settings.Default.statusbarset = true;
                Settings.Default.Save();
            }
            else
            {
                statusStrip1.Visible = false;
                TextBox1.Height = TextBox1.Height + statusStrip1.Height;
                Settings.Default.statusbarset = false;
                Settings.Default.Save();
            }
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!statusBarToolStripMenuItem.Checked)
            {
                statusBarToolStripMenuItem.Checked = true;
            }
            else
            {
                statusBarToolStripMenuItem.Checked = false;
            }
        }

        private void textbox_dragdrop(object sender, DragEventArgs e)
        {
            if ((TextBox1.Text != "Drag and drop a file here or start typing" ? true : filepath != null))
            {
                if ((!(TextBox1.Text != string.Empty) || filepath != null ? false : TextBox1.Text != textboxdef))
                {
                    if (MessageBox.Show("Do you save the Untitled file first before opening another file?", "Typex Notepad", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (showEncodingOptionsToolStripMenuItem.Checked == true)
                        {
                            encodingselection newenc = new encodingselection(this);
                            newenc.Show();
                        }
                        else
                        {
                            saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                            saveFileDialog1.Title = "Save a text file";
                            saveFileDialog1.ShowDialog();
                            if (saveFileDialog1.FileName != "")
                            {
                                File.WriteAllText(saveFileDialog1.FileName, TextBox1.Text, _encoding);
                                filepath = saveFileDialog1.FileName;
                                setTitle();

                            }
                        }
                    }
                }
            }
            object data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                string[] Filenames = data as string[];
                if (Filenames.Length != 0)
                {
                    string strdata = File.ReadAllText(Filenames[0]);
                    TextBox1.Text = strdata;
                    filepath = Filenames[0];
                    ishtmlsave = false;
                    #region Determine Encoding
                    using (var streamReader = new StreamReader(Filenames[0], detectEncodingFromByteOrderMarks: true))
                    {
                        var text = streamReader.ReadToEnd();
                        _encoding = streamReader.CurrentEncoding;
                    }
                    #endregion
                    setTitle();
                }
            }
            else if (MessageBox.Show("Cannot open file", "Typex Notepad", MessageBoxButtons.OK) == DialogResult.OK)
            {
                TextBox1.Focus();
            }
        }

        private void textbox_dragenter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.All;
            }
        }
        
    private void textbox1_click(object sender, EventArgs e)
        {
            Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);
        }

        private void textbox1_cursorchanged(object sender, EventArgs e)
        {
            Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);
        }

        private void textbox1_keydown(object sender, KeyEventArgs e)
        {
           
            Keys keyCode = e.KeyCode;
            if (keyCode == Keys.Back)
            {
                int sel = TextBox1.SelectionStart;
                Point pt = TextBox1.GetPositionFromCharIndex(sel);
                char ch = TextBox1.GetCharFromPosition(pt);
                if (EnteredString.Length > 0)
                {
                    if (ch != '>')
                    {
                        EnteredString = EnteredString.Remove(EnteredString.Length - 1);
                        Is_LessThanKeyPressed = true;
                    }
                }
                if (ch == '<')
                {
                    EnteredString = "";
                }
            }
            else if (keyCode == Keys.Return)
            {
                EnteredString = "";
                Is_SpaceBarKeyPressed = false;
            }
            else
            {
                switch (keyCode)
                {
                    case Keys.Space:
                        {
                            Is_SpaceBarKeyPressed = true;
                            if (Is_GreaterThanKeyPressed)
                            {
                                Is_GreaterThanKeyPressed = false;
                            }
                            Is_LessThanKeyPressed = false;
                            for (int i = 0; i < (int)tagslist.Length; i++)
                            {
                                if (EnteredString == tagslist[i])
                                {
                                    EnteredString = tagslist[i];
                                }
                            }
                            break;
                        }
                    case Keys.Left:
                        {
                            if (!Is_AutoCompleteCharacterPressed)
                            {
                                EnteredString = "";
                                Is_AutoCompleteCharacterPressed = false;
                            }
                            Is_SpaceBarKeyPressed = false;
                            Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);
                            break;
                        }
                    case Keys.Up:
                        {
                            if (!Is_AutoCompleteCharacterPressed)
                            {
                                EnteredString = "";
                                Is_AutoCompleteCharacterPressed = false;
                            }
                            Is_SpaceBarKeyPressed = false;
                            Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);
                            break;
                        }
                    case Keys.Right:
                        {
                            if (!Is_AutoCompleteCharacterPressed)
                            {
                                EnteredString = "";
                                Is_AutoCompleteCharacterPressed = false;
                            }
                            Is_SpaceBarKeyPressed = false;
                            Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);
                            break;
                        }
                    case Keys.Down:
                        {
                            if (!Is_AutoCompleteCharacterPressed)
                            {
                                EnteredString = "";
                                Is_AutoCompleteCharacterPressed = false;
                            }
                            Is_SpaceBarKeyPressed = false;
                            Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);
                            break;
                        }
                }
            }
           
        }

        private void textbox1_keypress(object sender, KeyPressEventArgs e)
        {
          
            string ch = e.KeyChar.ToString();
            ProcessAutoCompleteBrackets(ch);
            if (ch == "<")
            {
                Is_LessThanKeyPressed = true;
                Is_SpaceBarKeyPressed = false;
                EnteredString = "";
            }
            else if (ch == ">")
            {
                if (Is_TagClosedKeyPressed)
                {
                    Is_TagClosedKeyPressed = false;
                }
                else
                {
                    Is_GreaterThanKeyPressed = true;
                    Is_SpaceBarKeyPressed = false;
                    int oldsel = TextBox1.SelectionStart;
                    for (int i = 0; i < (int)tagslist.Length; i++)
                    {
                        if (EnteredString == tagslist[i])
                        {
                            TextBox1.Text = TextBox1.Text.Insert(oldsel,string.Concat(Environment.NewLine,"</", tagslist[i], ">"));
                            TextBox1.SelectionStart = TextBox1.SelectionStart + oldsel;
                            EnteredString = "";
                        }
                    }
                    if(EnteredString=="input")
                    {
                        
                        TextBox1.Text = TextBox1.Text.Insert(oldsel,"/>");
                        TextBox1.SelectionStart = TextBox1.SelectionStart + oldsel;
                        EnteredString = "";
                    }
                   
                    
                    Is_LessThanKeyPressed = false;
                }
            }
            else if (Is_LessThanKeyPressed)
            {
                for (char a = 'a'; a <= 'z'; a = (char)(a + 1))
                {
                    if (a.ToString() == ch)
                    {
                        EnteredString = string.Concat(EnteredString, ch);
                    }
                    else if (a.ToString().ToUpper() == ch)
                    {
                        EnteredString = string.Concat(EnteredString, ch);
                    }
                }
                for (int a = 0; a <= 9; a++)
                {
                    if (a.ToString() == ch)
                    {
                        EnteredString = string.Concat(EnteredString, ch);
                    }
                }
            }
            if (Is_LessThanKeyPressed)
            {
                if (ch == "/")
                {
                    Is_TagClosedKeyPressed = true;
                    Is_SpaceBarKeyPressed = true;
                    EnteredString = "";
                }
            }
       
        }

        private void textbox1_keyup(object sender, KeyEventArgs e)
        {
            autosavelabel.Text = string.Empty;
            if (e.KeyCode == Keys.Back)
            {
                int sel = TextBox1.SelectionStart;
                Point pt = TextBox1.GetPositionFromCharIndex(sel);
                char ch = TextBox1.GetCharFromPosition(pt);
                if (EnteredString.Length > 0)
                {
                    if (ch != '>')
                    {
                        EnteredString = EnteredString.Remove(EnteredString.Length - 1);
                        Is_LessThanKeyPressed = true;
                    }
                }
                if (ch == '<')
                {
                    EnteredString = "";
                }
            }
        }

        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
        }
        private void htmlsave()
        {
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
            TextBox1.Multiline = true;
            if (TextBox1.CanUndo == true)
            {
                undoToolStripMenuItem.Enabled = true;
                undoToolStripMenuItem1.Enabled = true;
            }
            else
            {
                undoToolStripMenuItem.Enabled = false;
                undoToolStripMenuItem1.Enabled = false;
            }
            Linelabel.Text = string.Concat("Line: ", TextBox1.GetLineFromCharIndex(2147483647) + 1, "   Cols: ", TextBox1.Text.Length);

            if (autosaveToolStripMenuItem.Checked)
            {
                if (filepath != null)
                {
                    File.WriteAllText(filepath, TextBox1.Text);
                    autosavelabel.Text = "Saving the text as you are editing...";
                }
            }
            else
            {
                autosavelabel.Text = string.Empty;
            }
            if (TextBox1.Text == string.Empty)
            {
                findToolStripMenuItem.Enabled = false;
                findNextToolStripMenuItem.Enabled = false;
            }
            else
            {
                findNextToolStripMenuItem.Enabled = true;
                findToolStripMenuItem.Enabled = true;
            }
            string temp = TextBox1.Text;
            int wordcount=temp.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            wordcountlabel.Text = "Words : " + wordcount;
            if (ishtmlsave == true && filepath == null)
            {
                if ((temp.StartsWith("<html>") || (temp.StartsWith("<!DOCTYPE html>")) && temp.EndsWith("</html>")))
                {
                    DialogResult dresult = MessageBox.Show("Your file contains HTML Tags. Do you want to save the file as HTML file ?", "Typex Notepad", MessageBoxButtons.YesNo);
                    switch (dresult)
                    {
                        case DialogResult.Yes:
                            saveFileDialog1.Filter = "HyperText Markup Language File(*.html)|*.html";
                            saveFileDialog1.Title = "Save as HTML file";
                            DialogResult saveresult = saveFileDialog1.ShowDialog();
                            if (saveresult == DialogResult.Cancel)
                                ishtmlsave = false;
                            if (saveFileDialog1.FileName != "")
                            {
                                File.WriteAllText(saveFileDialog1.FileName,TextBox1.Text,Encoding.UTF8);
                                filepath = saveFileDialog1.FileName;
                                setTitle();
                                ishtmlsave = false;
                            }
                            break;
                        case DialogResult.No:
                            ishtmlsave = false;
                            break;
                    }
                }

            }
        }

        

        private void TimeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dat = DateTime.Now.ToString("dd/MM/yyyy h:mm tt");
            TextBox1.Paste(dat);
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBox1.Undo();
            TextBox1.ClearUndo();
        }

        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!wordWrapToolStripMenuItem.Checked)
            {
                TextBox1.WordWrap = true;
                wordWrapToolStripMenuItem.Checked = true;
                Settings.Default.wordwrapset = true;
                Settings.Default.Save();
            }
            else
            {
                TextBox1.WordWrap = false;
                wordWrapToolStripMenuItem.Checked = false;
                Settings.Default.wordwrapset = false;
                Settings.Default.Save();
            }
        }

        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i = 2f + TextBox1.Font.Size;
            fonttype = TextBox1.Font.Name;
            TextBox1.Font = new Font(fonttype, i, FontStyle.Regular, GraphicsUnit.Point, 0);
            int zoomstate = (int)(i / (float)origzoom * 100f);
            zoomlabel.Text = string.Concat(zoomstate, "%");
        }

        private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            i = TextBox1.Font.Size - 2f;
            fonttype = TextBox1.Font.Name;
            TextBox1.Font = new Font(fonttype, i, FontStyle.Regular, GraphicsUnit.Point, 0);
            int zoomstate = (int)(i / (float)origzoom * 100f);
            zoomlabel.Text = string.Concat(zoomstate, "%");
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

        private class ContentPosition
        {
            public int LineIndex;

            public int ColumnIndex;

            public ContentPosition()
            {
            }
        }

        private class Renderer : ToolStripProfessionalRenderer
        {
            public Renderer() : base(new Cols())
            {
            }
        }

        private class staRenderer : ToolStripProfessionalRenderer
        {
            public staRenderer() : base(new Statusren())
            {
            }
        }

        private void form1_resizeend(object sender, EventArgs e)
        {

        }
        public bool iscopyret()
        {
            if (iscopy)
            {
                
                return true;
            }
            else
                return false;
            
        }
        public bool iscutret()
        {
            if (iscut)
            {
                
                return true;
            }
            else
                return false;
        }

        private void form1_resizebegin(object sender, EventArgs e)
        {

        }

        private void form1_resize(object sender, EventArgs e)
        {
            Update();
            UpdateBounds();
            UpdateStyles();
        }

       

    public void ClipboardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            clipbd newclip = new clipbd(this);
            newclip.Show();
        }

        private void OCRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocrwindow newocr = new ocrwindow(this);
            newocr.Show();
        }

        private void MemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            memoform newmemo = new memoform(this);
            newmemo.Show();
        }

        private void MetroTextBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void AboutTypexNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about newabout = new about(this);
            newabout.ShowDialog();
        }

        private void menustrip_resize(object sender, EventArgs e)
        {
            menuStrip1.Update();
        }

        private void menustrip_sizechanged(object sender, EventArgs e)
        {
            menuStrip1.Update();
        }

        private void menupanel_sizechanged(object sender, EventArgs e)
        {
            
        }

        private void menupanel_resize(object sender, EventArgs e)
        {
            
        }

        private void toolbox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolbox_mousemove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                toolbox.Location = new Point(
                    (toolbox.Location.X - lastLocation.X) + e.X, (toolbox.Location.Y - lastLocation.Y) + e.Y);

                toolbox.Update();
            }
        }

        private void toolbox_mouseup(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void toolbox_mousedown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void closetoolbut_Click(object sender, EventArgs e)
        {
            toolbox.Hide();
            toolboxtoggle.Checked = false;

        }

        private void toolboxtoggle_Click(object sender, EventArgs e)
        {
            if(toolboxtoggle.Checked==true)
            {
                toolbox.Hide();
                toolboxtoggle.Checked = false;
                Settings.Default.toolboxset = false;
                Settings.Default.Save();
            }
            else
            {
                toolbox.Show();
                toolboxtoggle.Checked = true;
                Settings.Default.toolboxset = true;
                Settings.Default.Save();
            }
        }

        private void cutbuttool_Click(object sender, EventArgs e)
        {
            TextBox1.Cut();
            iscut = true;
            iscopy = false;
        }

        private void cutbuttool_mouseenter(object sender, EventArgs e)
        {
            
        }

        private void cutbuttool_mousehover(object sender, EventArgs e)
        {
            
            

        }

        private void copybuttool_Click(object sender, EventArgs e)
        {
            TextBox1.Copy();
            iscopy = true;
            iscut = false;
        }

        private void pastebuttool_Click(object sender, EventArgs e)
        {
            TextBox1.Paste();
        }

        private void clipboardtool_Click(object sender, EventArgs e)
        {
            clipbd newclip = new clipbd(this);
            newclip.Show();
        }

        private void selectalltool_Click(object sender, EventArgs e)
        {
            TextBox1.SelectAll();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            
        }

        private void form1_shown(object sender, EventArgs e)
        {
            if (Settings.Default.autosaveset == true)
            {
                if (filepath == null)
                {
                    Form3 newform3 = new Form3();
                    newform3.ShowDialog();
                    if (newform3.val == 1)
                    {
                        if (showEncodingOptionsToolStripMenuItem.Checked == true)
                        {
                            encodingselection newenc = new encodingselection(this);
                            newenc.Show();
                        }
                        else
                        {
                            saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                            saveFileDialog1.Title = "Save a text file";
                            saveFileDialog1.ShowDialog();
                            if (saveFileDialog1.FileName != "")
                            {
                                File.WriteAllText(saveFileDialog1.FileName, TextBox1.Text, _encoding);
                                filepath = saveFileDialog1.FileName;
                                setTitle();
                            }
                            if (filepath != null)
                            {
                                setTitle();
                            }
                            
                        }
                        autosaveToolStripMenuItem.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("AutoSave has been disabled since the file was not saved even once !", "Typex Notepad - AutoSave Disabled !", MessageBoxButtons.OK);
                        autosaveToolStripMenuItem.Checked = false;
                        Settings.Default.autosaveset = false;
                        Settings.Default.Save();
                    }
                }
                else
                {
                    autosaveToolStripMenuItem.Checked = true;
                    setTitle();
                }
            }
            else
            {
                autosaveToolStripMenuItem.Checked = false;
                setTitle();
            }
        }

        private void clipBoardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clipbd newclip = new clipbd(this);
            newclip.Show();
        }

       

        private void ShowEncodingOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showEncodingOptionsToolStripMenuItem.Checked = !showEncodingOptionsToolStripMenuItem.Checked;
            Settings.Default.encodingset = showEncodingOptionsToolStripMenuItem.Checked;
            Settings.Default.Save();
        }
    }
}