namespace Typex_Notepad
{
    partial class encodingselection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(encodingselection));
            this.label1 = new System.Windows.Forms.Label();
            this.controlEncodingComboBox = new System.Windows.Forms.ComboBox();
            this.okbut = new System.Windows.Forms.Button();
            this.cancelbut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encoding :";
            // 
            // controlEncodingComboBox
            // 
            this.controlEncodingComboBox.FormattingEnabled = true;
            this.controlEncodingComboBox.Location = new System.Drawing.Point(72, 24);
            this.controlEncodingComboBox.Name = "controlEncodingComboBox";
            this.controlEncodingComboBox.Size = new System.Drawing.Size(218, 21);
            this.controlEncodingComboBox.TabIndex = 1;
            this.controlEncodingComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // okbut
            // 
            this.okbut.Location = new System.Drawing.Point(82, 73);
            this.okbut.Name = "okbut";
            this.okbut.Size = new System.Drawing.Size(76, 25);
            this.okbut.TabIndex = 2;
            this.okbut.Text = "OK";
            this.okbut.UseVisualStyleBackColor = true;
            this.okbut.Click += new System.EventHandler(this.okbut_Click);
            // 
            // cancelbut
            // 
            this.cancelbut.Location = new System.Drawing.Point(171, 73);
            this.cancelbut.Name = "cancelbut";
            this.cancelbut.Size = new System.Drawing.Size(76, 25);
            this.cancelbut.TabIndex = 3;
            this.cancelbut.Text = "Cancel";
            this.cancelbut.UseVisualStyleBackColor = true;
            this.cancelbut.Click += new System.EventHandler(this.cancelbut_Click);
            // 
            // encodingselection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 108);
            this.Controls.Add(this.cancelbut);
            this.Controls.Add(this.okbut);
            this.Controls.Add(this.controlEncodingComboBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "encodingselection";
            this.Text = "Select/Change Encoding";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.enoding_formclosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.encoding_formclosed);
            this.Load += new System.EventHandler(this.encodingselection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox controlEncodingComboBox;
        private System.Windows.Forms.Button okbut;
        private System.Windows.Forms.Button cancelbut;
    }
}