using EI.SI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3Client
{
    class Client
    {
        private const int PORT = 9999;

        static void Main(string[] args)
        {
            TcpClient client = null;
            NetworkStream stream = null;
            ProtocolSI protocolo = null;
            try
            {

                protocolo = new ProtocolSI();
                client = new TcpClient();
                client.Connect(IPAddress.Loopback, PORT);
                stream = client.GetStream();
                string opt = null;
                int send = 47;
                string send2 = "HI";
                byte[] packet = null;
                #region Cli protocol
                do
                {
                    Console.WriteLine("1) INT 2) STRING 9)END");
                    opt = Console.ReadLine();
                    switch (opt)
                    {
                        case "1":
                            packet = protocolo.Make(ProtocolSICmdType.USER_OPTION_1, send);
                            break;
                        case "2":
                            packet = protocolo.Make(ProtocolSICmdType.USER_OPTION_2, send2);
                            break;
                        case "9":
                            packet = protocolo.Make(ProtocolSICmdType.EOT);
                            break;
                        default:
                            Console.WriteLine("Opt invalida");
                            continue;
                    }
                    stream.Write(packet, 0, packet.Length);
                    Console.WriteLine("Sent data to server");

                    stream.Read(protocolo.Buffer, 0, protocolo.Buffer.Length);
                    if (protocolo.GetCmdType() == ProtocolSICmdType.ACK)
                    {
                        Console.WriteLine("Recieved ack");
                    }
                } while (opt!="9");
                Console.WriteLine("EOT");
                #endregion

                //------------------------------

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
