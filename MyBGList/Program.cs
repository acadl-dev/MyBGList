using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBGList;
using MyBGList.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(cfg => {
        cfg.WithOrigins(builder.Configuration["AllowedOrigins"]);
        cfg.AllowAnyHeader();
        cfg.AllowAnyMethod();
    });
    options.AddPolicy(name: "AnyOrigin",
        cfg => {
            cfg.AllowAnyOrigin();
            cfg.AllowAnyHeader();
            cfg.AllowAnyMethod();
        });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI do DbContext, usando a string de conexão definida no appsettings.json. O método UseSqlServer é específico para o provedor de banco de dados SQL Server, e é necessário ter o pacote Microsoft.EntityFrameworkCore.SqlServer instalado para usá-lo.
builder.Services.AddDbContext<MyBGlistDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
    );

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
    app.UseDeveloperExceptionPage();  //estamos usando-o apenas no ambiente de desenvolvimento, para que essas informações úteis, porém potencialmente prejudiciais, estejam disponíveis somente para o desenvolvedor                                ? 
else
    app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();


// Quando desejamos flexibilizar a política de mesma origem para todas as origens. Abordagem pode ser aceitável para o /error.e rotas /error/test, atualmente gerenciado pelas APIs mínimas.
app.MapGet("/error", 
    [EnableCors("AnyOrigin")]
    [ResponseCache(NoStore = true)] () => 
    Results.Problem()); //Minimal API, poderia ser substituido por um controller (os Controllers são mais adequados para tarefas complexas)

app.MapGet("/error/test", 
    [EnableCors("AnyOrigin")]
    [ResponseCache(NoStore = true)] () => 
    { throw new Exception("test"); });
app.MapGet("/cod/test",
    [EnableCors("AnyOrigin")]
[ResponseCache(NoStore = true)] () =>
    Results.Text("<script>" +
        "window.alert('Your client supports JavaScript!" +
        "\\r\\n\\r\\n" +
        $"Server time (UTC): {DateTime.UtcNow.ToString("o")}" +
        "\\r\\n" +
        "Client time (UTC): ' + new Date().toISOString());" +
        "</script>" +
        "<noscript>Your client does not support JavaScript</noscript>",
        "text/html"));

// Controllers
app.MapControllers().RequireCors("AnyOrigin");

app.Run();
