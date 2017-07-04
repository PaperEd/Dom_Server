using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Web;


namespace Server_1
{
    

    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://127.0.0.1:3000/";

            Command.addUser(url);
        }
    }
}
