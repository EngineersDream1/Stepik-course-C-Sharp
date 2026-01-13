namespace Application.Topics.Commands.UpdateTopic
{
    public record UpdateTopicCommand(Guid TopicId, UpdateTopicRequestDto UpdateTopicDto) 
        : ICommand<UpdateTopicResult>;

    public record UpdateTopicResult(TopicResponseDto Result);
}
