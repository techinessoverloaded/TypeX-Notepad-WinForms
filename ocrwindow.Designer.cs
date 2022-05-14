namespace Typex_Notepad
{
    partial class ocrwindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ocrwindow));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.browsebut = new System.Windows.Forms.Button();
            this.addbut = new System.Windows.Forms.Button();
            this.closebut = new System.Windows.Forms.Button();
            this.ocrtext = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.detectbut = new System.Windows.Forms.Button();
            this.appendbut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // browsebut
            // 
            this.browsebut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browsebut.Location = new System.Drawing.Point(410, 38);
            this.browsebut.Name = "browsebut";
            this.browsebut.Size = new System.Drawing.Size(75, 23);
            this.browsebut.TabIndex = 0;
            this.browsebut.Text = "Browse";
            this.browsebut.UseVisualStyleBackColor = true;
            this.browsebut.Click += new System.EventHandler(this.Browsebut_Click);
            // 
            // addbut
            // 
            this.addbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbut.Location = new System.Drawing.Point(410, 259);
            this.addbut.Name = "addbut";
            this.addbut.Size = new System.Drawing.Size(106, 23);
            this.addbut.TabIndex = 1;
            this.addbut.Text = "Add to text file";
            this.addbut.UseVisualStyleBackColor = true;
            this.addbut.Click += new System.EventHandler(this.Copybut_Click);
            // 
            // closebut
            // 
            this.closebut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebut.Location = new System.Drawing.Point(441, 414);
            this.closebut.Name = "closebut";
            this.closebut.Size = new System.Drawing.Size(75, 23);
            this.closebut.TabIndex = 2;
            this.closebut.Text = "Close";
            this.closebut.UseVisualStyleBackColor = true;
            this.closebut.Click += new System.EventHandler(this.Closebut_Click);
            // 
            // ocrtext
            // 
            this.ocrtext.Location = new System.Drawing.Point(12, 259);
            this.ocrtext.Multiline = true;
            this.ocrtext.Name = "ocrtext";
            this.ocrtext.ReadOnly = true;
            this.ocrtext.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ocrtext.Size = new System.Drawing.Size(392, 178);
            this.ocrtext.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.picturebox_dragdrop);
            this.pictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.picturebox_dragenter);
            // 
            // openlabel
            // 
            this.openlabel.AutoSize = true;
            this.openlabel.Location = new System.Drawing.Point(12, 22);
            this.openlabel.Name = "openlabel";
            this.openlabel.Size = new System.Drawing.Size(201, 13);
            this.openlabel.TabIndex = 5;
            this.openlabel.Text = "Drag and drop image or browse for image";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Result";
            // 
            // detectbut
            // 
            this.detectbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detectbut.Location = new System.Drawing.Point(410, 67);
            this.detectbut.Name = "detectbut";
            this.detectbut.Size = new System.Drawing.Size(75, 23);
            this.detectbut.TabIndex = 7;
            this.detectbut.Text = "Detect Text";
            this.detectbut.UseVisualStyleBackColor = true;
            this.detectbut.Click += new System.EventHandler(this.Detectbut_Click);
            // 
            // appendbut
            // 
            this.appendbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.appendbut.Location = new System.Drawing.Point(410, 288);
            this.appendbut.Name = "appendbut";
            this.appendbut.Size = new System.Drawing.Size(106, 23);
            this.appendbut.TabIndex = 8;
            this.appendbut.Text = "Append to text file";
            this.appendbut.UseVisualStyleBackColor = true;
            this.appendbut.Click += new System.EventHandler(this.Appendbut_Click);
            // 
            // ocrwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 449);
            this.Controls.Add(this.appendbut);
            this.Controls.Add(this.detectbut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openlabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ocrtext);
            this.Controls.Add(this.closebut);
            this.Controls.Add(this.addbut);
            this.Controls.Add(this.browsebut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ocrwindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OCR - Typex Notepad";
            this.Load += new System.EventHandler(this.Ocrwindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button browsebut;
        private System.Windows.Forms.Button addbut;
        private System.Windows.Forms.Button closebut;
        private System.Windows.Forms.TextBox ocrtext;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label openlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button detectbut;
        private System.Windows.Forms.Button appendbut;
    }
}