namespace ClipboardBasket
{
    partial class Form1
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
            this.txtClpbrd = new System.Windows.Forms.TextBox();
            this.btnGetClipBoardText = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtClpbrd
            // 
            this.txtClpbrd.Location = new System.Drawing.Point(24, 27);
            this.txtClpbrd.Multiline = true;
            this.txtClpbrd.Name = "txtClpbrd";
            this.txtClpbrd.Size = new System.Drawing.Size(236, 140);
            this.txtClpbrd.TabIndex = 0;
            // 
            // btnGetClipBoardText
            // 
            this.btnGetClipBoardText.Location = new System.Drawing.Point(83, 173);
            this.btnGetClipBoardText.Name = "btnGetClipBoardText";
            this.btnGetClipBoardText.Size = new System.Drawing.Size(109, 23);
            this.btnGetClipBoardText.TabIndex = 1;
            this.btnGetClipBoardText.Text = "Get Clipboard";
            this.btnGetClipBoardText.UseVisualStyleBackColor = true;
            this.btnGetClipBoardText.Click += new System.EventHandler(this.btnGetClipBoardText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnGetClipBoardText);
            this.Controls.Add(this.txtClpbrd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClpbrd;
        private System.Windows.Forms.Button btnGetClipBoardText;
    }
}

