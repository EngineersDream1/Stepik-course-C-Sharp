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

        public Task DeleteTopicAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TopicResponseDto> GetTopicAsync(Guid id)
        {
            TopicId topicId = TopicId.Of(id);
            var result = await dbContext.Topics.FindAsync([topicId]);

            if(result is null)
            {
                throw new TopicNotFoundException(id);
            }

            return result.ToTopicResponseDto();
        }

        public async Task<List<TopicResponseDto>> GetTopicsAsync()
        {
            var topics = await dbContext.Topics
                    .AsNoTracking()
                    .ToListAsync();

            return topics.ToTopicResponseDtoList();
        }

        public Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicRequestDto topicRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}
