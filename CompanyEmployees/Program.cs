//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//var app = builder.Build();

//// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using CompanyEmployees.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

builder.Services.AddControllers();

var app = builder.Build();

if(app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else 
    app.UseHsts();

app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();