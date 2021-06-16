using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace ConsoleApp1
{
    internal class Program
    {
        private static async Task Main()
        {
            var hub = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/".TrimEnd('/') + "/MyHub")
                .WithAutomaticReconnect()
                .Build();
            await hub.StartAsync();
            hub.On<Msg>("Msg", message =>
            {
                Console.WriteLine("Received!");
            });
            Console.ReadLine();
        }

    }

    internal class Msg
    {
        public byte[] Juhu { get; set; }
    }
}