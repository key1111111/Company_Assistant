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
                AskQuestionHandler handler) =>
            {
                return Results.Ok(
                    await handler.HandleAsync(
                        request));
            });
    }
}