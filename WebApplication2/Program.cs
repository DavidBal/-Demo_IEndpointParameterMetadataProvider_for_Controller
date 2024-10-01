
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.MapControllers();
            app.UseAuthorization();

           

            app.MapPost("/minimalTest", (HttpContext httpContext, [FromBody] XmlPlaceholder? xmlPlaceholder = null) =>
            {
                return Results.Ok();
            })
            .WithName("Minimal Test");

            app.Run();
        }
    }
}
