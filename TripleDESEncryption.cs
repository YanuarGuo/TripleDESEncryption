using System;
using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TripleDESEncryption
{
    public partial class TripleDESEncryption : Form
    {
        public string? Key { get; set; }
        public string? IV { get; set; }
        public string? Mode { get; set; }
        public string? TDESMode { get; set; }
        public new string? Padding { get; set; }

        public TripleDESEncryption()
        {
            InitializeComponent();
            GbEnc.Enabled = false;
            GbDec.Enabled = false;
        }

        private void BtnConfirmAll_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrEmpty(TxtKey1.Text)
                || string.IsNullOrEmpty(TxtKey2.Text)
                || string.IsNullOrEmpty(TxtKey3.Text)
                || string.IsNullOrEmpty(CbMode3DES.Text)
                || string.IsNullOrEmpty(CbPadding.Text)
                || string.IsNullOrEmpty(CbCipherMode.Text)
            )
            {
                MessageBox.Show("Please enter all configurations!");
                return;
            }
            TDESMode = CbMode3DES.Text; // TDES-168 and TDES-112
            Key = TxtKey1.Text + TxtKey2.Text + TxtKey3.Text;
            Padding = CbPadding.Text; // PKCS7 and ZeroPadding
            Mode = CbCipherMode.Text; // CBC and ECB
            GbEnc.Enabled = true;
            GbDec.Enabled = true;

            if (CbCipherMode.Text == "ECB")
            {
                TxtIVEnc.Text = "";
                TxtIVDec.Text = "";
                TxtIVEnc.Enabled = false;
                TxtIVDec.Enabled = false;
            }
            else
            {
                TxtIVEnc.Enabled = true;
                TxtIVDec.Enabled = true;
            }
            MessageBox.Show("Configurations saved!");
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            IV = TxtIVEnc.Text;
            if (
                string.IsNullOrEmpty(Key)
                || string.IsNullOrEmpty(Padding)
                || string.IsNullOrEmpty(Mode)
                || string.IsNullOrEmpty(TDESMode)
            )
            {
                MessageBox.Show("Key / IV / Padding / Mode / TDES Mode cannot be null or empty!");
                return;
            }
            string encrypted = TDESEncryption(
                TxtPlain.Text,
                Key,
                IV,
                Padding,
                CbOutFormat.Text,
                Mode,
                TDESMode
            );
            TxtCipher.Text = encrypted;
            MessageBox.Show("Encrypted text: " + encrypted);
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            IV = TxtIVDec.Text;
            if (
                string.IsNullOrEmpty(Key)
                || string.IsNullOrEmpty(Padding)
                || string.IsNullOrEmpty(Mode)
                || string.IsNullOrEmpty(TDESMode)
            )
            {
                MessageBox.Show("Key / IV / Padding/ Mode / TDES Mode cannot be null or empty!");
                return;
            }
            string decrypted = TDESDecryption(
                TxtCipher.Text,
                Key,
                IV,
                Padding,
                CbInFormat.Text,
                Mode,
                TDESMode
            );
            TxtPlain.Text = decrypted;
            MessageBox.Show("Decrypted text: " + decrypted);
        }

        private void BtnClearEnc_Click(object sender, EventArgs e)
        {
            TxtPlain.Text = "";
            TxtIVEnc.Text = "";
            CbOutFormat.SelectedIndex = -1;
        }

        private void BtnClearDec_Click(object sender, EventArgs e)
        {
            TxtCipher.Text = "";
            TxtIVDec.Text = "";
            CbInFormat.SelectedIndex = -1;
        }

        private void TxtKey1_TextChanged(object sender, EventArgs e)
        {
            if (TxtKey1.Text.Length == 8)
            {
                TxtKey2.Focus();
            }
        }

        private void TxtKey2_TextChanged(object sender, EventArgs e)
        {
            if (TxtKey2.Text.Length == 8)
            {
                TxtKey3.Focus();
            }
        }

        private void CbMode3DES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbMode3DES.Text == "TDES-112")
            {
                TxtKey3.Enabled = false;
            }
            else
            {
                TxtKey3.Enabled = true;
            }
        }

        private static byte[] Generate3DESKey(byte[] keyBytes, string TDESMode)
        {
            byte[] desKey = new byte[(TDESMode == "TDES-168") ? 24 : 16];
            Array.Copy(keyBytes, desKey, Math.Min(keyBytes.Length, desKey.Length));

            if (TDESMode == "TDES-112")
            {
                Array.Copy(desKey, 0, desKey, 16, 8);
            }

            return desKey;
        }

        public static string TDESEncryption(
            string plainText,
            string Key,
            string IV,
            string Padding,
            string OutputFormat,
            string CipherMode,
            string TDESMode
        )
        {
            using var provider = TripleDES.Create();

            byte[] keyBytes = Generate3DESKey(Encoding.ASCII.GetBytes(Key), TDESMode);
            Debug.WriteLine($"Key: {BitConverter.ToString(keyBytes)}");

            provider.Key = keyBytes;
            provider.Mode = CipherMode.ToUpper() switch
            {
                "CBC" => System.Security.Cryptography.CipherMode.CBC,
                "ECB" => System.Security.Cryptography.CipherMode.ECB,
                _ => throw new ArgumentException(
                    "Invalid Cipher Mode. Choose either 'CBC' or 'ECB'."
                ),
            };

            provider.Padding = Padding.ToUpper() switch
            {
                "PKCS7" => PaddingMode.PKCS7,
                "ZEROPADDING" => PaddingMode.Zeros,
                _ => throw new ArgumentException(
                    "Invalid Padding. Choose either 'PKCS7' or 'ZeroPadding'."
                ),
            };

            if (provider.Mode == System.Security.Cryptography.CipherMode.CBC)
            {
                byte[] ivBytes = Encoding.ASCII.GetBytes(IV);
                if (ivBytes.Length != 8)
                    throw new ArgumentException("IV must be exactly 8 bytes long");
                provider.IV = ivBytes;
            }

            using var ms = new MemoryStream();
            using (
                var cs = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write)
            )
            {
                byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);
                cs.Write(plainBytes, 0, plainBytes.Length);
                cs.FlushFinalBlock();
            }

            byte[] encryptedBytes = ms.ToArray();

            return OutputFormat == "HEX"
                ? BitConverter.ToString(encryptedBytes).Replace("-", "")
                : Convert.ToBase64String(encryptedBytes);
        }

        public static string TDESDecryption(
            string cipherText,
            string Key,
            string IV,
            string Padding,
            string InputFormat,
            string CipherMode,
            string TDESMode
        )
        {
            using var provider = TripleDES.Create();

            byte[] keyBytes = Generate3DESKey(Encoding.ASCII.GetBytes(Key), TDESMode);
            Debug.WriteLine($"Key: {BitConverter.ToString(keyBytes)}");

            provider.Key = keyBytes;
            provider.Mode = CipherMode.ToUpper() switch
            {
                "CBC" => System.Security.Cryptography.CipherMode.CBC,
                "ECB" => System.Security.Cryptography.CipherMode.ECB,
                _ => throw new ArgumentException(
                    "Invalid Cipher Mode. Choose either 'CBC' or 'ECB'."
                ),
            };

            provider.Padding = Padding.ToUpper() switch
            {
                "PKCS7" => PaddingMode.PKCS7,
                "ZEROPADDING" => PaddingMode.Zeros,
                _ => throw new ArgumentException(
                    "Invalid Padding. Choose either 'PKCS7' or 'ZeroPadding'."
                ),
            };

            if (provider.Mode == System.Security.Cryptography.CipherMode.CBC)
            {
                byte[] ivBytes = Encoding.ASCII.GetBytes(IV);
                if (ivBytes.Length != 8)
                    throw new ArgumentException("IV must be exactly 8 bytes long");
                provider.IV = ivBytes;
            }

            byte[] encryptedBytes =
                InputFormat.ToUpper() == "HEX"
                    ? ConvertHexToBytes(cipherText)
                    : Convert.FromBase64String(cipherText);

            using var ms = new MemoryStream();
            using (
                var cs = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Write)
            )
            {
                cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                cs.FlushFinalBlock();
            }

            return Encoding.ASCII.GetString(ms.ToArray());
        }

        private static byte[] ConvertHexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }

        //public string TripleDesEncrypt(string plainText)
        //{
        //    if (string.IsNullOrEmpty(Key))
        //        throw new ArgumentException("Key cannot be null or empty.");

        //    var des = CreateDes168(Key);
        //    var ct = des.CreateEncryptor();
        //    var input = Encoding.UTF8.GetBytes(plainText);
        //    var output = ct.TransformFinalBlock(input, 0, input.Length);
        //    return Convert.ToBase64String(output);
        //}

        //public string TripleDesDecrypt(string cypherText)
        //{
        //    if (string.IsNullOrEmpty(Key))
        //        throw new ArgumentException("Key cannot be null or empty.");

        //    var des = CreateDes168(Key);
        //    var ct = des.CreateDecryptor();
        //    var input = Convert.FromBase64String(cypherText);
        //    var output = ct.TransformFinalBlock(input, 0, input.Length);
        //    return Encoding.UTF8.GetString(output);
        //}

        //public static TripleDES CreateDes168(string userKey)
        //{
        //    if (string.IsNullOrEmpty(userKey))
        //        throw new ArgumentException("Key cannot be empty.");

        //    TripleDES des = TripleDES.Create();

        //    byte[] keyBytes = Encoding.UTF8.GetBytes(userKey);
        //    byte[] desKey = new byte[24]; // 24 bytes for 168-bit security

        //    for (int i = 0; i < desKey.Length; i++)
        //        desKey[i] = i < keyBytes.Length ? keyBytes[i] : (byte)0x00;

        //    des.Key = desKey;
        //    des.IV = new byte[des.BlockSize / 8];
        //    des.Padding = PaddingMode.PKCS7;
        //    des.Mode = CipherMode.ECB;

        //    return des;
        //}

        //public static TripleDES CreateDes112(string userKey)
        //{
        //    if (string.IsNullOrEmpty(userKey))
        //        throw new ArgumentException("Key cannot be empty.");

        //    TripleDES des = TripleDES.Create();

        //    byte[] keyBytes = Encoding.UTF8.GetBytes(userKey);
        //    byte[] desKey = new byte[16]; // 16 bytes for 112-bit security

        //    for (int i = 0; i < desKey.Length; i++)
        //        desKey[i] = i < keyBytes.Length ? keyBytes[i] : (byte)0x00;

        //    des.Key = desKey;
        //    des.IV = new byte[des.BlockSize / 8];
        //    des.Padding = PaddingMode.PKCS7;
        //    des.Mode = CipherMode.ECB;

        //    return des;
        //}

        //public static TripleDES CreateDes(string key)
        //{
        //    TripleDES des = TripleDES.Create();
        //    var desKey = MD5.HashData(Encoding.UTF8.GetBytes(key));
        //    des.Key = desKey;
        //    des.IV = new byte[des.BlockSize / 8];
        //    des.Padding = PaddingMode.PKCS7;
        //    des.Mode = CipherMode.ECB;
        //    return des;
        //}
    }
}
