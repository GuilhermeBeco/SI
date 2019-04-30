using EI.SI;
using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
            byte[] msg;
            IPEndPoint listenEndPoint;
            TcpListener server = null;
            TcpClient client = null;
            NetworkStream networkStream = null;
            ProtocolSI protocolSI = null;
            AesCryptoServiceProvider aes = null;
            SymmetricsSI symmetricsSI = null;
            RSACryptoServiceProvider rsaClient = null;
            RSACryptoServiceProvider rsaServer = null;
            SHA256CryptoServiceProvider sha = null;

            try
            {
                Console.WriteLine("Starting SERVER");

                #region Definitions
                
                rsaClient = new RSACryptoServiceProvider();
                rsaServer = new RSACryptoServiceProvider();

                aes = new AesCryptoServiceProvider();
                symmetricsSI = new SymmetricsSI(aes);

                // Binding IP/port
                listenEndPoint = new IPEndPoint(IPAddress.Any, 10000);

                // Client/Server Protocol to SI
                protocolSI = new ProtocolSI();

                // Hash Algorithm
                sha = new SHA256CryptoServiceProvider();

                #endregion


                #region TCP Listener
                // Start TcpListener
                server = new TcpListener(listenEndPoint);
                server.Start();

                // Waits for a client connection (blocking wait)
                Console.Write("waiting for a connection... ");
                client = server.AcceptTcpClient();
                networkStream = client.GetStream();
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine();

                #region Public Key Exchange
                // Receive client public key
                Console.Write("waiting for client public key...");
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                rsaClient.FromXmlString(protocolSI.GetStringFromData());
                Console.WriteLine("ok");
                Console.WriteLine("   Client Public Key: {0}", protocolSI.GetStringFromData());

                // Send public key...
                Console.Write("Sending public key... ");
                string serverPublicKey = rsaServer.ToXmlString(false);
                msg = protocolSI.Make(ProtocolSICmdType.PUBLIC_KEY, serverPublicKey);
                networkStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                Console.WriteLine("   Server Public Key: {0}", serverPublicKey);
                #endregion

                Console.WriteLine();

                #region Secret Key Exchange
                // Receive key
                Console.Write("waiting for key...");
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                aes.Key = rsaServer.Decrypt(protocolSI.GetData(), true);
                Console.WriteLine("ok");
                Console.WriteLine("   Received: {0} ", ProtocolSI.ToHexString(aes.Key));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocolSI.Make(ProtocolSICmdType.ACK);
                networkStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");


                // Receive iv
                Console.Write("waiting for iv...");
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);
                aes.IV = rsaServer.Decrypt(protocolSI.GetData(), true);
                Console.WriteLine("ok");
                Console.WriteLine("   Received: {0} ", ProtocolSI.ToHexString(aes.IV));

                // Answer with a ACK
                Console.Write("Sending a ACK... ");
                msg = protocolSI.Make(ProtocolSICmdType.ACK);
                networkStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");
                #endregion

                Console.WriteLine();

                #region Get Password (Secure channel)                
                // Receive the number of characters
                Console.Write("waiting for password request...");
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);

                byte[] numChars = protocolSI.GetData();
                byte[] clearData = symmetricsSI.Decrypt(numChars);

                int numberOfCharacters = BitConverter.ToInt16(clearData,0);
                // 6.1 Decrypt and replace the value of the previous variable

                string password = PasswordGenerator.GeneratePassword(numberOfCharacters);

                // 6.2 Answer with the encrypted Password
                byte[] pass = symmetricsSI.Encrypt(Encoding.UTF8.GetBytes(password));
                msg = protocolSI.Make(ProtocolSICmdType.SYM_CIPHER_DATA, pass);
                networkStream.Write(msg, 0, msg.Length);
                               

                #endregion

                Console.WriteLine();

                #region Integrity Confirmation

                // Receive the integrity confirmation request

                Console.Write("waiting for pasword...");
                networkStream.Read(protocolSI.Buffer, 0, protocolSI.Buffer.Length);


                // 7 Answer with encrypted signature of the password
                byte[] hash = sha.ComputeHash(pass);//zona critica
                byte[] signature = rsaServer.SignHash(hash, CryptoConfig.MapNameToOID("SHA256"));
                
                byte[] data = symmetricsSI.Encrypt(signature);
                Console.Write("Sending the encrypted signature... ");
                msg = protocolSI.Make(ProtocolSICmdType.SYM_CIPHER_DATA, data);
                networkStream.Write(msg, 0, msg.Length);
                Console.WriteLine("ok");

                #endregion

                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            finally
            {
                // Close connections
                if (networkStream != null)
                    networkStream.Dispose();
                if (client != null)
                    client.Close();
                if (server != null)
                    server.Stop();
                Console.WriteLine();
                Console.WriteLine("Connection with client was closed.");

                Console.WriteLine();
                Console.Write("End: Press a key...");
                Console.ReadKey();
            }
        }
    }
}
