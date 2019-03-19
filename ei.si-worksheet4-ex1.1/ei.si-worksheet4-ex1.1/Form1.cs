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

namespace ei_si_worksheet4
{
    public partial class Form1 : Form
    {
        private const string PUBLICK_KEY_FILE = "public.xml";
        private const string BOTH_KEYS = "both.xml";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonGererateKeys_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider algorithm=  new RSACryptoServiceProvider())
            {
                textboxPublicKey.Text = algorithm.ToXmlString(false);
                textboxBothKeys.Text = algorithm.ToXmlString(true);

            }

        }

        private void ButtonSavePublicKey_Click(object sender, EventArgs e)
        {
            File.WriteAllText(PUBLICK_KEY_FILE, textboxPublicKey.Text);
            MessageBox.Show("Gravado");
        }

        private void ButtonSaveKeys_Click(object sender, EventArgs e)
        {
            File.WriteAllText(BOTH_KEYS, textboxBothKeys.Text);
            MessageBox.Show("Gravado");

        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
            {
                algorithm.FromXmlString(File.ReadAllText(PUBLICK_KEY_FILE));
                byte[] symetricKey = Encoding.UTF8.GetBytes(textboxSymmentricKey.Text);
                byte[] encreyptedSymmetricKey = algorithm.Encrypt(symetricKey, true);
                textboxSymmetricKeyEncrtypted.Text = Convert.ToBase64String(encreyptedSymmetricKey);
                textboxBitSize.Text = (encreyptedSymmetricKey.Length * 8).ToString();
            }
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
            {
                algorithm.FromXmlString(File.ReadAllText(BOTH_KEYS));
                byte[] encryptedSymmetricKey = Convert.FromBase64String(textboxSymmetricKeyEncrtypted.Text);
                byte[] symmetricKey = algorithm.Decrypt(encryptedSymmetricKey, true);
                textboxSymmetricKeyDecrypted.Text = Encoding.UTF8.GetString(symmetricKey);
            }
        }
    }
}
