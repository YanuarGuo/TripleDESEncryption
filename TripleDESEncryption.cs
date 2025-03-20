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
                || string.IsNullOrEmpty(CbMode3DES.Text)
                || string.IsNullOrEmpty(CbPadding.Text)
                || string.IsNullOrEmpty(CbCipherMode.Text)
            )
            {
                MessageBox.Show("Please enter all configurations!");
                return;
            }
            TDESMode = CbMode3DES.Text;
            Key = TxtKey1.Text + TxtKey2.Text + TxtKey3.Text;
            Padding = CbPadding.Text;
            Mode = CbCipherMode.Text;
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
                TxtKey3.Text = "";
                TxtKey3.Enabled = false;
            }
            else
            {
                TxtKey3.Enabled = true;
            }
        }

        private static byte[] Generate3DESKey(byte[] keyBytes, string TDESMode, string Padding)
        {
            int keySize = TDESMode == "TDES-168" ? 24 : 16;

            byte[] deskey = new byte[keySize];
            Array.Copy(keyBytes, deskey, Math.Min(keyBytes.Length, keySize));

            if (TDESMode == "TDES-112" && deskey.Length >= 24)
            {
                Array.Copy(deskey, 0, deskey, 16, 8);
            }

            int padLength = keySize - keyBytes.Length;
            if (padLength > 0)
            {
                if (Padding == "PKCS7")
                {
                    byte padByte = (byte)padLength;
                    return deskey
                        .Take(keySize - padLength)
                        .Concat(Enumerable.Repeat(padByte, padLength))
                        .ToArray();
                }
                else if (Padding == "ZeroPadding")
                {
                    return deskey.Take(keySize - padLength).Concat(new byte[padLength]).ToArray();
                }
            }

            return deskey;
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
            try
            {
                using var provider = TripleDES.Create();

                byte[] keyBytes = Generate3DESKey(Encoding.ASCII.GetBytes(Key), TDESMode, Padding);
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

                if (provider.Mode == System.Security.Cryptography.CipherMode.CBC)
                {
                    byte[] ivBytes = Encoding.ASCII.GetBytes(IV);
                    if (ivBytes.Length != 8)
                        throw new ArgumentException("IV must be exactly 8 bytes long");
                    provider.IV = ivBytes;
                }

                using var ms = new MemoryStream();
                using (
                    var cs = new CryptoStream(
                        ms,
                        provider.CreateEncryptor(),
                        CryptoStreamMode.Write
                    )
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
            catch (Exception ex)
            {
                if (ex.Message.Contains("known weak key"))
                {
                    MessageBox.Show(
                        "Error: The provided key is a known weak key for TripleDES and cannot be used.",
                        "Weak Key Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                else
                {
                    MessageBox.Show(
                        $"Encryption Error: {ex.Message}",
                        "Encryption Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                return string.Empty;
            }
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

            byte[] keyBytes = Generate3DESKey(Encoding.ASCII.GetBytes(Key), TDESMode, Padding);
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

            if (provider.Mode == System.Security.Cryptography.CipherMode.CBC)
            {
                byte[] ivBytes = Encoding.ASCII.GetBytes(IV);
                if (ivBytes.Length != 8)
                    throw new ArgumentException("IV must be exactly 8 bytes long");
                provider.IV = ivBytes;
            }

            byte[] encryptedBytes =
                InputFormat == "HEX"
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
            try
            {
                if (string.IsNullOrWhiteSpace(hex))
                {
                    MessageBox.Show(
                        "Error: Input HEX string is empty!",
                        "Conversion Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return Array.Empty<byte>();
                }

                if (hex.Length % 2 != 0)
                {
                    MessageBox.Show(
                        "Error: HEX string length must be even!",
                        "Conversion Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return Array.Empty<byte>();
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(hex, "^[0-9A-Fa-f]+$"))
                {
                    MessageBox.Show(
                        "Error: HEX string contains invalid characters!",
                        "Conversion Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return Array.Empty<byte>();
                }

                byte[] bytes = new byte[hex.Length / 2];
                for (int i = 0; i < bytes.Length; i++)
                {
                    bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                }

                return bytes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unexpected Error: {ex.Message}",
                    "Conversion Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return Array.Empty<byte>();
            }
        }
    }
}
