using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Web;


namespace Client
{
    

    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://127.0.0.1:3000/";
            string select;
            while(true)
            {
                //Console.Clear();
                Console.WriteLine("1 : 조회 \t2 : 추가 \t3 : 수정\t 4 : 삭제 \t전체 조회 : 5");
                select = Console.ReadLine();
                switch(select)
                {
                    case "1":
                        Command.getUser(url);
                        break;
                    case "2":
                        Command.addUser(url);
                        break;
                    case "3":
                        Command.updateUser(url);
                        break;
                    case "4":
                        Command.deleteUser(url);
                        break;
                    case "5":
                        Command.getallUser(url);
                        break;
                        
                }
            }
        }
    }
    
}
