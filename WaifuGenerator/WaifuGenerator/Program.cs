using System;
using System.Net;
using System.Collections.Generic;
using System.Security.Principal;

namespace WaifuGenerator
{
    class Program
    {
        public static string UserName { get; }
        static void Main(string[] args)
        {
            System.Net.WebRequest reqGET = System.Net.WebRequest.Create(@"https://api.waifu.pics/sfw/waifu");
            System.Net.WebResponse resp = reqGET.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            var s = sr.ReadToEnd();
            List<string> letters = new List<string>();
            int j = 0;
            foreach (char i in s)
            {
                string str = i.ToString();
                if (str == "h")
                {
                    j = 1;
                }
                if (j == 1)
                {
                    letters.Add(str);
                }
            }
            var result = String.Join("", letters);
            string UserName = Environment.UserName;
            for(int k = 0; k < 3; k++)
            {
                result = result.Remove(result.Length - 1);
            }
            string localFilename = String.Format( @"C:\Users\{0}\Downloads\Waifu.jpg", UserName);
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(result, localFilename);
            }
            Console.WriteLine("Check your download directory");
            Console.WriteLine("Посмотри в папку загрузки");
        }
    }
}
