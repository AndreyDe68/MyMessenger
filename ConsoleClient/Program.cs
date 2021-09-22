using System;
using Newtonsoft.Json;
namespace MyMessenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Message msg = new Message("AndrewDe", "Hi!", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message desMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(desMsg);

            //{ "Username":"AndrewDe","MessageText":"Hi!","TimeStamp":"2021-09-22T11:03:43.8272765Z"}
            //AndrewDe < 22.09.2021 11:03:43 >: Hi!
            //Console.WriteLine(msg.ToString());
        }
    }
}
