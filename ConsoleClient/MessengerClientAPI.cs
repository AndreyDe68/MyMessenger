using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyMessenger
{
    class MessengerClientAPI
    {
        public void TestNewtonsoftJson()
        {
            Message msg = new Message("AndrewDe", "Hi!", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message desMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(desMsg);
        }

        public Message GetMessage(int MessageId)
        {
            WebRequest request = WebRequest.Create("http://localhost:5000/api/Messenger/" + MessageId.ToString());
            request.Method = "Get";
            WebResponse response = request.GetResponse();
            string status = ((HttpWebResponse)response).StatusDescription;
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();
            if ((status.ToLower() == "ok") && (responseFromServer != "Not found"))
            {
                Message desMsg = JsonConvert.DeserializeObject<Message>(responseFromServer);
                return desMsg;
            }
            return null;
        }

        public bool SendMessage(Message msg)
        {
            //Создаем запрос
            WebRequest request = WebRequest.Create("http://localhost:5000/api/Messenger");
            request.Method = "POST";
            //записываем сообщение в postData и перекодируем в UTF8
            string postData = JsonConvert.SerializeObject(msg);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //в запросе указываем json формат
            request.ContentType = "application/json";
            //длина тела запроса
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            //отлавливаем ответ
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            //читаем ответ
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return true;
        }
    }
}
