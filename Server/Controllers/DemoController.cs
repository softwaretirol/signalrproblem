using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace WebApplication3.Controllers
{
    public class DemoController : ControllerBase
    {
        public class MyHub : Hub
        {
        }
        private readonly IHubContext<MyHub> hub;

        public DemoController(IHubContext<MyHub> hub)
        {
            this.hub = hub;
        }

        [Route("Juhu")]
        [HttpGet]
        public async Task Start()
        {
            var r = new Random();
            for (var i = 0; i < 100; i++)
            {
                var data = new byte[1024 * 1024];
                r.NextBytes(data);
                await hub.Clients.All.SendAsync("Msg", new
                {
                    Juhu = data
                });
                await Task.Delay(100);
            }
        }
    }
}