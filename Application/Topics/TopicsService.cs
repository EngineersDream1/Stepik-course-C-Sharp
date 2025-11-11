using Application.Data.DataBaseContext;
using Application.Dtos;
using Application.Exceptions;
using Application.Extensions;
using Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Application.Topics
{
    public class TopicsService(IApplicationDbContext dbContext, ILogger<TopicsService> logger) : ITopicsService
    {        
        public async Task<TopicResponseDto> CreateTopicAsync(CreateTopicRequestDto dto)
        {
            Topic newTopic = Topic.Create(
                TopicId.Of(Guid.NewGuid()),
                dto.Title,
                dto.EventStart,
                dto.Summary,
                dto.TopicType,
                Location.Of(dto.Location.City, dto.Location.Street)
            );

            dbContext.Topics.Add(newTopic);
            await dbContext.SaveChangesAsync(CancellationToken.None);

            return newTopic.ToTopicResponseDto();
        }

        public async Task DeleteTopicAsync(Guid id)
        {
            TopicId topicId = TopicId.Of(id);
            var topic = await dbContext.Topics.FindAsync(topicId);

            if (topic is null || topic.IsDeleted)
            {
                throw new TopicNotFoundException(id);
            }

            //dbContext.Topics.Remove(topic);

            topic.IsDeleted = true;
            topic.DeletedAt = DateTimeOffset.UtcNow;

            await dbContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<TopicResponseDto> GetTopicAsync(Guid id)
        {
            TopicId topicId = TopicId.Of(id);
            var result = await dbContext.Topics.FindAsync([topicId]);

            if(result is null || result.IsDeleted)
            {
                throw new TopicNotFoundException(id);
            }

            return result.ToTopicResponseDto();
        }

        public async Task<List<TopicResponseDto>> GetTopicsAsync()
        {
            var topics = await dbContext.Topics
                    .AsNoTracking()
                    .Where(t => !t.IsDeleted)
                    .ToListAsync();

            return topics.ToTopicResponseDtoList();
        }

        public async Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicRequestDto dto)
        {
            TopicId topicId = TopicId.Of(id);
            var topic = await dbContext.Topics.FindAsync(topicId);

            if(topic is null || topic.IsDeleted)
            {
                throw new TopicNotFoundException(id);
            }

            topic.Title = dto.Title ?? topic.Title;
            topic.Summary = dto.Summary ?? topic.Summary;
            topic.TopicType = dto.TopicType ?? topic.TopicType;
            topic.EventStart = dto.EventStart ;
            topic.Location = Location.Of(
                dto.Location.City,
                dto.Location.Street
            );
            
            await dbContext.SaveChangesAsync(CancellationToken.None);

            return topic.ToTopicResponseDto();
        }
    }
}
