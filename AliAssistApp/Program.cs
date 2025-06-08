using AliAssistApp.Middleware;
using AliAssistApp.Services;

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
// app.UseMiddleware<AuthMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();