using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EI.SI;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Server
{
    /// <summary>
    /// Server
    /// </summary>
    class Server
    {
        public static string SEPARATOR = "...";

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
            AesCryptoServiceProvider algorithm = null;
            SymmetricsSI symmetricsSI = null;

            try
            {
                Console.WriteLine("SERVER");

                #region Defenitions
                // Binding IP/port
                listenEndPoint = new IPEndPoint(IPAddress.Any, 9999);

                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                algorithm = new AesCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(algorithm);

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

                #region receive key (Unsecure channel)                
                // Receive the cipher data
                Console.Write("waiting for data... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                algorithm.Key = protocol.GetData();
                Console.WriteLine("ok.");
                Console.WriteLine("   Received: {0}", ProtocolSI.ToHexString(algorithm.Key));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                #endregion

                Console.WriteLine(SEPARATOR);
                #region receive IV (Unsecure channel)                
                // Receive the cipher data
                Console.Write("waiting for data... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                algorithm.IV = protocol.GetData();
                Console.WriteLine("ok.");
                Console.WriteLine("   Received: {0}", ProtocolSI.ToHexString(algorithm.IV));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Data (Unsecure channel)                
                // Receive the cipher data
                Console.Write("waiting for data... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                byte[] encryptedBytes = protocol.GetData();
                byte[] clearBytes= symmetricsSI.Decrypt(encryptedBytes);
                string clearData = Encoding.UTF8.GetString(clearBytes);
                Console.WriteLine("ok.");
                Console.WriteLine("   Received: {0} = {1}", clearData, ProtocolSI.ToHexString(encryptedBytes));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocol.Make(ProtocolSICmdType.ACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                #endregion

            }
            catch (CryptographicException exception)
            {
                // Answer with a ACK
                Console.Write("Sending a NACK... ");
                msg = protocol.Make(ProtocolSICmdType.NACK);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
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
                if (algorithm != null)
                    algorithm.Dispose();
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with client was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }
    }
}
