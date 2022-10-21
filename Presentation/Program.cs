using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Abstract;
using Services.Config;



//fix of postgres utc datetime
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IProductService,ProductService>();

builder.Services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("Default"),
            x => x.MigrationsAssembly("DataAccess")
          )
      );

var mapperConfig = new MapperConfiguration(mc =>
    mc.AddProfile(new MapperProfile())
);

builder.Services.AddSingleton(mapperConfig.CreateMapper());


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(opt =>
	{
		opt.LoginPath = "/Login/SignIn";
		opt.Cookie.HttpOnly = true;
		opt.Cookie.Name = "AuthCookie";
		opt.Cookie.MaxAge = TimeSpan.FromHours(1);

		////for api
		//opt.Events = new CookieAuthenticationEvents
		//{		
		//	OnRedirectToLogin = x =>
		//	{
		//		x.HttpContext.Response.StatusCode = 401;
		//		return Task.CompletedTask;
		//	}
		//};
	});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=SignIn}/{id?}");

app.Run();
