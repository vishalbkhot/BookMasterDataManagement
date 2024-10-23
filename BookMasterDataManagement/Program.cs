
using BookMasterDataManagement.Data;
using BookMasterDataManagement.Repositories;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.Design;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<IBReferenceDataContext>(options =>
            options.UseInMemoryDatabase("IBReferenceData"));



builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() 
                   .AllowAnyMethod() 
                   .AllowAnyHeader(); 
        });
});
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000") 
               .AllowAnyMethod() 
               .AllowAnyHeader(); 
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Register the IOperationService and its implementation
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors("MyPolicy");
app.Run();
