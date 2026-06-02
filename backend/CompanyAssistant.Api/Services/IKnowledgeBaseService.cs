using CompanyAssistant.Api.Models;

namespace CompanyAssistant.Api.Services;

public interface IKnowledgeBaseService
{
    Task<SearchResult> SearchAsync(string question);
}