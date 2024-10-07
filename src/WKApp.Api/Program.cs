using WKApp.Api.Endpoints;
using WKApp.Domain.Interfaces;
using WKApp.Domain.Services;

namespace WKApp.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IEmployeeNumberService, EmployeeNumberService>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapGroup("/api/employee").MapEmployeeApi();


        app.Run();
    }
}
