using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TripleDESEncryption
{
    public partial class TripleDESEncryption : Form
    {
        private static readonly string Key =
            ConfigurationManager.AppSettings["Key"] ?? string.Empty;

        public TripleDESEncryption()
        {
            InitializeComponent();
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPlain.Text))
            {
                MessageBox.Show("Please enter some text to encrypt.");
                return;
            }
            TxtCipher.Text = TripleDesEncrypt(TxtPlain.Text);
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtCipher.Text))
            {
                MessageBox.Show("Please enter some text to decrypt.");
                return;
            }
            TxtPlain.Text = TripleDesDecrypt(TxtCipher.Text);
        }

        public static string TripleDesEncrypt(string plainText)
        {
            var des = CreateDes(Key);
            var ct = des.CreateEncryptor();
            var input = Encoding.UTF8.GetBytes(plainText);
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Convert.ToBase64String(output);
        }

        public static string TripleDesDecrypt(string cypherText)
        {
            var des = CreateDes(Key);
            var ct = des.CreateDecryptor();
            var input = Convert.FromBase64String(cypherText);
            var output = ct.TransformFinalBlock(input, 0, input.Length);
            return Encoding.UTF8.GetString(output);
        }

        public static TripleDES CreateDes(string key)
        {
            TripleDES des = TripleDES.Create();
            var desKey = MD5.HashData(Encoding.UTF8.GetBytes(key));
            des.Key = desKey;
            des.IV = new byte[des.BlockSize / 8];
            des.Padding = PaddingMode.PKCS7;
            des.Mode = CipherMode.ECB;
            return des;
        }
    }
}
