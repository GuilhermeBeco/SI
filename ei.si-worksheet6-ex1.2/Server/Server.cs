using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace EI.SI
{
    /// <summary>
    /// Server
    /// Symmetrics (Encryption)
    /// </summary>
    class ServerWithProtocolSI
    {
        public static string SEPARATOR = "...";

        /// <summary>
        /// IMPORTANTE: a cada RECEÇÃO deve seguir-se, obrigatóriamente, um ENVIO de dados
        /// IMPORTANT: each network .Read must be fallowed by a network .Write
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            byte[] msg;
            IPEndPoint listenEndPoint;
            TcpListener server = null;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;
            AesCryptoServiceProvider aes = null;
            SymmetricsSI symmetricsSI = null;
            RSACryptoServiceProvider rsaClient = null;
            RSACryptoServiceProvider rsaServer = null;

            try
            {
                Console.WriteLine("SERVER");

                #region Defenitions
                // algortimos assimétricos
                rsaClient = new RSACryptoServiceProvider();
                rsaServer = new RSACryptoServiceProvider();

                // algoritmos simétrico a usar...
                aes = new AesCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(aes);

                // Binding IP/port
                listenEndPoint = new IPEndPoint(IPAddress.Any, 13000);
                
                // Client/Server Protocol to SI
                protocol = new ProtocolSI();


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
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exhange Public Keys
                // Receive client public key
                Console.Write("waiting for client public key...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                rsaClient.FromXmlString(protocol.GetStringFromData());
                Console.WriteLine("ok");

                // Send public key...
                Console.Write("Sending public key... ");
                msg = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, rsaServer.ToXmlString(false));
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Secret Key               
                // Receive key
                Console.Write("waiting for key...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                aes.Key = rsaServer.Decrypt(protocol.GetData(), true);
                Console.WriteLine("ok");
                Console.WriteLine("   Received: {0} ", ProtocolSI.ToHexString(aes.Key));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");


                // Receive iv
                Console.Write("waiting for iv...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                aes.IV = rsaServer.Decrypt(protocol.GetData(), true);
                Console.WriteLine("ok");
                Console.WriteLine("   Received: {0} ", ProtocolSI.ToHexString(aes.IV));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data (Secure channel)                
                // Receive the cipher
                Console.Write("waiting for data...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                byte[] encryptedData = protocol.GetData();
                byte[] data = symmetricsSI.Decrypt(encryptedData);
                Console.WriteLine("ok");
                Console.WriteLine("   Encrypted: {0}", ProtocolSI.ToHexString(encryptedData));
                Console.WriteLine("   Data: {0} = {1}", ProtocolSI.ToString(data), ProtocolSI.ToHexString(data));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
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
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }

    }
}
