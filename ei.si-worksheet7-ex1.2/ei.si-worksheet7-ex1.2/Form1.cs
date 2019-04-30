using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;    // Mandatory to add the reference to System.Security DLL
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei.si_worksheet7
{
    public partial class Form1 : Form
    {
        // The digital certificates should be copied to ./bin/debug directory
        const string fileCertPFX = @"estg.dei.si.a.pfx";
        const string fileCertCER = @"estg.dei.si.a.cer";
        static readonly string pwdfileCertPFX = Properties.Settings.Default.PwdCertPFX;

        private byte[] tempDigitalSignature = null;
        private byte[] tempEnvelope = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// Show digital certificate info in the textbox
        /// </summary>
        /// <param name="cert">digital certificate</param>
        private void ShowCertificate(X509Certificate2 cert)
        {
            textBoxInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            textBoxInfo.Text += "Subject: " + cert.Subject + Environment.NewLine;
            textBoxInfo.Text += "FriendlyName: " + cert.FriendlyName + Environment.NewLine;
            textBoxInfo.Text += "Thumbprint: " + cert.Thumbprint + Environment.NewLine;
            textBoxInfo.Text += "SerialNumber: " + cert.SerialNumber + Environment.NewLine;
            textBoxInfo.Text += "HasPrivateKey: " + cert.HasPrivateKey + Environment.NewLine;
            textBoxInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            textBoxInfo.Text += Environment.NewLine;
        }




        private void ButtonSignatureWithData_Click(object sender, EventArgs e)
        {

        }

        private void ButtonVerifySignatureWithData_Click(object sender, EventArgs e)
        {

        }



        private void ButtonSignatureWithoutData_Click(object sender, EventArgs e)
        {

        }

        private void ButtonVerifySignatureWithoutData_Click(object sender, EventArgs e)
        {

        }



        private void ButtonEncryptWithCER_Click(object sender, EventArgs e)
        {

        }

        private void ButtonDecryptFromPFX_Click(object sender, EventArgs e)
        {
            
        }



        private void ButtonEncryptWithStore_Click(object sender, EventArgs e)
        {

        }

        private void ButtonDecryptFromStore_Click(object sender, EventArgs e)
        {

        }



        private void ButtonEncryptAndSign_Click(object sender, EventArgs e)
        {

        }

        private void ButtonVerifyAndDecrypt_Click(object sender, EventArgs e)
        {

        }
    }
}
