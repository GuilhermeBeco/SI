using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

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
            SHA256CryptoServiceProvider sha = null;
            int[] id = { 123, 234, 345, 456 };
            double[] balance= { 455.02, 124.00, 987.00, 1000.94 };
            try
            {
                Console.WriteLine("SERVER");

                #region Defenitions
                sha = new SHA256CryptoServiceProvider();
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
               
                
                    // Waits for a client connection (bloqueant wait)
                server.Start();
                Console.Write("waiting for a connection... ");
                while (true)
                {
                    client = server.AcceptTcpClient();

                    Thread tcpListenerThread = new Thread(() =>
                    {
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

                        Console.WriteLine(SEPARATOR);

                        #region Exchange Sign (Secure channel)                
                        // Receive the cipher
                        Console.Write("waiting for data...");
                        netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                        byte[] signature = protocol.GetData();

                        int y = 0;
                        bool isVerified = false;
                        do
                        {
                            byte[] data = BitConverter.GetBytes(id[y]);
                            byte[] hash = sha.ComputeHash(data);
                            isVerified = rsaClient.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA256"), signature);
                            y++;
                        } while (!isVerified && y < id.Length);
                        y--;
                        Console.WriteLine(isVerified);
                        Console.WriteLine(y);
                        // Answer with a ACK
                        Console.Write("Sending a Balance/NACK... ");
                        if (isVerified)
                        {
                            Console.WriteLine(balance[y]);
                            msg = protocol.Make(ProtocolSICmdType.DATA, balance[y]);
                        }
                        else
                        {
                            msg = protocol.Make(ProtocolSICmdType.NACK);
                        }
                        netStream.Write(msg, 0, msg.Length);
                        Console.WriteLine("ok");
                        #endregion
                    });
                    //falta o eot
                    tcpListenerThread.Start();
                }
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
