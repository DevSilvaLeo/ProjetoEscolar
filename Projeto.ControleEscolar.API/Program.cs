using Projeto.ControleEscolar.API;
using Projeto.ControleEscolar.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Setup.AddSwagger(builder);
Setup.AddCors(builder);
Setup.AddRegisterServices(builder);
Setup.AddEFServices(builder);
Setup.AddAutoMapperServices(builder);
Setup.AddJwtBearerSecurity(builder);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionMiddleware>();
Setup.UseCors(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
