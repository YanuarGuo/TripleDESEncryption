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
            GbConfig = new GroupBox();
            BtnConfirmAll = new Button();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            CbMode3DES = new ComboBox();
            label5 = new Label();
            CbCipherMode = new ComboBox();
            CbPadding = new ComboBox();
            TxtKey3 = new TextBox();
            TxtKey2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            TxtKey1 = new TextBox();
            GbEnc = new GroupBox();
            BtnClearEnc = new Button();
            label9 = new Label();
            CbOutFormat = new ComboBox();
            label7 = new Label();
            TxtIVEnc = new TextBox();
            GbDec = new GroupBox();
            BtnClearDec = new Button();
            label10 = new Label();
            CbInFormat = new ComboBox();
            label8 = new Label();
            TxtIVDec = new TextBox();
            GbConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            GbEnc.SuspendLayout();
            GbDec.SuspendLayout();
            SuspendLayout();
            // 
            // BtnEncrypt
            // 
            BtnEncrypt.Location = new Point(106, 264);
            BtnEncrypt.Name = "BtnEncrypt";
            BtnEncrypt.Size = new Size(89, 23);
            BtnEncrypt.TabIndex = 11;
            BtnEncrypt.Text = "Encrypt";
            BtnEncrypt.UseVisualStyleBackColor = true;
            BtnEncrypt.Click += BtnEncrypt_Click;
            // 
            // BtnDecrypt
            // 
            BtnDecrypt.Location = new Point(106, 264);
            BtnDecrypt.Name = "BtnDecrypt";
            BtnDecrypt.Size = new Size(89, 23);
            BtnDecrypt.TabIndex = 15;
            BtnDecrypt.Text = "Decrypt";
            BtnDecrypt.UseVisualStyleBackColor = true;
            BtnDecrypt.Click += BtnDecrypt_Click;
            // 
            // TxtPlain
            // 
            TxtPlain.Location = new Point(12, 49);
            TxtPlain.Multiline = true;
            TxtPlain.Name = "TxtPlain";
            TxtPlain.Size = new Size(183, 102);
            TxtPlain.TabIndex = 8;
            // 
            // TxtCipher
            // 
            TxtCipher.Location = new Point(12, 49);
            TxtCipher.Multiline = true;
            TxtCipher.Name = "TxtCipher";
            TxtCipher.Size = new Size(183, 102);
            TxtCipher.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 4;
            label1.Text = "Plain Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 31);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 5;
            label2.Text = "Cipher Text";
            // 
            // GbConfig
            // 
            GbConfig.Controls.Add(BtnConfirmAll);
            GbConfig.Controls.Add(pictureBox1);
            GbConfig.Controls.Add(label6);
            GbConfig.Controls.Add(CbMode3DES);
            GbConfig.Controls.Add(label5);
            GbConfig.Controls.Add(CbCipherMode);
            GbConfig.Controls.Add(CbPadding);
            GbConfig.Controls.Add(TxtKey3);
            GbConfig.Controls.Add(TxtKey2);
            GbConfig.Controls.Add(label4);
            GbConfig.Controls.Add(label3);
            GbConfig.Controls.Add(TxtKey1);
            GbConfig.Location = new Point(12, 12);
            GbConfig.Name = "GbConfig";
            GbConfig.Size = new Size(429, 230);
            GbConfig.TabIndex = 6;
            GbConfig.TabStop = false;
            GbConfig.Text = "Triple DES Configuration";
            // 
            // BtnConfirmAll
            // 
            BtnConfirmAll.Location = new Point(341, 188);
            BtnConfirmAll.Name = "BtnConfirmAll";
            BtnConfirmAll.Size = new Size(75, 23);
            BtnConfirmAll.TabIndex = 7;
            BtnConfirmAll.Text = "Confirm";
            BtnConfirmAll.UseVisualStyleBackColor = true;
            BtnConfirmAll.Click += BtnConfirmAll_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(26, 61);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(377, 1);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 25);
            label6.Name = "label6";
            label6.Size = new Size(67, 15);
            label6.TabIndex = 16;
            label6.Text = "TDES Mode";
            // 
            // CbMode3DES
            // 
            CbMode3DES.DropDownStyle = ComboBoxStyle.DropDownList;
            CbMode3DES.FormattingEnabled = true;
            CbMode3DES.Items.AddRange(new object[] { "TDES-168", "TDES-112" });
            CbMode3DES.Location = new Point(93, 22);
            CbMode3DES.Name = "CbMode3DES";
            CbMode3DES.Size = new Size(323, 23);
            CbMode3DES.TabIndex = 1;
            CbMode3DES.SelectedIndexChanged += CbMode3DES_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 78);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 14;
            label5.Text = "Keys";
            // 
            // CbCipherMode
            // 
            CbCipherMode.DropDownStyle = ComboBoxStyle.DropDownList;
            CbCipherMode.FormattingEnabled = true;
            CbCipherMode.Items.AddRange(new object[] { "CBC", "ECB" });
            CbCipherMode.Location = new Point(220, 149);
            CbCipherMode.Name = "CbCipherMode";
            CbCipherMode.Size = new Size(196, 23);
            CbCipherMode.TabIndex = 6;
            // 
            // CbPadding
            // 
            CbPadding.DropDownStyle = ComboBoxStyle.DropDownList;
            CbPadding.FormattingEnabled = true;
            CbPadding.Items.AddRange(new object[] { "PKCS7", "ZeroPadding" });
            CbPadding.Location = new Point(12, 149);
            CbPadding.Name = "CbPadding";
            CbPadding.Size = new Size(196, 23);
            CbPadding.TabIndex = 5;
            // 
            // TxtKey3
            // 
            TxtKey3.Location = new Point(291, 96);
            TxtKey3.MaxLength = 8;
            TxtKey3.Name = "TxtKey3";
            TxtKey3.Size = new Size(125, 23);
            TxtKey3.TabIndex = 4;
            // 
            // TxtKey2
            // 
            TxtKey2.Location = new Point(152, 96);
            TxtKey2.MaxLength = 8;
            TxtKey2.Name = "TxtKey2";
            TxtKey2.Size = new Size(125, 23);
            TxtKey2.TabIndex = 3;
            TxtKey2.TextChanged += TxtKey2_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(227, 131);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 9;
            label4.Text = "Cipher Mode";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 131);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Padding";
            // 
            // TxtKey1
            // 
            TxtKey1.Location = new Point(12, 96);
            TxtKey1.MaxLength = 8;
            TxtKey1.Name = "TxtKey1";
            TxtKey1.Size = new Size(125, 23);
            TxtKey1.TabIndex = 2;
            TxtKey1.TextChanged += TxtKey1_TextChanged;
            // 
            // GbEnc
            // 
            GbEnc.Controls.Add(BtnClearEnc);
            GbEnc.Controls.Add(label9);
            GbEnc.Controls.Add(CbOutFormat);
            GbEnc.Controls.Add(label7);
            GbEnc.Controls.Add(TxtIVEnc);
            GbEnc.Controls.Add(TxtPlain);
            GbEnc.Controls.Add(label1);
            GbEnc.Controls.Add(BtnEncrypt);
            GbEnc.Location = new Point(12, 248);
            GbEnc.Name = "GbEnc";
            GbEnc.Size = new Size(208, 303);
            GbEnc.TabIndex = 7;
            GbEnc.TabStop = false;
            GbEnc.Text = "Encryption";
            // 
            // BtnClearEnc
            // 
            BtnClearEnc.Location = new Point(12, 264);
            BtnClearEnc.Name = "BtnClearEnc";
            BtnClearEnc.Size = new Size(89, 23);
            BtnClearEnc.TabIndex = 15;
            BtnClearEnc.Text = "Clear";
            BtnClearEnc.UseVisualStyleBackColor = true;
            BtnClearEnc.Click += BtnClearEnc_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 212);
            label9.Name = "label9";
            label9.Size = new Size(86, 15);
            label9.TabIndex = 14;
            label9.Text = "Output Format";
            // 
            // CbOutFormat
            // 
            CbOutFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            CbOutFormat.FormattingEnabled = true;
            CbOutFormat.Items.AddRange(new object[] { "Base64", "HEX" });
            CbOutFormat.Location = new Point(12, 230);
            CbOutFormat.Name = "CbOutFormat";
            CbOutFormat.Size = new Size(183, 23);
            CbOutFormat.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 159);
            label7.Name = "label7";
            label7.Size = new Size(107, 15);
            label7.TabIndex = 9;
            label7.Text = "Initialization Vector";
            // 
            // TxtIVEnc
            // 
            TxtIVEnc.Location = new Point(12, 177);
            TxtIVEnc.MaxLength = 8;
            TxtIVEnc.Name = "TxtIVEnc";
            TxtIVEnc.Size = new Size(183, 23);
            TxtIVEnc.TabIndex = 9;
            // 
            // GbDec
            // 
            GbDec.Controls.Add(BtnClearDec);
            GbDec.Controls.Add(label10);
            GbDec.Controls.Add(CbInFormat);
            GbDec.Controls.Add(label8);
            GbDec.Controls.Add(TxtIVDec);
            GbDec.Controls.Add(TxtCipher);
            GbDec.Controls.Add(label2);
            GbDec.Controls.Add(BtnDecrypt);
            GbDec.Location = new Point(233, 248);
            GbDec.Name = "GbDec";
            GbDec.Size = new Size(208, 303);
            GbDec.TabIndex = 5;
            GbDec.TabStop = false;
            GbDec.Text = "Decryption";
            // 
            // BtnClearDec
            // 
            BtnClearDec.Location = new Point(13, 264);
            BtnClearDec.Name = "BtnClearDec";
            BtnClearDec.Size = new Size(89, 23);
            BtnClearDec.TabIndex = 16;
            BtnClearDec.Text = "Clear";
            BtnClearDec.UseVisualStyleBackColor = true;
            BtnClearDec.Click += BtnClearDec_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 212);
            label10.Name = "label10";
            label10.Size = new Size(76, 15);
            label10.TabIndex = 15;
            label10.Text = "Input Format";
            // 
            // CbInFormat
            // 
            CbInFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            CbInFormat.FormattingEnabled = true;
            CbInFormat.Items.AddRange(new object[] { "Base64", "HEX" });
            CbInFormat.Location = new Point(12, 230);
            CbInFormat.Name = "CbInFormat";
            CbInFormat.Size = new Size(183, 23);
            CbInFormat.TabIndex = 14;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 159);
            label8.Name = "label8";
            label8.Size = new Size(107, 15);
            label8.TabIndex = 11;
            label8.Text = "Initialization Vector";
            // 
            // TxtIVDec
            // 
            TxtIVDec.Location = new Point(12, 177);
            TxtIVDec.MaxLength = 8;
            TxtIVDec.Name = "TxtIVDec";
            TxtIVDec.Size = new Size(183, 23);
            TxtIVDec.TabIndex = 13;
            // 
            // TripleDESEncryption
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 564);
            Controls.Add(GbDec);
            Controls.Add(GbEnc);
            Controls.Add(GbConfig);
            Name = "TripleDESEncryption";
            Text = "TripleDESEncryption";
            GbConfig.ResumeLayout(false);
            GbConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            GbEnc.ResumeLayout(false);
            GbEnc.PerformLayout();
            GbDec.ResumeLayout(false);
            GbDec.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BtnEncrypt;
        private Button BtnDecrypt;
        private TextBox TxtPlain;
        private TextBox TxtCipher;
        private Label label1;
        private Label label2;
        private GroupBox GbConfig;
        private Label label4;
        private Label label3;
        private TextBox TxtKey1;
        private Label label6;
        private ComboBox CbMode3DES;
        private Label label5;
        private ComboBox CbCipherMode;
        private ComboBox CbPadding;
        private TextBox TxtKey3;
        private TextBox TxtKey2;
        private PictureBox pictureBox1;
        private Button BtnConfirmAll;
        private GroupBox GbEnc;
        private GroupBox GbDec;
        private Label label7;
        private TextBox TxtIVEnc;
        private Label label9;
        private ComboBox CbOutFormat;
        private Label label10;
        private ComboBox CbInFormat;
        private Label label8;
        private TextBox TxtIVDec;
        private Button BtnClearEnc;
        private Button BtnClearDec;
    }
}
