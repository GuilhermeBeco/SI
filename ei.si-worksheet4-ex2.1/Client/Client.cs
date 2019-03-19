using System;
using System.Text;
using EI.SI;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;

namespace Client
{
    /// <summary>
    /// Client
    /// </summary>
    class Client
    {
        public static string SEPARATOR = "...";
        private const string ASSYMETRIC_KEYS = "keys.xml";
        /// <summary>
        /// IMPORTANTE: a cada RECEÇÃO deve seguir-se, obrigatóriamente, um ENVIO de dados
        /// IMPORTANT: each network .Read() must be fallowed by a network .Write()
        /// </summary>
        static void Main(string[] args)
        {
            byte[] msg;
            IPEndPoint serverEndPoint;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;
            TripleDESCryptoServiceProvider tripleDES = null;
            SymmetricsSI symmetricsSI = null;
            RSACryptoServiceProvider rsaClient = null;
            RSACryptoServiceProvider rsaServer = null;
           
            try
            {
                Console.WriteLine("CLIENT");

                #region Defenitions
                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                // Defenitions for TcpClient: IP:port (127.0.0.1:9999)
                serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

                // algoritmo simétrico a usar
                tripleDES = new TripleDESCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(tripleDES);
                rsaClient = new RSACryptoServiceProvider();
                rsaServer = new RSACryptoServiceProvider();
                if (!File.Exists(ASSYMETRIC_KEYS))
                {
                    File.WriteAllText(ASSYMETRIC_KEYS, rsaClient.ToXmlString(true));
                }
                else
                {
                    rsaClient.FromXmlString(File.ReadAllText(ASSYMETRIC_KEYS));
                }
                #endregion

                Console.WriteLine(SEPARATOR);

                #region TCP Connection
                // Connects to Server ...
                Console.Write("Connecting to server... ");
                client = new TcpClient();
                client.Connect(serverEndPoint);
                netStream = client.GetStream();
                Console.WriteLine("ok.");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange public key  (Secure channel)
                // Send data...
                string publicKey = rsaClient.ToXmlString(false);
                Console.Write("Sending  pub key... ");
                msg = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, publicKey);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
              /*  Console.WriteLine("Data to encrypt.... (STR): {0}", ProtocolSI.ToString(clearData));
                Console.WriteLine("Data to encrypt.... (HEX): {0}", ProtocolSI.ToHexString(clearData));*/
                Console.WriteLine("Pub Key sent: {0}", publicKey);

                // Receive answer from server
                Console.Write("waiting for serv pub key... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                string servPubKey = protocol.GetStringFromData();
               
                rsaServer.FromXmlString(servPubKey);
                Console.WriteLine("ok.");
                #endregion
                Console.WriteLine(SEPARATOR);

                #region Exchange Secret Key
                // Send key...
                Console.Write("Sending key... ");
                byte[] encryptedSymmetricKey = rsaServer.Encrypt(tripleDES.Key, true);
                msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, encryptedSymmetricKey);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("Key: " + ProtocolSI.ToHexString(tripleDES.Key));
                Console.WriteLine("secret Key: " + ProtocolSI.ToHexString(tripleDES.Key));

                // Receive ack from server
                Console.Write("waiting for ACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok.");

                // Send iv...
                Console.Write("Sending iv... ");
                byte[] encryptedIv = rsaServer.Encrypt(tripleDES.IV, true);
                Console.Write("Sending  IV ");
                msg = protocol.Make(ProtocolSICmdType.ASSYM_CIPHER_DATA, encryptedIv);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("IV: " + ProtocolSI.ToHexString(tripleDES.IV));
                Console.WriteLine("Secret IV: " + ProtocolSI.ToHexString(encryptedIv));

                // Receive ack from server
                Console.Write("waiting for ACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok.");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data  (Secure channel)
                // Send data...
                byte[] clearData = Encoding.UTF8.GetBytes("hello world!!!");
                byte[] encryptedData = symmetricsSI.Encrypt(clearData);
                Console.Write("Sending  data... ");
                msg = protocol.Make(ProtocolSICmdType.DATA, encryptedData);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("Data to encrypt.... (STR): {0}", ProtocolSI.ToString(clearData));
                Console.WriteLine("Data to encrypt.... (HEX): {0}", ProtocolSI.ToHexString(clearData));
                Console.WriteLine("Encrypted data sent (HEX): {0}", ProtocolSI.ToHexString(encryptedData));

                // Receive answer from server
                Console.Write("waiting for ACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok.");
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            finally
            {
                if (tripleDES != null)
                    tripleDES.Dispose();
                // Close connections
                if (netStream != null)
                    netStream.Dispose();
                if (client != null)
                    client.Close();
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with server was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }
    }
}
