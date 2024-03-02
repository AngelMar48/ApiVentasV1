using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using Service.Contracts;

namespace ApiVentasV1.Extensions;

public static class ServiceExtensions
{
	public static void ConfigureCors(this IServiceCollection services) =>
		services.AddCors(options =>
		{
			options.AddPolicy("CorsPolicy", builder =>
			builder.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader());
		});

	public static void ConfigureIISIntegration(this IServiceCollection services) =>
		services.Configure<IISOptions>(options =>
		{
		});

	public static void ConfigureLoggerService(this IServiceCollection services) =>
		services.AddSingleton<ILoggerManager, LoggerManager>();

	public static void ConfigureRepositoryManager(this IServiceCollection services) =>
		services.AddScoped<IRepositoryManager, RepositoryManager>();

	public static void ConfigureServiceManager(this IServiceCollection services) =>
		services.AddScoped<IServiceManager, ServiceManager>();

	public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
		services.AddDbContext<RepositoryContext>(opts =>
			opts.UseSqlite(configuration.GetConnectionString("sqlConnection")));

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Code Maze API",
                Version = "v1",
                Description = "API by Ange Martínez",
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Angel Martínez",
                    Email = "i.martinezcortes01@gmail.com",
                    Url = new Uri("https://twitter.com/"),
                },
                License = new OpenApiLicense
                {
                    Name = "API LICX",
                    Url = new Uri("https://example.com/license"),
                }

            });

        });
    }
}
