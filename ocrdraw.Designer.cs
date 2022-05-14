namespace Typex_Notepad
{
    partial class ocrdraw
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ocrdraw));
            this.newbut = new System.Windows.Forms.Button();
            this.savebut = new System.Windows.Forms.Button();
            this.detbut = new System.Windows.Forms.Button();
            this.exitbut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.erasebut = new System.Windows.Forms.RadioButton();
            this.drawbut = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // newbut
            // 
            this.newbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newbut.Location = new System.Drawing.Point(6, 19);
            this.newbut.Name = "newbut";
            this.newbut.Size = new System.Drawing.Size(41, 23);
            this.newbut.TabIndex = 0;
            this.newbut.Text = "New";
            this.newbut.UseVisualStyleBackColor = true;
            this.newbut.Click += new System.EventHandler(this.Newbut_Click);
            // 
            // savebut
            // 
            this.savebut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.savebut.Location = new System.Drawing.Point(53, 19);
            this.savebut.Name = "savebut";
            this.savebut.Size = new System.Drawing.Size(43, 23);
            this.savebut.TabIndex = 1;
            this.savebut.Text = "Save";
            this.savebut.UseVisualStyleBackColor = true;
            this.savebut.Click += new System.EventHandler(this.Savebut_Click);
            // 
            // detbut
            // 
            this.detbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detbut.Location = new System.Drawing.Point(401, 19);
            this.detbut.Name = "detbut";
            this.detbut.Size = new System.Drawing.Size(75, 23);
            this.detbut.TabIndex = 2;
            this.detbut.Text = "Detect Text";
            this.detbut.UseVisualStyleBackColor = true;
            // 
            // exitbut
            // 
            this.exitbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbut.Location = new System.Drawing.Point(482, 19);
            this.exitbut.Name = "exitbut";
            this.exitbut.Size = new System.Drawing.Size(75, 23);
            this.exitbut.TabIndex = 3;
            this.exitbut.Text = "Exit";
            this.exitbut.UseVisualStyleBackColor = true;
            this.exitbut.Click += new System.EventHandler(this.Exitbut_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.erasebut);
            this.groupBox1.Controls.Add(this.drawbut);
            this.groupBox1.Controls.Add(this.newbut);
            this.groupBox1.Controls.Add(this.exitbut);
            this.groupBox1.Controls.Add(this.savebut);
            this.groupBox1.Controls.Add(this.detbut);
            this.groupBox1.Location = new System.Drawing.Point(1, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 55);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            this.groupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
            // 
            // erasebut
            // 
            this.erasebut.AutoSize = true;
            this.erasebut.Location = new System.Drawing.Point(158, 22);
            this.erasebut.Name = "erasebut";
            this.erasebut.Size = new System.Drawing.Size(52, 17);
            this.erasebut.TabIndex = 5;
            this.erasebut.Text = "Erase";
            this.erasebut.UseVisualStyleBackColor = true;
            this.erasebut.CheckedChanged += new System.EventHandler(this.erasebut_checkchanged);
            this.erasebut.Click += new System.EventHandler(this.Erasebut_Click);
            // 
            // drawbut
            // 
            this.drawbut.AutoSize = true;
            this.drawbut.Checked = true;
            this.drawbut.Location = new System.Drawing.Point(102, 22);
            this.drawbut.Name = "drawbut";
            this.drawbut.Size = new System.Drawing.Size(50, 17);
            this.drawbut.TabIndex = 4;
            this.drawbut.TabStop = true;
            this.drawbut.Text = "Draw";
            this.drawbut.UseVisualStyleBackColor = true;
            this.drawbut.CheckedChanged += new System.EventHandler(this.Drawbut_CheckedChanged);
            this.drawbut.Click += new System.EventHandler(this.drawbut_click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(1, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 238);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_mousedown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_mousemove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_mouseup);
            // 
            // ocrdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(566, 300);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ocrdraw";
            this.Text = "OCR Handwriting Mode - Typex Notepad";
            this.Load += new System.EventHandler(this.Ocrdraw_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ocrdraw_mousedown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ocrdraw_mousemove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ocrdraw_mouseup);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newbut;
        private System.Windows.Forms.Button savebut;
        private System.Windows.Forms.Button detbut;
        private System.Windows.Forms.Button exitbut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton erasebut;
        private System.Windows.Forms.RadioButton drawbut;
    }
}