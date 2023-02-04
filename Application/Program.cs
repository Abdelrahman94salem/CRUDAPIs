var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//.WithOrigins("http://localhost:3000", "http://localhost:4200")
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
                         builder =>
                         {
                             builder
                             
                             .AllowAnyMethod()
                             .AllowAnyHeader()
                             .AllowAnyOrigin()
                             .AllowCredentials();
                         }));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "CRUD Operation",
        Version = "v1",
        Description = "CRUD Operation for Transflo test",
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD Operation"));

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
app.UseCors("CorsPolicy");

