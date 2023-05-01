using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OCS_Test_Assignment.Persistence;
using Swashbuckle.AspNetCore.Newtonsoft;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers();
builder.Services.AddMvcCore()
    .AddApiExplorer();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("OrdersDatabase")));
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddScoped<OrdersDbOperations>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.UseRouting();
app.MapControllers();
app.UseEndpoints(endpoints => endpoints.MapControllers());


app.MapRazorPages();

app.Run();
