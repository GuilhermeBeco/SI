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

namespace ei.si.worksheet6
{
    public partial class Form1 : Form
    {
        private byte[] signature = null;
        private string pubKey = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSignHash_Click(object sender, EventArgs e)
        {
            using(RSACryptoServiceProvider algorithmRsa = new RSACryptoServiceProvider())
            {
                using(SHA256CryptoServiceProvider algorithmSHA256 = new SHA256CryptoServiceProvider())
                {
                    this.pubKey = algorithmRsa.ToXmlString(false);//a true seria private e pub key
                    byte[] data = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
                    byte[] hash = algorithmSHA256.ComputeHash(data);
                    this.signature = algorithmRsa.SignHash(hash,CryptoConfig.MapNameToOID("SHA256"));
                    textBoxDigitalSignature.Text = BitConverter.ToString(signature);
                    textBoxDigitalSignatureBits.Text = (signature.Length * 8).ToString();
                    textBoxMessageDigest.Text = BitConverter.ToString(hash);
                    textBoxMessageDigestBits.Text = (hash.Length * 8).ToString();

                }
            }
        }

        private void ButtonSignData_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider algorithmRsa = new RSACryptoServiceProvider())
            {
                using (SHA256CryptoServiceProvider algorithmSHA256 = new SHA256CryptoServiceProvider())
                {
                    this.pubKey = algorithmRsa.ToXmlString(false);//a true seria private e pub key
                    byte[] data = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
                    this.signature = algorithmRsa.SignData(data, algorithmSHA256);
                    textBoxDigitalSignature.Text = BitConverter.ToString(signature);
                    textBoxDigitalSignatureBits.Text = (signature.Length * 8).ToString();
                    textBoxMessageDigest.Text = "";
                    textBoxMessageDigestBits.Text = "";

                }
            }
        }

        private void ButtonVerifyHash_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider algorithmRsa = new RSACryptoServiceProvider())
            {
                using (SHA256CryptoServiceProvider algorithmSHA256 = new SHA256CryptoServiceProvider())
                {
                    algorithmRsa.FromXmlString(this.pubKey);
                    byte[] data = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
                    byte[] hash = algorithmSHA256.ComputeHash(data);
                    bool isVerified = algorithmRsa.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA256"),this.signature);
                    if (isVerified)
                    {
                        MessageBox.Show("Valid sign");
                    }
                    else
                    {
                        MessageBox.Show("Valid sign");
                    }
                }
            }
        }
        private void ButtonVerifyData_Click(object sender, EventArgs e)
        {
            using (RSACryptoServiceProvider algorithmRsa = new RSACryptoServiceProvider())
            {
                using (SHA256CryptoServiceProvider algorithmSHA256 = new SHA256CryptoServiceProvider())
                {
                    algorithmRsa.FromXmlString(this.pubKey);
                    byte[] data = Encoding.UTF8.GetBytes(textBoxOriginalMessage.Text);
                    bool isVerified = algorithmRsa.VerifyData(data,algorithmSHA256, this.signature);
                    if (isVerified)
                    {
                        MessageBox.Show("Valid sign");
                    }
                    else
                    {
                        MessageBox.Show("Valid sign");
                    }
                }
            }
        }


    }
}
