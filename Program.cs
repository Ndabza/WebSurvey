using WebSurvey.Data;
using WebSurvey.Interfaces;
using WebSurvey.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SurveyContext>();
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
