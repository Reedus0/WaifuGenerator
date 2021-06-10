using System;


namespace WaifuGenerator
{
    class Program
    {
        public static string UserName { get; }
        static void Main(string[] args)
        {
            System.Net.WebRequest reqGET = null;
            Console.WriteLine("SFW or NSFW?");
            string nsfwStr = Console.ReadLine();
            Console.WriteLine("Types:\n");
            bool nsfw = false;
            string type = "";
            if (nsfwStr.StartsWith("n"))
            {
                nsfw = true;
                Console.WriteLine("waifu\n");
                Console.WriteLine("neko\n");
                Console.WriteLine("blowjob\n");
                type = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("waifu\n");
                Console.WriteLine("neko\n");
                Console.WriteLine("kiss\n");
                Console.WriteLine("dance\n");
                Console.WriteLine("smile\n");
                type = Console.ReadLine();
            }
            if (nsfw)
            {
                string word = "";
                char letter = type[0];
                switch(letter.ToString())
                {
                    case "w":
                        word = "waifu";
                        break;
                    case "n":
                        word = "neko";
                        break;
                    case "b":
                        word = "blowjob";
                        break;
                    default:
                        word = "waifu";
                        break;
                }
                string link = String.Format("https://api.waifu.pics/nsfw/{0}", word);
                reqGET = System.Net.WebRequest.Create(link);
            }
            else
            {
                string word = "";
                char letter = type[0];
                switch (letter.ToString())
                {
                    case "w":
                        word = "waifu";
                        break;
                    case "n":
                        word = "neko";
                        break;
                    case "k":
                        word = "kiss";
                        break;
                    case "d":
                        word = "dance";
                        break;
                    case "s":
                        word = "smile";
                        break;
                    default:
                        word = "waifu";
                        break;
                }
                string link = String.Format("https://api.waifu.pics/sfw/{0}", word);
                reqGET = System.Net.WebRequest.Create(link);
            }
            System.Net.WebResponse resp = reqGET.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            var s = sr.ReadToEnd();
            System.Collections.Generic.List<string> letters = new System.Collections.Generic.List<string>();
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
            string localFilename;
            if (result.Substring(result.Length-1) == "f")
            {
                localFilename = "WaifuGif.gif";
                try
                {
                    System.IO.File.Delete("WaifuJpg.jpg");
                }
                catch
                {
                    
                }
            }
            else
            {
                localFilename = "WaifuJpg.jpg";
                try
                {
                    System.IO.File.Delete("WaifuGif.gif");
                }
                catch
                {

                }
            }
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.DownloadFile(result, localFilename);
            }
            Console.WriteLine("Done, check the folder");
            Console.ReadLine();
        }
    }
}
