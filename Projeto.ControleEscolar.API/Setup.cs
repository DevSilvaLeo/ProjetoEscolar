using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Projeto.ControleEscolar.Application.Interfaces;
using Projeto.ControleEscolar.Application.Services;
using Projeto.ControleEscolar.Domain.Interfaces.Repository;
using Projeto.ControleEscolar.Domain.Interfaces.Security;
using Projeto.ControleEscolar.Domain.Interfaces.Services;
using Projeto.ControleEscolar.Domain.Services;
using Projeto.ControleEscolar.Infra.Security.Helpers;
using Projeto.ControleEscolar.Infra.Security.Services;
using Projeto.ControleEscolar.Infra.Security.Settings;
using Projeto.ControleEscolar.Infra.SqlServer.Contexts;
using Projeto.ControleEscolar.Infra.SqlServer.Repositories;
using System.Text;

namespace Projeto.ControleEscolar.API
{
    public static class Setup
    {
        public static void AddRegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
            builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();

            builder.Services.AddTransient<IAlunoAplicationService, AlunoApplicationService>();
            builder.Services.AddTransient<IAlunoDomainService, AlunoDomainService>();

            builder.Services.AddTransient<IProfessorApplicationService, ProfessorApplicationService>();
            builder.Services.AddTransient<IProfessorDomainService, ProfessorDomainService>();

            builder.Services.AddTransient<ITurmaApplicationService, TurmaApplicationService>();
            builder.Services.AddTransient<ITurmaDomainService, TurmaDomainService>();

            builder.Services.AddTransient<IDisciplinaApplicationService, DisciplinaApplicationService>();
            builder.Services.AddTransient<IDisciplinaDomainService, DisciplinaDomainService>();

            builder.Services.AddTransient<IAutenticacaoApplicationService, AutenticacaoApplicationService>();
            builder.Services.AddTransient<IAutenticacaoDomainService, AutenticacaoDomainService>();
           
            builder.Services.AddTransient<IMD5Cryptograph, MD5Cryptograph>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        public static void AddAutoMapperServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void AddEFServices(this WebApplicationBuilder builder)
        {
            var conn = builder.Configuration.GetConnectionString("SistemaEscolar");
            builder.Services.AddDbContext<SqlServerContext>(options=>options.UseSqlServer(conn));
        }
        public static void AddJwtBearerSecurity(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("JwtSettings"));
            builder.Services.AddTransient<IAuthorizationSecurity, AuthorizationSecurity>();

            builder.Services.AddAuthentication(
                auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.ASCII.GetBytes
                                (builder.Configuration.GetSection("JwtSettings").GetSection("SecretKey").Value)
                            ),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });
        }

        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Sistema Escolas",
                    Description = "API REST para administração escolar.",
                    Contact = new OpenApiContact { Name = "THE ONE SOFTWARE", Email = "contato@theonesoftware.com.br", Url = new Uri("http://www.theonesoftware.com.br") }
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                   s => s.AddPolicy("DefaultPolicy", builder =>
                   {
                       builder.AllowAnyOrigin() //qualquer origem pode acessar a API
                              .AllowAnyMethod() //qualquer método (POST, PUT, DELETE, GET)
                              .AllowAnyHeader(); //qualquer informação de cabeçalho
                   })
               );
        }

        public static void UseCors(this WebApplication app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
