using EI.SI;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace Client
{
    public partial class FormClient : Form
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
        string pass = null;

        public FormClient()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void ButtonGenerateAssymetric_Click(object sender, EventArgs e)
        {
            rsaClient = new RSACryptoServiceProvider();
            rsaServer = new RSACryptoServiceProvider();
            sha = new SHA256CryptoServiceProvider();
        }

        private void ButtonGenerateSymmetric_Click(object sender, EventArgs e)
        {
            aes = new AesCryptoServiceProvider();
            symetric = new SymmetricsSI(aes);
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            protocol = new ProtocolSI();

            // Defenitions for TcpClient: IP:port (127.0.0.1:13000)
            serverEndPoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), Int16.Parse(textBoxPort.Text));
            client = new TcpClient();
            client.Connect(serverEndPoint);
            netStream = client.GetStream();
        }

        private void ButtonSharePublicKeys_Click(object sender, EventArgs e)
        {
            msg = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, rsaClient.ToXmlString(false));
            netStream.Write(msg, 0, msg.Length);
            // Receive server public key
            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            rsaServer.FromXmlString(protocol.GetStringFromData());
            MessageBox.Show("Pubs partilhadas");
        }

        private void ButtonShareSecretKey_Click(object sender, EventArgs e)
        {
            msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, rsaServer.Encrypt(aes.Key, true));
            netStream.Write(msg, 0, msg.Length);

            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);

            msg = protocol.Make(ProtocolSICmdType.IV, rsaServer.Encrypt(aes.IV, true));
            netStream.Write(msg, 0, msg.Length);

            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            if (protocol.GetCmdType() == ProtocolSICmdType.ACK)
            {
                MessageBox.Show("Secret partilhada");
            }
        }

        private void buttonGetPassword_Click(object sender, EventArgs e)
        {
            int numChars = int.Parse(textBoxNumberOfCharacters.Text);
            if (numChars > 0)
            {
                byte[] clearData = BitConverter.GetBytes(numChars);
                byte[] encryptedData = symetric.Encrypt(clearData);
                msg = protocol.Make(ProtocolSICmdType.SYM_CIPHER_DATA, encryptedData);
                netStream.Write(msg, 0, msg.Length);
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                byte[] encryptedPass = protocol.GetData();
                byte[] passwd = symetric.Decrypt(encryptedPass);
                pass= Encoding.UTF8.GetString(passwd);
                MessageBox.Show(pass);
            }
        }

        private void buttonConfirmIntegrity_Click(object sender, EventArgs e)
        {
            msg = protocol.Make(ProtocolSICmdType.USER_OPTION_1);
            netStream.Write(msg, 0, msg.Length);
            netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
            byte[] signatureEncrypted = protocol.GetData();
            byte[] signature = symetric.Decrypt(signatureEncrypted);
            
            byte[] data = Encoding.UTF8.GetBytes(pass);
            byte[] hash = sha.ComputeHash(data);
            bool isVerified = rsaServer.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA256"), signature);
            if (isVerified)
            {
                MessageBox.Show("Message verified sucessfully");
                textBoxPassword.Text = pass;
            }
            else
            {
                MessageBox.Show("The message isn't ok");
            }
        }
    }
}
