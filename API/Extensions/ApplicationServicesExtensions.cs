using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
        public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //Sql Server DB CONTEXT
            services.AddDbContext<ConcertsAgendaContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // //CACHE
            // services.AddSingleton<IResponseCacheService, ResponseCacheService>();

            //REPOSITORY
            services.AddScoped<IConcertRepository, ConcertRepository>();

            // //UNIT OF WORK
            // services.AddScoped<IUnitOfWork, UnitOfWork>();

            // //GENERIC REPOSITORY
            // services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // //TOKEN SERVICE
            // services.AddScoped<ITokenService, TokenService>();

            // //DTOs
            // services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                    .Where(e => e.Value?.Errors.Count() > 0)
                                    .SelectMany(x => x.Value?.Errors ?? Enumerable.Empty<ModelError>())
                                    .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            services.AddCors(opt => 
            {
                opt.AddPolicy("CorsPolicy", policy => 
                {
                    policy.WithOrigins("https://localhost:4300").AllowAnyHeader().AllowAnyMethod();
                    //.AllowAnyOrigin();
                    
                });
            });

            return services;
        }
    }

}