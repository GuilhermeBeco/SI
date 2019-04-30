using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei.si_worksheet7
{
    public partial class Form1 : Form
    {
        // The digital certificates should be copied to ./bin/debug directory
        const string fileCertPFX = @".pfx";
        const string fileCertCER = @".cer";
        static readonly string pwdfileCertPFX = Properties.Settings.Default.PwdCertPFX;

        private byte[] tempCertRaw = null;
        private byte[] tempData = null;


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
            // todo

            textBoxInfo.Text += "++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++" + Environment.NewLine;
            textBoxInfo.Text += Environment.NewLine;
        }



        private void ButtonOpenPFX_Click(object sender, EventArgs e)
        {

        }

        private void ButtonOpenCER_Click(object sender, EventArgs e)
        {

        }



        private void ButtonOpenFromStore_Click(object sender, EventArgs e)
        {

        }

        private void ButtonAddToStoreCER_Click(object sender, EventArgs e)
        {

        }



        private void ButtonVerifyCert_Click(object sender, EventArgs e)
        {

        }

        private void ButtonVerifyCertChain_Click(object sender, EventArgs e)
        {

        }



        private void ButtonExportPublicCert_Click(object sender, EventArgs e)
        {

        }

        private void ButtonImportPublicCert_Click(object sender, EventArgs e)
        {

        }



        private void ButtonExportPrivateCert_Click(object sender, EventArgs e)
        {

        }

        private void ButtonImportPrivateCert_Click(object sender, EventArgs e)
        {

        }



    }
}
