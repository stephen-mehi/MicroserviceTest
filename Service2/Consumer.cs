
using MassTransit;
using MassTransit.MessageData;
using Newtonsoft.Json;
using SharedContracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Service2
{
    public class TestType
    {
        public string Message { get; set; }
    }

    public class TestConsumer : IConsumer<MessageType>
    {

        public Task Consume(ConsumeContext<MessageType> context)
        {
            Console.Out.WriteLine("TESTTTTTTTTTTTTTTT in consume");
            context.Publish<TestType>(new { Message = "test message" });
            return Task.CompletedTask;
        }
    }
}
