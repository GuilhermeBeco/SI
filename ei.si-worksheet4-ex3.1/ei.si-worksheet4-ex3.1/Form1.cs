using EI.SI;
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
        RSACryptoServiceProvider algorithm = new RSACryptoServiceProvider();
        AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonGenerateKeys_Click(object sender, EventArgs e)
        {

                tbPublicKey.Text = algorithm.ToXmlString(false);
                tbBothKeys.Text = algorithm.ToXmlString(true);
            

        }

        private void ButtonImportKeys_Click(object sender, EventArgs e)
        {          
              if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                   algorithm.FromXmlString(File.ReadAllText(openFileDialog1.FileName));
               tbPublicKey.Text = algorithm.ToXmlString(true);
               tbBothKeys.Text = algorithm.ToXmlString(false);
           
        }

        private void ButtonSavePublicKey_Click(object sender, EventArgs e)
        {
            File.WriteAllText(PUBLIC_KEY_FILE, tbPublicKey.Text);
            MessageBox.Show("Pub key gravada");

        }

        private void ButtonSaveKeys_Click(object sender, EventArgs e)
        {
            File.WriteAllText(BOTH_KEY_FILE, tbBothKeys.Text);
            MessageBox.Show("Priv key gravada");
        }

        private void ButtonGenerateSymmetricKey_Click(object sender, EventArgs e)
        {
            
            textBoxSymmetricKey.Text = Convert.ToBase64String(aes.Key);
            byte[] encryptedKey = algorithm.Encrypt(aes.Key, true);
            tbSymmetricKeyEncrtypted.Text = Convert.ToBase64String(encryptedKey);
            tbBitSize.Text = (encryptedKey.Length * 8).ToString();
            
        }

        private void ButtonEncryptFile_Click(object sender, EventArgs e)
        {
            byte[] clearData = File.ReadAllBytes("data.txt");
            SymmetricsSI symmetrics = new SymmetricsSI(aes);
            byte[] encryptedData = symmetrics.Encrypt(clearData);
            File.WriteAllBytes("encrypted.dat", encryptedData);
            File.WriteAllBytes("secretKey.dat", Convert.FromBase64String(tbSymmetricKeyEncrtypted.Text));
            File.WriteAllBytes("iv.dat", algorithm.Encrypt(aes.IV,true);
            MessageBox.Show("All elems saved");


        }

        private void buttonDecryptFile_Click(object sender, EventArgs e)
        {
            byte[] encryptedData = File.ReadAllBytes("encrypted.dat");
            byte[] encryptedKey= File.ReadAllBytes("secretKey.dat");
            byte[] encryptedIV= File.ReadAllBytes("iv.dat");

            aes = new AesCryptoServiceProvider();
            aes.Key = algorithm.Decrypt(encryptedKey, true);
            aes.IV = algorithm.Decrypt(encryptedIV, true);
            SymmetricsSI symmetrics = new SymmetricsSI(aes);

            File.WriteAllBytes("decryptedData.txt", symmetrics.Decrypt(encryptedData));
            MessageBox.Show("File Decrypted") ;

        }
    }
}
