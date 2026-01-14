using Application.Topics.Commands.CreateTopic;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Topics.Commands.UpdateTopic
{
    public class UpdateTopicHandler(IApplicationDbContext dbContext, IMapper mapper) 
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

            mapper.Map(request.UpdateTopicDto, topic);

            await dbContext.SaveChangesAsync(CancellationToken.None);

            return new UpdateTopicResult(topic.ToTopicResponseDto());
        }
    }
}
