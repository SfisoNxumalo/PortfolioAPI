
using Infrastructure.Data;
using Integrations.Interfaces.Repositories;
using Integrations.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces.Services;
using Services.Services;




namespace PortfolioAPI_V2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IMessageRepository, MessageRepository>();
            builder.Services.AddScoped<IMessageServices, MessageService>();
            builder.Services.AddScoped<MessageService>();

            builder.Services.AddDbContext<DatabaseContext>(opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
