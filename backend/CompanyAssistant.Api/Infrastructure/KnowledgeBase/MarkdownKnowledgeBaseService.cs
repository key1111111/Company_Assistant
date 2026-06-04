

public class MarkdownKnowledgeBaseService
    : IKnowledgeBaseService
{
    private readonly IWebHostEnvironment _env;

    public MarkdownKnowledgeBaseService(
        IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<SearchResult> SearchAsync(
        string question)
    {
        var docsFolder =
            Path.Combine(
                Directory.GetParent(_env.ContentRootPath)!
                .Parent!
                .Parent!
                .FullName,
                "docs");

        var files = Directory.GetFiles(
            docsFolder,
            "*.md");

        var keywords = question
            .ToLower()
            .Split(' ',
                StringSplitOptions.RemoveEmptyEntries);

        string bestContent = "";
        string bestSource = "";
        int bestScore = 0;

        foreach (var file in files)
        {
            var content =
                await File.ReadAllTextAsync(file);

            var score = keywords.Count(k =>
                content.Contains(
                    k,
                    StringComparison.OrdinalIgnoreCase));

            if (score > bestScore)
            {
                bestScore = score;
                bestContent = content;
                bestSource = Path.GetFileName(file);
            }
        }

        if (bestScore == 0)
        {
            return new SearchResult(
                "No matching information found.",
                "");
        }

        return new SearchResult(
            bestContent,
            bestSource);
    }
}