using JsonModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _01_Server
{
    class Program
    {
        const int port = 8888; // порт для прослушивания подключений
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                server = new TcpListener(IPAddress.Any, port);

                // запуск слушателя
                server.Start();

                while (true)
                {
                    IPAddress ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[1];
                    
                    Console.WriteLine("My IPAdress->  "+ip.ToString());


                    Console.WriteLine("Ожидание подключений... ");
                    while (true)
                    {
                        TcpClient client = server.AcceptTcpClient();
                        ClientObject clientObject = new ClientObject(client);

                        // создаем новый поток для обслуживания нового клиента
                        Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                        clientThread.Start();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }
        }
    }
}
