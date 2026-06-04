using CompanyAssistant.Api.Features.AskQuestion;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddScoped<
    IKnowledgeBaseService,
    MarkdownKnowledgeBaseService>();

builder.Services.AddScoped<
    AskQuestionHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();

app.MapAskQuestion();

app.Run();