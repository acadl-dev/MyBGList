var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
    app.UseDeveloperExceptionPage();  //estamos usando-o apenas no ambiente de desenvolvimento, para que essas informações úteis, porém potencialmente prejudiciais, estejam disponíveis somente para o desenvolvedor                                ? 
else
    app.UseExceptionHandler("/error");




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/error", () => Results.Problem()); //Minimal API, poderia ser substituido por um controller (os Controllers são mais adequados para tarefas complexas)
app.MapGet("/error/test", () => {throw new Exception("test"); }) ;

app.MapControllers();

app.Run();
