using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.MessageData;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedContracts;

namespace Service1.Controllers
{
    [Route("api1/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public ValuesController(
            IBusControl busControl)
        {
            _busControl = busControl;
        }

        private readonly IBusControl _busControl;

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            Console.Out.WriteLine("TESTTTTTTTTTTTTTTT in get");

            var endpoint = await _busControl.GetSendEndpoint(new Uri("rabbitmq://172.18.0.2/message_type_queue"));
            await _busControl.Send<MessageType>(new MessageType() { Message="TEST MESSAGE"});

            //await _busControl.Publish(new MessageType() { Message = "TEST MESSAGE *******" });
            return new string[] { "value100", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
