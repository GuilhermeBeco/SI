using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exercice2_Server
{

    class Server
    {
        private const int PORT = 9999;
        private const int MAX_BUFFER_SIZE = 1024;
        static void Main(string[] args)
        {
            TcpClient client = null;
            TcpListener server = null;
            NetworkStream stream = null;
            byte[] buffer = null;
            int bytesRead = 0;
            int keyAux = 0;
            int resMsg = 0;
            int i = 0;

            try
            {
                buffer = new byte[MAX_BUFFER_SIZE];
                //---Server init
                server = new TcpListener(IPAddress.Any, PORT);
                server.Start();
                client = server.AcceptTcpClient();
               //--
                stream = client.GetStream();
                buffer = new byte[MAX_BUFFER_SIZE];
                //------------------------------
                #region Server comm block
                var ack = Encoding.UTF8.GetBytes("ACK");
                bytesRead = stream.Read(buffer, 0, MAX_BUFFER_SIZE);
                Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                stream.Write(ack, 0, ack.Length);
                Console.WriteLine("ACKnoledge");
                #region vars decode

                string msgCrypto = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                char[] msg = new char[msgCrypto.Length];
                msg = msgCrypto.ToCharArray(0, msgCrypto.Length);
                #endregion
               
                #endregion
                //--
                bytesRead = stream.Read(buffer, 0, MAX_BUFFER_SIZE);
                Console.WriteLine(BitConverter.ToInt32(buffer, 0));
                stream.Write(ack, 0, ack.Length);
                Console.WriteLine("ACKnoledge");
                #region decode
                int key = BitConverter.ToInt32(buffer, 0);
               // Console.WriteLine(key);
               do{

                    resMsg = (int)msg[i];
                    if (resMsg != 32)
                    {
                        if (resMsg - key >= 65)
                        {
                            resMsg -= key;

                        }
                        else
                        {
                            keyAux = resMsg-65;

                            resMsg = 90;
                            resMsg -= key - keyAux;

                        }
                    }

                    msg[i] = (char)resMsg;
                    i++;
                } while (i < msg.Length);
                Console.WriteLine(msg);
                
                #endregion
                              //-------------------------
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (client != null)
                {
                    client.Close();
                }
                if (server != null)
                {
                    server.Stop();
                }

            }
            Console.ReadKey();
        }
    }
}
