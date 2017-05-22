using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCommanders.Services;
using WebSocketSharp.Server;

namespace WebCommanders
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new WebSocketServer(8081);

            server.AddWebSocketService<WebCommanderService>("/Play");

            server.Start();

            Console.ReadLine();

            server.Stop();
        }
    }
}
