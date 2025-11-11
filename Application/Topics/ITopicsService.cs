namespace Application.Topics
{
    public interface ITopicsService
    {
        Task<List<TopicResponseDto>> GetTopicsAsync();
        Task<TopicResponseDto> GetTopicAsync(Guid id);
        Task<TopicResponseDto> CreateTopicAsync(CreateTopicRequestDto dto);
        Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicRequestDto dto);
        Task DeleteTopicAsync(Guid id);
    }
}
