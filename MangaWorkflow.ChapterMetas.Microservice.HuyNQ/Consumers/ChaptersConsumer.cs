using MangaWorkflow.BusinessObject.Shared.Models.HuyNQ;
using MassTransit;
using System.Text.Json;

namespace MangaWorkflow.ChapterMetas.Microservice.HuyNQ.Consumers
{
    public class ChaptersConsumer(ILogger<ChaptersConsumer> logger) : IConsumer<ChapterHuyNq>
    {
        private readonly ILogger _logger = logger;

        public Task Consume(ConsumeContext<ChapterHuyNq> context)
        {
            var receiveMsg = context.Message;

            var msg = string.Format("{0}: RECEIVE the event from chapterQueue queue on RabbitMQ: {1}", DateTime.Now, receiveMsg);
            _logger.LogInformation(msg);

            Serilog.Log.Information(msg);

            return Task.CompletedTask;
        }
    }
}
