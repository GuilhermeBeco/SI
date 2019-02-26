using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Client
    {
        private const int PORT = 9999;
        private const int MAX_BUFFER_SIZE = 1024;
        

        static void Main(string[] args)
        {
            TcpClient client = null;
            Random rnd = new Random();
            NetworkStream stream = null;
            byte[] buffer = null;
            int bytesRead = 0;
            int keyAux = 0;
            int resMsg = 0;
            int i = 0;
              
            try
            {
                string men = "EI SI";
                char[] msg = new char [men.Length];
                
                client = new TcpClient();
                client.Connect(IPAddress.Loopback, PORT);
                stream = client.GetStream();
                buffer = new byte[MAX_BUFFER_SIZE];
                msg = men.ToCharArray(0,men.Length); ;
                //------------------------------
                #region Client comm block
                //string msg = "EI SI";
                  int key = rnd.Next(1, 26);
                #region cifrar
                   Console.WriteLine(key);
                do
                    {

                    resMsg = (int)msg[i];
                    if (resMsg != 32)
                    {
                        if (resMsg + key <= 90)
                        {
                            resMsg += key;

                        }
                        else
                        {
                            keyAux = 90 - resMsg;
                          
                            resMsg = 65;
                            resMsg += key-keyAux;

                        }
                    }
                    
                    msg[i] =(char)resMsg;
                    i++;
                } while (i < msg.Length);
                #endregion
                Console.WriteLine(msg);
                   byte[] packet = Encoding.UTF8.GetBytes(msg);
                   stream.Write(packet, 0, packet.Length);
                   Console.WriteLine("Sent data to server");

                   bytesRead=stream.Read(buffer, 0, MAX_BUFFER_SIZE);
                   Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                //---key
                packet = BitConverter.GetBytes(key);
                stream.Write(packet, 0, packet.Length);
                //---key
                //-------------------------*/
                #endregion
                int num = 47;
                packet = BitConverter.GetBytes(num);
                stream.Write(packet, 0, packet.Length);
                Console.WriteLine("Sent data to server");

                bytesRead = stream.Read(buffer, 0, MAX_BUFFER_SIZE);
                Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                                
                stream.Write(packet, 0, packet.Length);
                Console.WriteLine("Sent data to server");
                
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

            }
            Console.ReadKey();
        }
    }
   
}
