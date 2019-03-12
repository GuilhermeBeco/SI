using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ei_si_worksheet3
{
    public partial class Form1 : Form
    {
        private StreamReader fileStreamReader;

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


        private void ButtonChooseFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileStreamReader = new StreamReader(openFileDialog1.FileName);
            }
        }


        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {

        }
    }
}
