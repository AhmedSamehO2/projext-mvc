using meta.BLL.Interface;
using meta.BLL.Mapper;
using meta.BLL.Reposetry;
using meta.DAL.database;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(opt => {
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
});
builder.Services.AddScoped<IDepartmentRep, DepartmentRep>();
builder.Services.AddScoped<IEmployeeRep, EmployeeRep>();
builder.Services.AddScoped<ICountryRep, CountryRep>();
builder.Services.AddScoped<ICityRep, CityRep>();
builder.Services.AddScoped<IDistrictRep, DistrictRep>();








builder.Services.AddDbContextPool<metaContext>(opts =>
            opts.UseSqlServer(builder.Configuration.GetConnectionString("metaConnection")));
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
