using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EI.SI;

namespace TesteLastYear
{
    public partial class Form1 : Form
    {
        byte[] msg;
        IPEndPoint serverEndPoint;
        TcpClient client = null;
        NetworkStream netStream = null;
        ProtocolSI protocol = null;
        AesCryptoServiceProvider aes = null;
        SymmetricsSI symetric = null;
        RSACryptoServiceProvider rsaClient = null;
        RSACryptoServiceProvider rsaServer = null;
        SHA256CryptoServiceProvider sha = null;
        string server = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
          //  if (File.ReadAllText("Chave.xml") != null)
            //    rsaClient.FromXmlString(File.ReadAllText("Chave.xml"));
            //else
                rsaClient = new RSACryptoServiceProvider();
            rsaServer = new RSACryptoServiceProvider();
            sha = new SHA256CryptoServiceProvider();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            aes = new AesCryptoServiceProvider();
            symetric = new SymmetricsSI(aes);

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            protocol = new ProtocolSI();

            // Defenitions for TcpClient: IP:port (127.0.0.1:13000)
            serverEndPoint = new IPEndPoint(IPAddress.Parse(textBoxIp.Text), Int16.Parse(textBoxPort.Text));
            client = new TcpClient();
            client.Connect(serverEndPoint);
            netStream = client.GetStream();
            

        }

        private void buttonPub_Click(object sender, EventArgs e)
        {
            
            msg = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, rsaClient.ToXmlString(false));
            netStream.Write(msg, 0, msg.Length);
           // Receive server public key
            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            rsaServer.FromXmlString(protocol.GetStringFromData());
         
        }

        private void buttonSecret_Click(object sender, EventArgs e)
        {
           
           msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, rsaServer.Encrypt(aes.Key, true));
           netStream.Write(msg, 0, msg.Length);

           netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            
           msg = protocol.Make(ProtocolSICmdType.IV, rsaServer.Encrypt(aes.IV, true));
           netStream.Write(msg, 0, msg.Length);

           netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            if (protocol.GetCmdType() == ProtocolSICmdType.ACK)
            {
                MessageBox.Show("hi");
            }
           
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            byte[] username = Encoding.UTF8.GetBytes(textBoxUser.Text);
            byte[] encryptedData = symetric.Encrypt(username);
            
            msg = protocol.Make(ProtocolSICmdType.SYM_CIPHER_DATA, encryptedData);
            netStream.Write(msg, 0, msg.Length);
            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            MessageBox.Show("Aqui");
            string passwd = textBoxPass.Text;
            byte[] pass = sha.ComputeHash(Encoding.UTF8.GetBytes(passwd));//zona critica
            byte[] signature = rsaClient.SignHash(pass, CryptoConfig.MapNameToOID("SHA256"));
            msg = protocol.Make(ProtocolSICmdType.DIGITAL_SIGNATURE, signature);
            netStream.Write(msg, 0, msg.Length);

            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            if (protocol.GetCmdType() == ProtocolSICmdType.ACK)
                MessageBox.Show("Login Sucessfull");
            else
                MessageBox.Show("Login Failled");
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

            if (protocol.GetCmdType() == ProtocolSICmdType.SYM_CIPHER_DATA)
            {
                byte[] data = symetric.Decrypt(protocol.GetData());
                server = Encoding.UTF8.GetString(data);
                MessageBox.Show(Encoding.UTF8.GetString(data));
            }
            else
            {
                MessageBox.Show("Sign not valid");
            }
            msg = protocol.Make(ProtocolSICmdType.ACK);
            netStream.Write(msg, 0, msg.Length);
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {

            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            byte[] signature = protocol.GetData();
            byte[] data = Encoding.UTF8.GetBytes(server);
            byte[] hash = sha.ComputeHash(data);
            bool isVerified = rsaServer.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA256"), signature);
            if (isVerified)
            {
                MessageBox.Show("Message verified sucessfully");
            }
            else
            {
                MessageBox.Show("The message isn't ok");
            }
        }
    }
}
