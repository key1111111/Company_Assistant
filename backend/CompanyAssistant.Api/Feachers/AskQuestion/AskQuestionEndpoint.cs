using CompanyAssistant.Api.Services;

namespace CompanyAssistant.Api.Features.AskQuestion;

public static class AskQuestionEndpoint
{
    public static void MapAskQuestion(
        this WebApplication app)
    {
        app.MapPost(
            "/api/ask",
            async (
                AskQuestionRequest request,
                IKnowledgeBaseService kb) =>
            {
                var result =
                    await kb.SearchAsync(
                        request.Question);

                return Results.Ok(
                    new AskQuestionResponse(
                        result.Content,
                        result.Source));
            });
    }
}