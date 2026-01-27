using Microsoft.AspNetCore.Cors;
using MyBGList;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


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
//app.UseCors();

app.UseAuthorization();


// Quando desejamos flexibilizar a política de mesma origem para todas as origens. Abordagem pode ser aceitável para o /error.e rotas /error/test, atualmente gerenciado pelas APIs mínimas.
app.MapGet("/error", [EnableCors("AnyOrigin")] () => Results.Problem()); //Minimal API, poderia ser substituido por um controller (os Controllers são mais adequados para tarefas complexas)

app.MapGet("/error/test", [EnableCors("AnyOrigin")] () => { throw new Exception("test"); });
/* app.MapGet("/BoardGames", () => new[] {
    new BoardGame() {
        Id = 1,
        Name = "Axis & Allies",
        Year = 1981
    },
    new BoardGame() {
        Id = 2,
        Name = "Citadels",
        Year = 2000
    },
    new BoardGame() {
        Id = 3,
        Name = "Terraforming Mars",
        Year = 2016
    }
});

 O comportamento mínimo do nosso BoardGamesController pode ser facilmente tratado pela API Minimal com algumas linhas de código. 
Aqui está um trecho de código que podemos colocar no arquivo Program.cs para obter a mesma saída do método de ação Get() */

app.MapControllers();

app.Run();
