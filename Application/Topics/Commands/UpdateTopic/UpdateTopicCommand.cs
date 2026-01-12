namespace Application.Topics.Commands.UpdateTopic
{
    public record UpdateTopicCommand(Guid TopicId, UpdateTopicRequestDto TopicDto) : ICommand<UpdateTopicResult>;

    public record UpdateTopicResult(TopicResponseDto Result);
}
