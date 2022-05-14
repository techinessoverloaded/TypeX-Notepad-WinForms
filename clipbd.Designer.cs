namespace Typex_Notepad
{
    partial class clipbd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(clipbd));
            this.copybut = new System.Windows.Forms.Button();
            this.closebut = new System.Windows.Forms.Button();
            this.selectallbut = new System.Windows.Forms.Button();
            this.clearbut = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // copybut
            // 
            this.copybut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copybut.Location = new System.Drawing.Point(167, 160);
            this.copybut.Name = "copybut";
            this.copybut.Size = new System.Drawing.Size(75, 23);
            this.copybut.TabIndex = 1;
            this.copybut.Text = "Copy";
            this.copybut.UseVisualStyleBackColor = true;
            this.copybut.Click += new System.EventHandler(this.Button1_Click);
            // 
            // closebut
            // 
            this.closebut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closebut.Location = new System.Drawing.Point(248, 160);
            this.closebut.Name = "closebut";
            this.closebut.Size = new System.Drawing.Size(75, 23);
            this.closebut.TabIndex = 2;
            this.closebut.Text = "Close";
            this.closebut.UseVisualStyleBackColor = true;
            this.closebut.Click += new System.EventHandler(this.Closebut_Click);
            // 
            // selectallbut
            // 
            this.selectallbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectallbut.Location = new System.Drawing.Point(86, 160);
            this.selectallbut.Name = "selectallbut";
            this.selectallbut.Size = new System.Drawing.Size(75, 23);
            this.selectallbut.TabIndex = 3;
            this.selectallbut.Text = "Select All";
            this.selectallbut.UseVisualStyleBackColor = true;
            this.selectallbut.Click += new System.EventHandler(this.Selectallbut_Click);
            // 
            // clearbut
            // 
            this.clearbut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearbut.Location = new System.Drawing.Point(5, 160);
            this.clearbut.Name = "clearbut";
            this.clearbut.Size = new System.Drawing.Size(75, 23);
            this.clearbut.TabIndex = 4;
            this.clearbut.Text = "Clear";
            this.clearbut.UseVisualStyleBackColor = true;
            this.clearbut.Click += new System.EventHandler(this.Clearbut_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_tick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(5, 5);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(318, 147);
            this.listBox1.TabIndex = 5;
            // 
            // clipbd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 193);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.clearbut);
            this.Controls.Add(this.selectallbut);
            this.Controls.Add(this.closebut);
            this.Controls.Add(this.copybut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "clipbd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clipboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.clipbd_close);
            this.Load += new System.EventHandler(this.Clipbd_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button copybut;
        private System.Windows.Forms.Button closebut;
        private System.Windows.Forms.Button selectallbut;
        private System.Windows.Forms.Button clearbut;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ListBox listBox1;
    }
}