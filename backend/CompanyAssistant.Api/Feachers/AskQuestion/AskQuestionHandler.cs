namespace CompanyAssistant.Api.Features.AskQuestion;

public class AskQuestionHandler
{
    private readonly IKnowledgeBaseService _kb;

    public AskQuestionHandler(
        IKnowledgeBaseService kb)
    {
        _kb = kb;
    }

    public async Task<AskQuestionResponse>
        HandleAsync(
            AskQuestionRequest request)
    {
        var result =
            await _kb.SearchAsync(
                request.Question);

        return new AskQuestionResponse(
            result.Content,
            result.Source);
    }
}