using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var kernelBuilder = Kernel.CreateBuilder();

var orgid = Environment.GetEnvironmentVariable("OPENAI_ORGID", EnvironmentVariableTarget.Process);
var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY", EnvironmentVariableTarget.Process);

if (string.IsNullOrEmpty(orgid) || string.IsNullOrEmpty(apiKey))
{
    throw new InvalidOperationException("As variáveis de ambiente OPENAI_ORGID e OPENAI_API_KEY devem estar definidas.");
}

kernelBuilder.AddOpenAIChatCompletion(
    modelId: "gpt-4",
    apiKey: apiKey,
    orgId: orgid);


Kernel kernel = kernelBuilder.Build();
builder.Services.AddSingleton(kernel);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
