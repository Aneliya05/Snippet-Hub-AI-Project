using API.Services;
using Business_Layer.Services;
using Data_Layer.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options
        .UseLazyLoadingProxies()
        .UseSqlite("Data Source=app.db"));

builder.Services.AddScoped<TokenServices>();
builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<SnippetServices>();
builder.Services.AddScoped<ArticleServices>();
builder.Services.AddScoped<CategoryServices>();
builder.Services.AddScoped<LanguageServices>();
builder.Services.AddScoped<TagServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
