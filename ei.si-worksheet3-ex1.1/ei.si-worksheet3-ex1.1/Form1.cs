using EI.SI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei_si_worksheet3
{
    public partial class Form1 : Form
    {
      //  private byte[] key;
       // private byte[] iv;
        private AesCryptoServiceProvider algorithm = null;
        private SymmetricsSI symmetricsSI = null;
        public Form1()
        {
            algorithm = new AesCryptoServiceProvider();
            symmetricsSI = new SymmetricsSI(algorithm);
            InitializeComponent();
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            string clearText = textBoxTextToEncrypt.Text;
            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
          //  byte[] encryptedBytes = Encrypt(clearBytes);
            byte[] encryptedBytes =symmetricsSI.Encrypt(clearBytes);
            textBoxEncryptedText.Text = Convert.ToBase64String(encryptedBytes);
            
        }
        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            string encryptedText = textBoxEncryptedText.Text;
            byte[] encryptedBytes =Convert.FromBase64String(encryptedText);
           // byte[] clearBytes = Decrypt(encryptedBytes);
            byte[] clearBytes = symmetricsSI.Decrypt(encryptedBytes);
            textBoxDecryptedText.Text = Encoding.UTF8.GetString(clearBytes);
        }
        #region encrypt n decrypt 
        /*
        private byte[] Encrypt(byte[] clearBytes)
        {
            byte[] encryptedBytes = null;
            AesCryptoServiceProvider algorithm = null;
            CryptoStream cryptoStream = null;
            MemoryStream memoryStream = null;
            try
            {
                algorithm = new AesCryptoServiceProvider();
                this.key = algorithm.Key;
                this.iv = algorithm.IV;
                memoryStream = new MemoryStream();
                cryptoStream = new CryptoStream(
                  memoryStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(clearBytes, 0, clearBytes.Length);
                cryptoStream.Close();
                encryptedBytes = memoryStream.ToArray();


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                if (cryptoStream != null) cryptoStream.Dispose();

            }
            return encryptedBytes;

        }
        private byte[] Decrypt(byte[] encryptedBytes)
        {
            byte[] clearBytes = new byte[encryptedBytes.Length];
            using (AesCryptoServiceProvider algorithm = new AesCryptoServiceProvider())
            {
                algorithm.Key = this.key;
                algorithm.IV = this.iv;
                using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
                    using(CryptoStream cryptoStream = new CryptoStream(memoryStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    int bytesRead = cryptoStream.Read(clearBytes, 0, clearBytes.Length);
                    Array.Resize(ref clearBytes, bytesRead);
                }
            }
            return clearBytes;

        }*/
        #endregion
    }
}
