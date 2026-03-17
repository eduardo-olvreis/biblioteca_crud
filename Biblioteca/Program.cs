using Biblioteca.Data;
using Biblioteca.Repositories.Autores;
using Biblioteca.Repositories.Livros;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});
builder.Services.AddOpenApi();
builder.Services.AddScoped<IAutorRepository, SqlAutorRepository>();
builder.Services.AddScoped<ILivroRepository, SqlLivroRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
