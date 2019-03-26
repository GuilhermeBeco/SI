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
        private int offset = 0;
        SHA256CryptoServiceProvider sha = null;
        private byte[] buffer = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            sha = new SHA256CryptoServiceProvider();
            buffer = new byte[1024];
        }

        private void ButtonTransformFirstBlock_Click(object sender, EventArgs e)
        {
                byte[] firstBlock = Encoding.UTF8.GetBytes(textBoxFirstInputData.Text);
               sha.TransformBlock(firstBlock, offset, firstBlock.Length, buffer, offset);
        }

        private void ButtonTransformNextBlock_Click(object sender, EventArgs e)
        {
                byte[] secondBlock = Encoding.UTF8.GetBytes(textBoxNextInputData.Text);
                sha.TransformBlock(secondBlock, offset, secondBlock.Length, buffer, offset);
        }

        private void ButtonTransformFinalBlock_Click(object sender, EventArgs e)
        {
                byte[] lastBlock = Encoding.UTF8.GetBytes(textBoxLastInputData.Text);
                sha.TransformFinalBlock(lastBlock, offset, lastBlock.Length);
                textBoxHashBytes.Text = BitConverter.ToString(sha.Hash);
            
        }
    }
}
