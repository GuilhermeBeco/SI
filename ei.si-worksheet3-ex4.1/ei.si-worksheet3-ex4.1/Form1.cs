using EI.SI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei_si_worksheet3
{
    public partial class Form1 : Form
    {
        private AesCryptoServiceProvider algorithmAes = null;
        private TripleDESCryptoServiceProvider algorithmTripleDES = null;
        private SymmetricsSI symmetricsSI = null;
        int opt = -1; //des=1 tripleDes=3

        public Form1()
        {
            algorithmAes = new AesCryptoServiceProvider();
            algorithmTripleDES = new TripleDESCryptoServiceProvider();
           // symmetricsSI = new SymmetricsSI(algorithm);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            string clearText = textBoxTextToEncrypt.Text;
            byte[] clearBytes = Encoding.UTF8.GetBytes(clearText);
            byte[] encryptedBytes = null;
            //  byte[] encryptedBytes = Encrypt(clearBytes);
            if (opt == 1)
            {
                symmetricsSI = new SymmetricsSI(algorithmAes);
               encryptedBytes = symmetricsSI.Encrypt(clearBytes);
            }
            else
            {
                symmetricsSI = new SymmetricsSI(algorithmTripleDES);
                encryptedBytes = symmetricsSI.Encrypt(clearBytes);
            }
            textboxEncryptedText.Text = Convert.ToBase64String(encryptedBytes);
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            string encryptedText = textboxEncryptedText.Text;
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            // byte[] clearBytes = Decrypt(encryptedBytes);
            byte[] clearBytes = symmetricsSI.Decrypt(encryptedBytes);
            textBoxDecryptedText.Text = Encoding.UTF8.GetString(clearBytes);
        }

        private void ComboBoxAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comboText = comboBoxAlgorithm.Text;
            if (comboText.Equals("AES"))
            {
                opt = 1;
            }
            else
            {
                opt = 3;
            }
        }
    }
}
