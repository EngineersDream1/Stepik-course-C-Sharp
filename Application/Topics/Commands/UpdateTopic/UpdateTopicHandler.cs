using Application.Topics.Commands.CreateTopic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Topics.Commands.UpdateTopic
{
    internal class UpdateTopicHandler(IApplicationDbContext dbContext) : ICommandHandler<UpdateTopicCommand, UpdateTopicResult>
    {
        public async Task<UpdateTopicResult> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
        {
            TopicId topicId = TopicId.Of(request.TopicId);
            var topic = await dbContext.Topics.FindAsync(topicId);

            if (topic is null || topic.IsDeleted)
            {
                throw new TopicNotFoundException(request.TopicId);
            }

            topic.Title = request.TopicDto.Title ?? topic.Title;
            topic.Summary = request.TopicDto.Summary ?? topic.Summary;
            topic.TopicType = request.TopicDto.TopicType ?? topic.TopicType;
            topic.EventStart = request.TopicDto.EventStart;
            topic.Location = Location.Of(
                request.TopicDto.Location.City,
                request.TopicDto.Location.Street
            );

            await dbContext.SaveChangesAsync(CancellationToken.None);

            return new UpdateTopicResult(topic.ToTopicResponseDto());
        }
    }
}
