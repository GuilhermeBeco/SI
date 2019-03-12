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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {

        }

        private byte[] Encrypt(byte[] clearBytes)
        {
            byte[] encryptedBytes = null;
            AesCryptoServiceProvider algorithm = null;
            CryptoStream cryptoStream = null;
            MemoryStream memoryStream = null;
            try
            {
                algorithm = new AesCryptoServiceProvider();
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
    }
}
