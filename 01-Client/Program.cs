using JsonModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _01_Client
{
    class Program
    {
        private const int port = 8888;

        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                //Console.WriteLine("Write ServerIp");
                //string server = Console.ReadLine();
                //To know serverIp your freand or yours :
                // call Windows Consol(Write "cmd" in search)
                // and in console write "ipconfig" and there you will see!)
                client.Connect("10.4.155.88", port);
                Console.WriteLine("Connect Succesful");

                User user = new User();
                user.Name = "Visual Studio";
                user.Message = "Pink";

                ////////
                NetworkStream streamS = client.GetStream();
                // сообщение для отправки клиенту
                
                // преобразуем сообщение в массив байтов
                byte[] dataS = Encoding.UTF8.GetBytes(JsonFortmat.GetJsonFromPackage(user));

                // отправка сообщения
                streamS.Write(dataS, 0, dataS.Length);
                Console.WriteLine("Отправлено сообщение: {0}", user);
                Thread.Sleep(1000);
                // закрываем подключение
                client.Close();
                ////////
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }

            Console.WriteLine("Запрос завершен...");
            Console.Read();
        }
    }
}
