using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EI.SI;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace Client
{
    /// <summary>
    /// Client
    /// </summary>
    class Client
    {
        public static string SEPARATOR = "...";

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
            AesCryptoServiceProvider algorithm = null;
            SymmetricsSI symmetricsSI = null;


            try
            {
                Console.WriteLine("CLIENT");

                #region Defenitions
                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                // Defenitions for TcpClient: IP:port (127.0.0.1:9999)
                serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                algorithm = new AesCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(algorithm);
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
                #region exchange secret key

                // Send data...
                
                Console.Write("Sending key... ");
                msg = protocol.Make(ProtocolSICmdType.SECRET_KEY,algorithm.Key);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("Sent: {0}",ProtocolSI.ToHexString(algorithm.Key));

                // Receive answer from server
                Console.Write("waiting for ACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok.");

                #endregion
                Console.WriteLine(SEPARATOR);
                Console.WriteLine(SEPARATOR);

                #region exchange IV
                Console.Write("Sending IV... ");
                msg = protocol.Make(ProtocolSICmdType.IV, algorithm.IV);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("Sent: {0}", ProtocolSI.ToHexString(algorithm.IV));

                // Receive answer from server
                Console.Write("waiting for ACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok.");
                #endregion
                Console.WriteLine(SEPARATOR);

                #region Exchange Data (Unsecure channel)
                // Send data...
                string clearData = "hello world!!!";
                byte[] clearBytes = Encoding.UTF8.GetBytes(clearData);
                byte[] encryptedBytes = symmetricsSI.Encrypt(clearBytes);
                Console.Write("Sending data... ");
                msg = protocol.Make(ProtocolSICmdType.SYM_CIPHER_DATA, encryptedBytes);
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok.");
                Console.WriteLine("   Sent: {0} = {1}", clearData, ProtocolSI.ToHexString(encryptedBytes));

                // Receive answer from server
                Console.Write("waiting for ACK/NACK... ");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                if(protocol.GetCmdType()==ProtocolSICmdType.ACK)
                     Console.WriteLine("ok.");
                else
                    Console.WriteLine("NOT ok.");
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
                if (algorithm != null)
                    algorithm.Dispose();
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with server was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }
    }
}
