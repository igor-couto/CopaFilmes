using System;
using System.IO;
using System.Reflection;
using System.Text.Json;
using CopaDeFilmes.Application.Interfaces;
using CopaDeFilmes.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CopaDeFilmes.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IChampionshipService, ChampionshipService>();

            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var contato = new OpenApiContact()
                {
                    Name = "Igor Freitas Couto",
                    Email = "igor.fcouto@gmail.com",
                    Url = new Uri("https://github.com/igor-couto")
                };

                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API Copa do Mundo de Filmes",
                        Version = "1.0",
                        Description = "API da Copa do Mundo de Filmes",
                        Contact = contato
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (File.Exists(xmlPath))
                    options.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(options => {

                options.DocumentTitle = "API Copa do Mundo de Filmes";

                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

                options.RoutePrefix = string.Empty;
            });

            app.UseCors("AllowAnyOrigin");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}