using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Json;
using System.Web;

namespace Client
{
    class Command
    {
        public static void getUser(string url) // 유저 GET
        {
            string result = null;
            string user;
            Console.Write("조회할 학생의 이름을 입력해주세요 : ");
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

            Console.WriteLine(result);
        }

        public static void addUser(string url)
        {
            Console.Write("추가할 사용자의 이름을 입력해주세요 : ");
            string UserName = Console.ReadLine();
            Console.Write("사용자의 번호를 입력해주세요 : ");
            string number = Console.ReadLine();
            Console.Write("사용자가 받을 점수를 입력해주세요 :");
            string score = Console.ReadLine();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "addUser/" + UserName);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{" +
                                "\"number\":" + number + "," +
                                "\"score\":" + score +
                              "}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
        
        public static void updateUser(string url)
        {
            Console.Write("추가할 사용자의 이름을 입력해주세요 : ");
            string UserName = Console.ReadLine();
            Console.Write("사용자의 번호를 입력해주세요 : ");
            string number = Console.ReadLine();
            Console.Write("사용자가 받을 점수를 입력해주세요 :");
            string score = Console.ReadLine();
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "updateUser/" + UserName);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{" +
                                "\"number\":" + number + "," +
                                "\"score\":" + score +
                              "}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static void deleteUser(string url)
        {
            string user = Console.ReadLine();
            url = url + "deleteUser/" + user;

            WebRequest request = WebRequest.Create(url);
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }

        public static void getallUser(string url) // 유저 GET
        {
            string result = null;
            string user;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "list");
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

            Console.WriteLine(result);
        }

    }
}
