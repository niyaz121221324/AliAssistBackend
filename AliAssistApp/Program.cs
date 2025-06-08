using AliAssistApp.Exceptions;
using AliAssistApp.Middleware;
using AliAssistApp.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Регистрация сервисов
builder.Services.AddControllers();

// Регистрация HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// Регистрация HttpClient
builder.Services.AddHttpClient();

// Регистрация парсеров
builder.Services.AddScoped<IAmazonProductService, AmazonAmazonProductService>(); 
builder.Services.AddScoped<IAliExpressProductService, AliExpressProductService>();

// Регистрация CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("https://localhost:7142") // Разрешаем доступ только с этого домена
            .AllowAnyMethod() // Разрешаем все HTTP методы (GET, POST, PUT, DELETE и т.д.)
            .AllowAnyHeader(); // Разрешаем все заголовки
    });
});

// Swagger (если необходимо)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Настройка Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin"); // Включаем политику CORS для определенного домена

// Подключение кастомного middleware для JWT-аутентификации
app.UseMiddleware<AuthMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var exception = exceptionHandlerPathFeature?.Error;

        ProblemDetails problemDetails = exception switch
        {
            TokenExpiredException tokenExpiredException => new TokenExpiredProblemDetail(tokenExpiredException),
            InvalidTokenException invalidTokenEx => new InvalidTokenProblemDetail(invalidTokenEx),
            _ => new ProblemDetails
            {
                Title = "An unexpected error occurred.",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception?.Message
            }
        };

        context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});

app.Run();