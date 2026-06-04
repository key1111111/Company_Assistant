

public interface IKnowledgeBaseService
{
    Task<SearchResult> SearchAsync(string question);
}