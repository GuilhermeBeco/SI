using System;
using EI.SI;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;

namespace Server
{
    /// <summary>
    /// Server
    /// </summary>
    class Server
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
            IPEndPoint listenEndPoint;
            TcpListener server = null;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;
            TripleDESCryptoServiceProvider tripleDES = null;
            SymmetricsSI symmetricsSI = null;
            RSACryptoServiceProvider rsaCLient = null;
            RSACryptoServiceProvider rsaServer = null;

            try
            {
                Console.WriteLine("SERVER");

                #region Defenitions
                // Binding IP/port
                listenEndPoint = new IPEndPoint(IPAddress.Any, 9999);

                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                // algoritmo simétrico a usar
                tripleDES = new TripleDESCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(tripleDES);
                rsaCLient = new RSACryptoServiceProvider();
                rsaServer = new RSACryptoServiceProvider();
                if (!File.Exists(ASSYMETRIC_KEYS))
                {
                    File.WriteAllText(ASSYMETRIC_KEYS, rsaServer.ToXmlString(true));
                }
                else
                {
                    rsaServer.FromXmlString(File.ReadAllText(ASSYMETRIC_KEYS));
                }
                #endregion


                Console.WriteLine(SEPARATOR);

                #region TCP Listner
                // Start TcpListener
                server = new TcpListener(listenEndPoint);
                server.Start();

                // Waits for a client connection (bloqueant wait)
                Console.Write("waiting for a connection... ");
                client = server.AcceptTcpClient();
                netStream = client.GetStream();
                Console.WriteLine("ok.");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange public keys  (secure channel)
                // Receive the cipher data
                Console.Write("waiting for key... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                string clientPubKey=protocol.GetStringFromData();// só recebo a key do cli
                rsaCLient.FromXmlString(clientPubKey);//sendo esse o unico dado que tenho do cli
                Console.WriteLine("ok.");

                Console.WriteLine("client pub key:  {0}",clientPubKey);

                // Answer with a ACK
                Console.Write("Sending a pub Key... ");
                string serverPubKey = rsaServer.ToXmlString(false);
                msg = protocol.Make(ProtocolSICmdType.SECRET_KEY,serverPubKey);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("Sent pub key: {0}",serverPubKey);
                #endregion
                Console.WriteLine(SEPARATOR);

                #region Exchange Secret Key
                // Receive the key
                Console.Write("waiting for key... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                tripleDES.Key = rsaServer.Decrypt(protocol.GetData(),true);//enquanto que aqui é que tenho dados
                Console.WriteLine("ok.");
                Console.WriteLine("Received: {0}", ProtocolSI.ToHexString(tripleDES.Key));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");

                // Receive the iv
                Console.Write("waiting for iv... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                tripleDES.IV = rsaServer.Decrypt(protocol.GetData(),true);//enquanto que aqui é que tenho dados
                Console.WriteLine("ok.");
                Console.WriteLine("Received: {0}", ProtocolSI.ToHexString(tripleDES.IV));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data  (secure channel)
                // Receive the cipher data
                Console.Write("waiting for data... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                byte[] data = symmetricsSI.Decrypt(protocol.GetData()); 
                Console.WriteLine("ok.");
                Console.WriteLine("Encrypted data received (HEX): {0}", ProtocolSI.ToHexString(protocol.GetData()));
                Console.WriteLine("Decrypted data......... (HEX): {0}", ProtocolSI.ToHexString(data));
                Console.WriteLine("Decrypted data......... (STR): {0}", ProtocolSI.ToString(data));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
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
                // Close connections
                if (netStream != null)
                    netStream.Dispose();
                if (client != null)
                    client.Close();
                if (server != null)
                    server.Stop();
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with client was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key... ");
            Console.ReadKey();
        }
    }
}
