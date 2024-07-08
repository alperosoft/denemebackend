using System.Data;
using System.Data.Odbc;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Osoft.Erp.Core.IRepositories;
using Osoft.SiparisOnay.Api.Mapping;
using Osoft.SiparisOnay.Repository.IRepositories;
using Osoft.SiparisOnay.Repository.Repositories;
using Osoft.SiparisOnay.Repository.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configurations();
builder.Services.AddHangfire(c => c.UseMemoryStorage());
builder.Services.AddHangfireServer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddSignalR();


var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Osoft.SiparisOnay.Api v1");
        options.OAuthClientId("swagger-ui");
        options.OAuthClientSecret("swagger-ui-secret");
        options.OAuthRealm("swagger-ui-realm");
        options.OAuthAppName("Swagger UI");

    });
}

// Configure the HTTP request pipeline.





app.UseHttpsRedirection();

app.UseCors("CorsSpecs");

app.UseAuthentication();
app.UseAuthorization();

app.UseHangfireDashboard();
app.MapControllers();
app.MapHub<MyHub>("/raporJob");

app.Run();

public static class ServiceRegistration
{
    static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
    static string cryptedString;
    public static void Configurations(this IServiceCollection services)
    {

        var dsn = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
        var user = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["User"];
        var cryptedString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["Password"];


        if (string.IsNullOrEmpty(cryptedString))
        {
            throw new ArgumentNullException
            ("");
        }

        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        MemoryStream memoryStream = new MemoryStream
            (Convert.FromBase64String(cryptedString));
        CryptoStream cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
        StreamReader reader = new StreamReader(cryptoStream);
        var password = reader.ReadToEnd();
        services.AddScoped<IDbConnection, OdbcConnection>(serviceProvider =>
        {
            String connectionString = $@"Dsn={dsn};Uid={user};Pwd={password};";
            OdbcConnection conn = new OdbcConnection(connectionString);
            conn.Open();
            return conn;
        });


        services.AddSwaggerGen(options =>
        {
            //options.SwaggerDoc("v1", new OpenApiInfo { Title = "Osoft.SiparisOnay.Api", Version = "v1" });

            //var securityScheme = new OpenApiSecurityScheme
            //{
            //    Name = "Authorization",
            //    Description = "Enter your JWT token",
            //    In = ParameterLocation.Header,
            //    Type = SecuritySchemeType.Http,
            //    Scheme = "Bearer" 
            //};

            //options.AddSecurityDefinition("Bearer", securityScheme);

            //var securityRequirement = new OpenApiSecurityRequirement
            //{
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Reference = new OpenApiReference
            //            {
            //                Type = ReferenceType.SecurityScheme,
            //                Id = "Bearer"
            //            }
            //        },
            //        new string[] {}
            //    }
            //};

            //options.AddSecurityRequirement(securityRequirement);
        });


        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IFirmaRepository, FirmaRepository>();
        services.AddScoped<IFirmagrpRepository, FirmagrpRepository>();
        services.AddScoped<IBankaRepository, BankaRepository>();
        services.AddScoped<ISpRepository, SpRepository>();
        services.AddScoped<IPersonelRepository, PersonelRepository>();
        services.AddScoped<IGnstrRepository, GnstrRepository>();
        services.AddScoped<ISpkategRepository, SpkategRepository>();
        services.AddScoped<ILbRepository, LbRepository>();
        services.AddScoped<IAmbalajRepository, AmbalajRepository>();
        services.AddScoped<IEbatRepository, EbatRepository>();
        services.AddScoped<IDovizRepository, DovizRepository>();
        services.AddScoped<IBirimRepository, BirimRepository>();
        services.AddScoped<IMamlzRepository, MamlzRepository>();
        services.AddScoped<IFytturRepository, FytturRepository>();
        services.AddScoped<IIsletmeRepository, IsletmeRepository>();
        services.AddScoped<IStokPrtRepository, StokPrtRepository>();
        services.AddScoped<ITableIdRepository, TableIdRepository>();
        services.AddScoped<ISpdRepository, SpdRepository>();
        services.AddScoped<ILfydRepository, LfydRepository>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStkfdRepository, StkfdRepository>();
        services.AddScoped<ISirketRepository, SirketRepository>();
        services.AddScoped<ISevkiyatRepository, SevkiyatRepository>();
        services.AddScoped<ISpurtRepository, SpurtRepository>();
        services.AddScoped<IReceteRepository, ReceteRepository>();
        services.AddScoped<IColorsRepository, ColorsRepository>();
        services.AddScoped<ISpwoRepository, SpwoRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        services.AddScoped<IKanbanBoardRepository, KanbanBoardRepository>();
        services.AddScoped<IDinamikRaporRepository, DinamikRaporRepository>();
        services.AddScoped<IDinamikRaporFilterRepository, DinamikRaporFilterRepository>();
        services.AddScoped<IStkfRepository, StkfRepository>();
        services.AddScoped<IDepoRepository, DepoRepository>();
        services.AddScoped<IStkfdTopRepository, StkfdTopRepository>();
        services.AddScoped<IVardiyaRepository, VardiyaRepository>();
        services.AddScoped<IBosprimnoRepository, BosprimnoRepository>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<IHubRepository, HubRepository>();



        services.AddAutoMapper(typeof(MapProfile));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = "domain.com",
                ValidateIssuer = true,
                ValidIssuer = "domain.com",
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("JwtSecurity")["Key"]))
            };
        });


        //gelen istek yetkisi
        var cors1 = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Security")["cors1"];
        var cors2 = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Security")["cors2"];
        services.AddCors(options =>
        {
            options.AddPolicy("CorsSpecs",
                builder =>
                {
                    builder.WithOrigins(cors1, cors2)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(options => true)
                        .AllowCredentials();
                });
        });
        //gelen istek yetkisi END

    }
}
 
