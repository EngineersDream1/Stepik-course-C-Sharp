using Application.Dtos;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Topics
{
    public interface ITopicsService
    {
        Task<List<TopicResponseDto>> GetTopicsAsync();
        Task<TopicResponseDto> GetTopicAsync(Guid id);
        Task<TopicResponseDto> CreateTopicAsync(CreateTopicRequestDto dto);
        Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicRequestDto topicRequestDto);
        Task DeleteTopicAsync(Guid id);
    }
}
