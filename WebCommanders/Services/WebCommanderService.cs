using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebCommanders.Services
{
    public class WebCommanderService : WebSocketBehavior
    {
        protected override void OnOpen()
        {
            Console.WriteLine("on open");
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine("recieved message");
            Console.WriteLine($"e.IsText = {e.IsText}");
            Console.WriteLine($"Data = {e.Data}");

            Console.WriteLine("attempting to parse as json");

            JObject deser;
            try
            {
                deser = JsonConvert.DeserializeObject<JObject>(e.Data);
                Console.WriteLine("Successfully deserialized, reserialized version:");
                Console.WriteLine(JsonConvert.SerializeObject(deser));
            }
            catch(JsonException exc)
            {
                Console.WriteLine($"Failed to deserialize: {exc.Message}");
                Console.WriteLine("Disconnecting");
                Sessions.CloseSession(ID);
            }

        }

        protected override void OnError(ErrorEventArgs e)
        {
            Console.WriteLine("on error");
            Console.WriteLine(e.Message);
            Console.WriteLine(e.Exception);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Console.WriteLine("on close");
        }
    }
}
