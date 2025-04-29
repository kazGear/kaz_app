using KazApi.Common._Filter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("KazApp is starting...");
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.ConfigureKestrel((context, options) => {
                    options.Listen(IPAddress.Any, 5000); // HTTP
                    if (context.HostingEnvironment.IsProduction())
                    {
                        options.Listen(IPAddress.Any, 5001, listenOptions =>
                        {
                            listenOptions.UseHttps(
                                "/etc/letsencrypt/live/kazapp-trial.com/kazapp-trial.pfx",
                                "kaz_5050");
                        });
                    }
                });
            });
}

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // ��O�t�B���^�[
        services.AddControllers(options =>
        {
            options.Filters.Add<ExceptionFilter>();
        });

        // �t�B���^�[�A�C���^�[�Z�N�V����
        services.AddControllersWithViews(options =>
        {
            options.Filters.Add(typeof(AuthActionFilter));
        });

        // JWT�ݒ�
        services.AddAuthentication(options => 
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
        }).AddJwtBearer(options => 
        {
            options.TokenValidationParameters = new TokenValidationParameters
            { 
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]!)) 
            }; 
        });

        // JS: cors�ݒ�
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
        });

        services.AddControllers().
                 AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Encoder 
                = System.Text.Encodings.Web.JavaScriptEncoder.Create(
                    System.Text.Unicode.UnicodeRanges.All);
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            //app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
            //app.UseHttpsRedirection();
        }

        app.UseRouting();
        app.UseCors("AllowAll"); // app.UseStaticFiles()����Ɏ��s����K�v������

        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //endpoints.MapFallbackToFile("/index.html");
        });
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Add("Content-Type", "application/json; charset=utf-8");
            await next();
        });
    }
}


// ************************************************************************************************
// original (swagger�g�p�\)
// ************************************************************************************************

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// CORS�I���W���ݒ�
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(
//        builder =>
//        {
//            builder.AllowAnyOrigin()  // ���ׂẴI���W������� CORS �v��������
//                   .AllowAnyMethod()  // ���ׂĂ� HTTP ���\�b�h������
//                   .AllowAnyHeader(); // ���ׂĂ̍쐬�җv���w�b�_�[������
//        });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//	app.UseSwagger();
//	app.UseSwaggerUI();
//}

//// CORS �~�h���E�F�A��L���ɂ���
//app.UseCors();

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
