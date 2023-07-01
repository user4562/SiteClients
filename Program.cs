using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(options =>
{
    options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

if(Environment.GetEnvironmentVariable("ISRUNIP") == "true")
{
    app.Run(Environment.GetEnvironmentVariable("DBIP"));
}
else
{
    app.Run();
}


//< ItemGroup >
//  < Folder Include = "wwwroot\lib\" />
//</ ItemGroup >
