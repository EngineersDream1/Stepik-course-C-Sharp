using Application.Topics.Commands.CreateTopic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Topics.Commands.UpdateTopic
{
    internal class UpdateTopicHandler(IApplicationDbContext dbContext) 
        : ICommandHandler<UpdateTopicCommand, UpdateTopicResult>
    {
        public async Task<UpdateTopicResult> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
        {
            TopicId topicId = TopicId.Of(request.TopicId);
            var topic = await dbContext.Topics.FindAsync(topicId);

            if (topic is null || topic.IsDeleted)
            {
                throw new TopicNotFoundException(request.TopicId);
            }

            topic.Update(
                request.UpdateTopicDto.Title,
                request.UpdateTopicDto.Summary,
                request.UpdateTopicDto.TopicType,
                request.UpdateTopicDto.EventStart,
                request.UpdateTopicDto.Location.City,
                request.UpdateTopicDto.Location.Street
            );

            await dbContext.SaveChangesAsync(CancellationToken.None);

            return new UpdateTopicResult(topic.ToTopicResponseDto());
        }
    }
}
