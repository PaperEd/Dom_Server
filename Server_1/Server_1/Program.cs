using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class REST
    {
        public static void getUser(string url) // 유저 GET
        {
            string result = null;
            string user;
            user = Console.ReadLine();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "getUser/" + user);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
                stream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                JObject obj = JObject.Parse(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(result);
        }

    }


    class Program
    {

        static void Main(string[] args)
        {
            string url = "http://127.0.0.1:3000/";

            REST.getUser(url);
        }
    }
}
