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

namespace ei.si.worksheet5
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

        private void ButtonMD5ComputeHash_Click(object sender, EventArgs e)
        {
            using (MD5CryptoServiceProvider algorithm = new MD5CryptoServiceProvider())
            {
                byte[] data = Encoding.UTF8.GetBytes(textBoxDataToHash.Text);
                byte[] hash = algorithm.ComputeHash(data);
                textBoxDataToHash.Text = BitConverter.ToString(hash);

            }
        }

        private void ButtonSHA1ComputeHash_Click(object sender, EventArgs e)
        {
            using (SHA1CryptoServiceProvider algorithm = new SHA1CryptoServiceProvider())
            {
                byte[] data = Encoding.UTF8.GetBytes(textBoxDataToHash.Text);
                byte[] hash = algorithm.ComputeHash(data);
                textBoxHashBytes.Text = BitConverter.ToString(hash);

            }
        }

        private void ButtonSHA256ComputeHash_Click(object sender, EventArgs e)
        {
            using (SHA256CryptoServiceProvider algorithm = new SHA256CryptoServiceProvider())
            {
                byte[] data = Encoding.UTF8.GetBytes(textBoxDataToHash.Text);
                byte[] hash = algorithm.ComputeHash(data);
                textBoxHashBytes.Text = BitConverter.ToString(hash);

            }
        }

        private void ButtonSHA512ComputeHash_Click(object sender, EventArgs e)
        {
            using (SHA512CryptoServiceProvider algorithm = new SHA512CryptoServiceProvider())
            {
                byte[] data = Encoding.UTF8.GetBytes(textBoxDataToHash.Text);
                byte[] hash = algorithm.ComputeHash(data);
                textBoxHashBytes.Text = BitConverter.ToString(hash);

            }
        }
    }
}
