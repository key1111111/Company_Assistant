

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

            var paragraphs = content
                .Split(
                    new[] { "\r\n\r\n", "\n\n" },
                    StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < paragraphs.Length; i++)
            {
                var paragraph = paragraphs[i];

                var score = keywords.Count(k =>
                    paragraph.Contains(
                        k,
                        StringComparison.OrdinalIgnoreCase));

                if (score > bestScore)
                {
                    bestScore = score;

                    var selected = new List<string>();

                    // Previous paragraph
                   // if (i > 0)
                   //     selected.Add(paragraphs[i - 1]);

                    // Matching paragraph
                    selected.Add(paragraph);

                    // Next paragraph
                  //  if (i < paragraphs.Length - 1)
                  //      selected.Add(paragraphs[i + 1]);

                    bestContent =
                        string.Join(
                            Environment.NewLine + Environment.NewLine,
                            selected);

                    bestSource =
                        Path.GetFileName(file);
                }
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