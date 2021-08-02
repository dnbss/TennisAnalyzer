using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace HttpListen
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            // установка адресов прослушки
            listener.Prefixes.Add("https://www.tennislive.net/wta/match/varvara-lepchenko-VS-lauren-davis/charleston-charleston-2021/");
            listener.Start();
            Console.WriteLine("Ожидание подключений...");
            // метод GetContext блокирует текущий поток, ожидая получение запроса 
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            // получаем объект ответа
            HttpListenerResponse response = context.Response;
            // создаем ответ в виде кода html
            string responseStr = "";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
            // получаем поток ответа и пишем в него ответ
            response.ContentLength64 = buffer.Length;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // закрываем поток
            output.Close();
            // останавливаем прослушивание подключений
            listener.Stop();
            Console.WriteLine("Обработка подключений завершена");
            Console.Read();
        }

        
    }
}
