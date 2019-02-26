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

namespace Ficha2
{
    public partial class Form1 : Form
    {
        private const int MAX_BUFFER_SIZE = 20480;
        private const string DESTINATION_FILE = "security_bak.jpg";
        private const string SOURCE_FILE = "security.jpg";
        private const string LOG_FILE = "log.txt";
        

        public Form1()
        {
            InitializeComponent();
        }
        public void buttonCopyFile_Click(object sender, EventArgs e)
        {
            FileStream sourceStream = null;
            FileStream destinationStream = null;
            StreamWriter logStream = null;
            DateTime today = DateTime.Today;
            byte[] buffer = null;
            string log = "hi";
            int bytesRead = 0;

            try
            {
                sourceStream = new FileStream(SOURCE_FILE, FileMode.Open);
                destinationStream = new FileStream(DESTINATION_FILE, FileMode.Create);
           //     logStream = File.AppendText(LOG_FILE);
                logStream = new StreamWriter(LOG_FILE, true);
                log = "Cópia feita com " + sourceStream.Length + " bytes";
                buffer = new byte[MAX_BUFFER_SIZE];
                while (((bytesRead = sourceStream.Read(buffer, 0, MAX_BUFFER_SIZE))) != 0)
                {
                    destinationStream.Write(buffer, 0, bytesRead);
                    
                    progressBar1.Step =(int) destinationStream.Length;
                    progressBar1.PerformStep();
                }
                MessageBox.Show("File copied");
                logStream.WriteLine(log);
                progressBar1.Value = 0;

            }
            catch(Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                if (sourceStream != null)
                {
                    sourceStream.Close();
                }
                if (destinationStream != null)
                {
                    destinationStream.Close();
                }
                if (logStream != null)
                {
                    logStream.Close();
                }

            }
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
