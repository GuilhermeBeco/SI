using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MITM
{
    class Program
    {
        private const int PORT_SERVER = 9999;
        private const int PORT_CLIENT = 9998;
        static void Main(string[] args)
        {
            TcpClient client = null;
            TcpListener server = null;
            NetworkStream stream = null;
            ProtocolSI protocolo = null;
            try
            {
                server = new TcpListener(IPAddress.Any, PORT_CLIENT);
                server.Start();
                client = server.AcceptTcpClient();
                protocolo = new ProtocolSI();
                byte[] pack = null;
                stream = client.GetStream();
                
                #region server protocol
                do
                {
                    stream.Read(protocolo.Buffer, 0, protocolo.Buffer.Length);

                    switch (protocolo.GetCmdType())
                    {
                        case ProtocolSICmdType.USER_OPTION_1:
                            Console.WriteLine(protocolo.GetIntFromData());
                           pack=protocolo.Make(ProtocolSICmdType.USER_OPTION_1, protocolo.GetIntFromData());
                            break;
                        case ProtocolSICmdType.USER_OPTION_2:
                            Console.WriteLine(protocolo.GetStringFromData());
                            pack = protocolo.Make(ProtocolSICmdType.USER_OPTION_2, protocolo.GetStringFromData());
                            break;
                        case ProtocolSICmdType.EOT:
                            Console.WriteLine("EOT");
                            pack = protocolo.Make(ProtocolSICmdType.EOT);
                            break;

                    }
                    var packet = protocolo.Make(ProtocolSICmdType.ACK);
                    stream.Write(packet, 0, packet.Length);
                    Console.WriteLine("Sent ack");
                } while (protocolo.GetCmdType() != ProtocolSICmdType.EOT);
                //  Console.WriteLine("EOT");
                #endregion

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
        }
    }
}
