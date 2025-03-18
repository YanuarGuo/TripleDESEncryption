namespace TripleDESEncryption
{
    partial class TripleDESEncryption
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnEncrypt = new Button();
            BtnDecrypt = new Button();
            TxtPlain = new TextBox();
            TxtCipher = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // BtnEncrypt
            // 
            BtnEncrypt.Location = new Point(264, 129);
            BtnEncrypt.Name = "BtnEncrypt";
            BtnEncrypt.Size = new Size(75, 23);
            BtnEncrypt.TabIndex = 0;
            BtnEncrypt.Text = "Encrypt";
            BtnEncrypt.UseVisualStyleBackColor = true;
            BtnEncrypt.Click += BtnEncrypt_Click;
            // 
            // BtnDecrypt
            // 
            BtnDecrypt.Location = new Point(183, 129);
            BtnDecrypt.Name = "BtnDecrypt";
            BtnDecrypt.Size = new Size(75, 23);
            BtnDecrypt.TabIndex = 1;
            BtnDecrypt.Text = "Decrypt";
            BtnDecrypt.UseVisualStyleBackColor = true;
            BtnDecrypt.Click += BtnDecrypt_Click;
            // 
            // TxtPlain
            // 
            TxtPlain.Location = new Point(12, 37);
            TxtPlain.Name = "TxtPlain";
            TxtPlain.Size = new Size(327, 23);
            TxtPlain.TabIndex = 2;
            // 
            // TxtCipher
            // 
            TxtCipher.Location = new Point(12, 90);
            TxtCipher.Name = "TxtCipher";
            TxtCipher.Size = new Size(327, 23);
            TxtCipher.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Plain Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 72);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 5;
            label2.Text = "Cipher Text";
            // 
            // TripleDESEncryption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(351, 168);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TxtCipher);
            Controls.Add(TxtPlain);
            Controls.Add(BtnDecrypt);
            Controls.Add(BtnEncrypt);
            Name = "TripleDESEncryption";
            Text = "TripleDESEncryption";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnEncrypt;
        private Button BtnDecrypt;
        private TextBox TxtPlain;
        private TextBox TxtCipher;
        private Label label1;
        private Label label2;
    }
}
