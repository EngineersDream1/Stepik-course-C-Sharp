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
        Task<List<Topic>> GetTopicsAsync();
        Task<Topic> GetTopicAsync(Guid id);
        Task<Topic> CreateTopicAsync(Topic topicRequestDto);
        Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto);
        Task DeleteTopicAsync(Guid id);
    }
}
