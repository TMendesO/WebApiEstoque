using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiEstoque.Repositorios;
using WebApiEstoque.Repositorios.Interface;
using WebApiEstoque.Data;

namespace WebApiEstoque
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            var serverVersion = new MySqlServerVersion(new System.Version(8, 0));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connection = builder.Configuration["ConnectionMySQL:DataBase"];

            builder.Services.AddEntityFrameworkMySql()
                .AddDbContext<ProdutosDbContext>(
                options => options.UseMySql(connection, serverVersion)
                );

            builder.Services.AddScoped<IProdutosRepositorio, ProdutoRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            var app = builder.Build();

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
