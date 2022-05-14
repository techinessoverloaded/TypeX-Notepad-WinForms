namespace Typex_Notepad
{
    partial class memoform
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(memoform));
            this.addbut = new System.Windows.Forms.Button();
            this.delbut = new System.Windows.Forms.Button();
            this.genqr = new System.Windows.Forms.Button();
            this.scanqr = new System.Windows.Forms.Button();
            this.exitbut = new System.Windows.Forms.Button();
            this.mainpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.qrpanel = new System.Windows.Forms.Panel();
            this.bothlabel = new System.Windows.Forms.Label();
            this.webcamlabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.genqrlabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Openwebcambut = new System.Windows.Forms.Button();
            this.backpanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveallbut = new System.Windows.Forms.Button();
            this.datebut = new System.Windows.Forms.Button();
            this.addtotextbut = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMemoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateQRCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qrpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.backpanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addbut
            // 
            this.addbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addbut.Location = new System.Drawing.Point(4, 3);
            this.addbut.Name = "addbut";
            this.addbut.Size = new System.Drawing.Size(39, 37);
            this.addbut.TabIndex = 0;
            this.addbut.Text = "New";
            this.addbut.UseVisualStyleBackColor = true;
            this.addbut.Click += new System.EventHandler(this.Button1_Click);
            // 
            // delbut
            // 
            this.delbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delbut.Location = new System.Drawing.Point(273, 3);
            this.delbut.Name = "delbut";
            this.delbut.Size = new System.Drawing.Size(51, 37);
            this.delbut.TabIndex = 1;
            this.delbut.Text = "Delete";
            this.delbut.UseVisualStyleBackColor = true;
            this.delbut.Click += new System.EventHandler(this.Delbut_Click);
            // 
            // genqr
            // 
            this.genqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.genqr.Location = new System.Drawing.Point(330, 3);
            this.genqr.Name = "genqr";
            this.genqr.Size = new System.Drawing.Size(112, 37);
            this.genqr.TabIndex = 2;
            this.genqr.Text = "Generate QR Code";
            this.genqr.UseVisualStyleBackColor = true;
            this.genqr.Click += new System.EventHandler(this.Genqr_Click);
            // 
            // scanqr
            // 
            this.scanqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scanqr.Location = new System.Drawing.Point(672, 3);
            this.scanqr.Name = "scanqr";
            this.scanqr.Size = new System.Drawing.Size(123, 37);
            this.scanqr.TabIndex = 3;
            this.scanqr.Text = "Add from QR Code";
            this.scanqr.UseVisualStyleBackColor = true;
            this.scanqr.Click += new System.EventHandler(this.Scanqr_Click);
            // 
            // exitbut
            // 
            this.exitbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbut.Location = new System.Drawing.Point(801, 3);
            this.exitbut.Name = "exitbut";
            this.exitbut.Size = new System.Drawing.Size(37, 37);
            this.exitbut.TabIndex = 4;
            this.exitbut.Text = "Exit";
            this.exitbut.UseVisualStyleBackColor = true;
            this.exitbut.Click += new System.EventHandler(this.Exitbut_Click);
            // 
            // mainpanel
            // 
            this.mainpanel.AllowDrop = true;
            this.mainpanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mainpanel.AutoSize = true;
            this.mainpanel.Location = new System.Drawing.Point(3, 3);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(407, 402);
            this.mainpanel.TabIndex = 5;
            this.mainpanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.mainpanel_dragdrop);
            this.mainpanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.mainpanel_dragenter);
            // 
            // qrpanel
            // 
            this.qrpanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.qrpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.qrpanel.Controls.Add(this.bothlabel);
            this.qrpanel.Controls.Add(this.webcamlabel);
            this.qrpanel.Controls.Add(this.pictureBox1);
            this.qrpanel.Controls.Add(this.genqrlabel);
            this.qrpanel.Location = new System.Drawing.Point(419, 42);
            this.qrpanel.Name = "qrpanel";
            this.qrpanel.Size = new System.Drawing.Size(424, 407);
            this.qrpanel.TabIndex = 7;
            // 
            // bothlabel
            // 
            this.bothlabel.AutoSize = true;
            this.bothlabel.Location = new System.Drawing.Point(3, 6);
            this.bothlabel.Name = "bothlabel";
            this.bothlabel.Size = new System.Drawing.Size(99, 13);
            this.bothlabel.TabIndex = 3;
            this.bothlabel.Text = "Webcam/QR Code";
            // 
            // webcamlabel
            // 
            this.webcamlabel.AutoSize = true;
            this.webcamlabel.Location = new System.Drawing.Point(3, 6);
            this.webcamlabel.Name = "webcamlabel";
            this.webcamlabel.Size = new System.Drawing.Size(50, 13);
            this.webcamlabel.TabIndex = 2;
            this.webcamlabel.Text = "Webcam";
            this.webcamlabel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(415, 373);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // genqrlabel
            // 
            this.genqrlabel.AutoSize = true;
            this.genqrlabel.Location = new System.Drawing.Point(3, 6);
            this.genqrlabel.Name = "genqrlabel";
            this.genqrlabel.Size = new System.Drawing.Size(104, 13);
            this.genqrlabel.TabIndex = 0;
            this.genqrlabel.Text = "Generated QR Code";
            this.genqrlabel.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Openwebcambut
            // 
            this.Openwebcambut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Openwebcambut.Location = new System.Drawing.Point(448, 3);
            this.Openwebcambut.Name = "Openwebcambut";
            this.Openwebcambut.Size = new System.Drawing.Size(89, 37);
            this.Openwebcambut.TabIndex = 8;
            this.Openwebcambut.Text = "Open Webcam";
            this.Openwebcambut.UseVisualStyleBackColor = true;
            this.Openwebcambut.Click += new System.EventHandler(this.Openwebcambut_Click);
            // 
            // backpanel
            // 
            this.backpanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.backpanel.AutoScroll = true;
            this.backpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backpanel.Controls.Add(this.mainpanel);
            this.backpanel.Location = new System.Drawing.Point(0, 42);
            this.backpanel.Name = "backpanel";
            this.backpanel.Size = new System.Drawing.Size(413, 407);
            this.backpanel.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(543, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 37);
            this.button1.TabIndex = 11;
            this.button1.Text = "Browse for QR Code";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // saveallbut
            // 
            this.saveallbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveallbut.Location = new System.Drawing.Point(204, 3);
            this.saveallbut.Name = "saveallbut";
            this.saveallbut.Size = new System.Drawing.Size(63, 37);
            this.saveallbut.TabIndex = 12;
            this.saveallbut.Text = "Save All";
            this.saveallbut.UseVisualStyleBackColor = true;
            this.saveallbut.Click += new System.EventHandler(this.Saveallbut_Click);
            // 
            // datebut
            // 
            this.datebut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.datebut.Location = new System.Drawing.Point(130, 3);
            this.datebut.Name = "datebut";
            this.datebut.Size = new System.Drawing.Size(68, 37);
            this.datebut.TabIndex = 13;
            this.datebut.Text = "Date/Time";
            this.datebut.UseVisualStyleBackColor = true;
            this.datebut.Click += new System.EventHandler(this.datebut_Click);
            // 
            // addtotextbut
            // 
            this.addtotextbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addtotextbut.Location = new System.Drawing.Point(49, 3);
            this.addtotextbut.Name = "addtotextbut";
            this.addtotextbut.Size = new System.Drawing.Size(75, 37);
            this.addtotextbut.TabIndex = 14;
            this.addtotextbut.Text = "Add to Text File";
            this.addtotextbut.UseVisualStyleBackColor = true;
            this.addtotextbut.Click += new System.EventHandler(this.Addtotextbut_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateTimeToolStripMenuItem,
            this.saveChangesToolStripMenuItem,
            this.deleteMemoToolStripMenuItem,
            this.generateQRCodeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // saveChangesToolStripMenuItem
            // 
            this.saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            this.saveChangesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveChangesToolStripMenuItem.Text = "Save changes";
            this.saveChangesToolStripMenuItem.Click += new System.EventHandler(this.saveChangesToolStripMenuItem_Click);
            // 
            // deleteMemoToolStripMenuItem
            // 
            this.deleteMemoToolStripMenuItem.Name = "deleteMemoToolStripMenuItem";
            this.deleteMemoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteMemoToolStripMenuItem.Text = "Delete memo";
            this.deleteMemoToolStripMenuItem.Click += new System.EventHandler(this.deleteMemoToolStripMenuItem_Click);
            // 
            // generateQRCodeToolStripMenuItem
            // 
            this.generateQRCodeToolStripMenuItem.Name = "generateQRCodeToolStripMenuItem";
            this.generateQRCodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generateQRCodeToolStripMenuItem.Text = "Generate QR Code";
            this.generateQRCodeToolStripMenuItem.Click += new System.EventHandler(this.generateQRCodeToolStripMenuItem_Click);
            // 
            // dateTimeToolStripMenuItem
            // 
            this.dateTimeToolStripMenuItem.Name = "dateTimeToolStripMenuItem";
            this.dateTimeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dateTimeToolStripMenuItem.Text = "Date/Time";
            this.dateTimeToolStripMenuItem.Click += new System.EventHandler(this.dateTimeToolStripMenuItem_Click);
            // 
            // memoform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 450);
            this.Controls.Add(this.addtotextbut);
            this.Controls.Add(this.datebut);
            this.Controls.Add(this.saveallbut);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.backpanel);
            this.Controls.Add(this.Openwebcambut);
            this.Controls.Add(this.qrpanel);
            this.Controls.Add(this.exitbut);
            this.Controls.Add(this.scanqr);
            this.Controls.Add(this.genqr);
            this.Controls.Add(this.delbut);
            this.Controls.Add(this.addbut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "memoform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Typex Memo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Memoform_FormClosing);
            this.Load += new System.EventHandler(this.Memoform_Load);
            this.qrpanel.ResumeLayout(false);
            this.qrpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.backpanel.ResumeLayout(false);
            this.backpanel.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addbut;
        private System.Windows.Forms.Button delbut;
        private System.Windows.Forms.Button genqr;
        private System.Windows.Forms.Button scanqr;
        private System.Windows.Forms.Button exitbut;
        private System.Windows.Forms.FlowLayoutPanel mainpanel;
        private System.Windows.Forms.Panel qrpanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label genqrlabel;
        private System.Windows.Forms.Label webcamlabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Openwebcambut;
        private System.Windows.Forms.Panel backpanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button saveallbut;
        private System.Windows.Forms.Button datebut;
        private System.Windows.Forms.Label bothlabel;
        private System.Windows.Forms.Button addtotextbut;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMemoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateQRCodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateTimeToolStripMenuItem;
    }
}