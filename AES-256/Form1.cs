using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AES_256
{
    public partial class Form1 : Form
    {
            private TextBox plaintextTextBox;
    private TextBox encryptedTextBox;
    private TextBox decryptedTextBox;
    private Button encryptButton;
    private Button decryptButton;
        public Form1()
        {
            InitializeComponent();

        }

       public class AesEncryption
{
    private static readonly byte[] Key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F }; // 32 bytes for AES-256
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("yourIV1234567890"); // 16 bytes for AES

    public static byte[] Encrypt(string plaintext)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                    cryptoStream.Write(plaintextBytes, 0, plaintextBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }
    }
            public static string Decrypt(byte[] ciphertext)
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Key;
                    aes.IV = IV;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream(ciphertext))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            byte[] plaintextBytes = new byte[ciphertext.Length];
                            int decryptedByteCount = cryptoStream.Read(plaintextBytes, 0, plaintextBytes.Length);

                            return Encoding.UTF8.GetString(plaintextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
        }

        



  

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
