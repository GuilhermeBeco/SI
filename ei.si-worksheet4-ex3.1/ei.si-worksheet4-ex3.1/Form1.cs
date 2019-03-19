using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ei_si_worksheet4
{
    public partial class Form1 : Form
    {
        private const string PUBLIC_KEY_FILE = "public.xml";
        private const string BOTH_KEY_FILE = "both.xml";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonGenerateKeys_Click(object sender, EventArgs e)
        {

            using(RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
            {
                tbPublicKey.Text = algorithm.ToXmlString(true);
                tbBothKeys.Text = algorithm.ToXmlString(false);
            }

        }

        private void ButtonImportKeys_Click(object sender, EventArgs e)
        {          
            using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    algorithm.FromXmlString(File.ReadAllText(openFileDialog1.FileName));
                tbPublicKey.Text = algorithm.ToXmlString(true);
                tbBothKeys.Text = algorithm.ToXmlString(false);
            }
        }

        private void ButtonSavePublicKey_Click(object sender, EventArgs e)
        {
            File.WriteAllText(PUBLIC_KEY_FILE, tbPublicKey.Text);
            MessageBox.Show("Pub key gravada");

        }

        private void ButtonSaveKeys_Click(object sender, EventArgs e)
        {
            ButtonSavePublicKey_Click(sender, e);
            File.WriteAllText(BOTH_KEY_FILE, tbBothKeys.Text);
            MessageBox.Show("Priv key gravada");
        }

        private void ButtonGenerateSymmetricKey_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider())
            {
                algorithm.FromXmlString(File.ReadAllText(PUBLIC_KEY_FILE));
                byte[] symetricKey = Encoding.UTF8.GetBytes(textBoxSymmetricKey.Text);
                byte[] encreyptedSymmetricKey = algorithm.Encrypt(symetricKey, true);
                tbSymmetricKeyEncrtypted.Text = Convert.ToBase64String(encreyptedSymmetricKey);
                tbBitSize.Text = (encreyptedSymmetricKey.Length * 8).ToString();
            }
        }

        private void ButtonEncryptFile_Click(object sender, EventArgs e)
        {

        }

        private void buttonDecryptFile_Click(object sender, EventArgs e)
        {

        }
    }
}
