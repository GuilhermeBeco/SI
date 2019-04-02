using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace EI.SI
{
    /// <summary>
    /// Client
    /// Symmetrics (Encryption)
    /// </summary>
    class ClientWithProtocolSI
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
            IPEndPoint serverEndPoint;
            TcpClient client = null;
            NetworkStream netStream = null;
            ProtocolSI protocol = null;
            AesCryptoServiceProvider aes = null;
            SymmetricsSI symmetricsSI = null;
            RSACryptoServiceProvider rsaClient = null;
            RSACryptoServiceProvider rsaServer = null;
            SHA256CryptoServiceProvider sha = null;

            try
            {
                Console.WriteLine("CLIENT");

                #region Defenitions
                // algortimos assimétricos
                sha = new SHA256CryptoServiceProvider();
                rsaClient = new RSACryptoServiceProvider();
                rsaServer = new RSACryptoServiceProvider();

                // algoritmos simétrico a usar...
                aes = new AesCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(aes);



                // Client/Server Protocol to SI
                protocol = new ProtocolSI();

                // Defenitions for TcpClient: IP:port (127.0.0.1:13000)
                serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 13000);
                #endregion

                Console.WriteLine(SEPARATOR);

                #region TCP Connection
                // Connects to Server ...
                Console.Write("Connecting to server... ");
                client = new TcpClient();
                client.Connect(serverEndPoint);
                netStream = client.GetStream();
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine(SEPARATOR);

                #region Exchange Public Keys
                // Send public key...
                Console.Write("Sending public key... ");
                msg = protocol.Make(ProtocolSICmdType.PUBLIC_KEY, rsaClient.ToXmlString(false));
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");

                // Receive server public key
                Console.Write("waiting for server public key...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                rsaServer.FromXmlString(protocol.GetStringFromData());
                Console.WriteLine("ok");
                #endregion

                

                Console.WriteLine(SEPARATOR);

                #region Exchange Secret Key
                // Send key...
                Console.Write("Sending  key... ");
                msg = protocol.Make(ProtocolSICmdType.SECRET_KEY, rsaServer.Encrypt(aes.Key, true));
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                Console.WriteLine("   Sent: " + ProtocolSI.ToHexString(aes.Key));

                // Receive ack
                Console.Write("waiting for ACK...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok");


                // Send iv...
                Console.Write("Sending  iv... ");
                msg = protocol.Make(ProtocolSICmdType.IV, rsaServer.Encrypt(aes.IV, true));
                netStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                Console.WriteLine("   Sent: " + ProtocolSI.ToHexString(aes.IV));

                // Receive ack
                Console.Write("waiting for ACK...");
                netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                Console.WriteLine("ok");

                #endregion

                Console.WriteLine(SEPARATOR);

                Console.WriteLine(SEPARATOR);

                #region parte interativa
                int opt = -1; //1 para saldo / 0 para sair
                string op = "";
                do
                {
                    Console.WriteLine("1-Obter saldo");
                    Console.WriteLine("0-sair");
                    Console.WriteLine("Qual a sua opcao: ");
                    op = Console.ReadLine();
                    opt = int.Parse(op);
                    if (opt == 1)
                    {
                      /*  #region Exchange Data (Secure channel)
                        // Send data...
                        byte[] clearData = Encoding.UTF8.GetBytes("hello world!!!");
                        Console.Write("Sending  data... ");
                        byte[] encryptedData = symmetricsSI.Encrypt(clearData);
                        msg = protocol.Make(ProtocolSICmdType.DATA, encryptedData);
                        netStream.Write(msg, 0, msg.Length);
                        Console.WriteLine("ok");
                        Console.WriteLine("   Data: {0} = {1}", ProtocolSI.ToString(clearData), ProtocolSI.ToHexString(clearData));
                        Console.WriteLine("   Encrypted: {0}", ProtocolSI.ToHexString(encryptedData));

                        // Receive answer from server
                        Console.Write("waiting for ACK...");
                        netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                        Console.WriteLine("ok");
                        #endregion
                        */

                        Console.WriteLine(SEPARATOR);

                        #region SendSign (Secure channel)
                        // Send data...
                        Console.WriteLine("Qual o seu numero de cliente no banco: ");
                        int num = int.Parse(Console.ReadLine());
                        byte[] bytesNum = BitConverter.GetBytes(num);


                        Console.Write("Sending  sign... ");
                        byte[] hash = sha.ComputeHash(bytesNum);
                        byte[] signature = rsaClient.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));
                        msg = protocol.Make(ProtocolSICmdType.DIGITAL_SIGNATURE, signature);
                        netStream.Write(msg, 0, msg.Length);
                        Console.WriteLine("ok");

                        // Receive answer from server
                        Console.Write("waiting for balance...");
                        netStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                        if (protocol.GetCmdType() == ProtocolSICmdType.DATA)
                        {
                            Console.Write(ProtocolSI.ConvertByteArrayToDouble(protocol.GetData()));
                        }
                        else
                        {
                            Console.WriteLine("Sign not valid");
                        }
                       
                        Console.WriteLine(SEPARATOR);
                        #endregion
                    }
                    else if (opt == 0)
                    {
                        Console.WriteLine("A sair...");
                    }
                    else
                    {
                        Console.WriteLine("Opcao inválida");
                    }

                    #endregion


                } while (opt != 0);
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
                Console.WriteLine(SEPARATOR);
                Console.WriteLine("Connection with server was closed.");
            }

            Console.WriteLine(SEPARATOR);
            Console.Write("End: Press a key...");
            Console.ReadKey();
        }

    }
}
