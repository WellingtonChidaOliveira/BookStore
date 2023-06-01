using BookStore.Server.Abstraction;
using BookStore.Server.Data.MongoDb;
using BookStore.Server.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddScoped<IMongoDbContext, MongoDbContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

  
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwagger();

    app.UseReDoc(app =>
    {
        app.DocumentTitle = "BookStore API Documentation";
        app.SpecUrl("/swagger/v1/swagger.json");
    });
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
