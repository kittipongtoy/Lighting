using Lighting.Areas.Identity.Data;
using Lighting.Core.Repositories;
using Lighting.Repositories;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;
using Lighting.Models;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LightingContextConnection") 
					?? throw new InvalidOperationException("Connection string 'LightingContextConnection' not found.");

builder.Services.AddDbContext<LightingContext>(options =>
	options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<LightingUser>(option => option.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<LightingContext>();

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddIdentity<LightingUser, Role>(
	options =>
	{
		options.SignIn.RequireConfirmedAccount = false;
		options.Password.RequiredLength = 5;
		options.Password.RequireDigit = false;
		options.Password.RequireUppercase = false;
		options.User.RequireUniqueEmail = true;
		options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
		options.Lockout.MaxFailedAccessAttempts = 10;

	})
	.AddEntityFrameworkStores<LightingContext>()
	.AddDefaultUI()
	.AddDefaultTokenProviders()
	.AddRoles<Role>();

builder.Services.AddRazorPages();

// Add services to the container.
builder.Services.AddControllersWithViews()
	.AddRazorRuntimeCompilation()
	.AddRazorPagesOptions(options =>
	{
		//options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
	});

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30));

builder.Services.AddCors(options =>
{
	options.AddPolicy(myAllowSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins("https://ir.lighting.co.th/",
											  "");
					  });
});

builder.Services.AddDbContext<LightingContext>(options =>
	options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
	{
		sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
		sqlOptions.EnableRetryOnFailure(
			maxRetryCount: 20,
			maxRetryDelay: TimeSpan.FromSeconds(30),
			errorNumbersToAdd: null);
	}));

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
	options.TokenLifespan = TimeSpan.FromMinutes(30));

//add date time to console, .net error log
builder.Services.AddLogging(options =>
{
	options.AddSimpleConsole(c =>
	{
		c.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ";
		// c.UseUtcTimestamp = true; // something to consider
	});
});

builder.Services.AddHsts(options =>
{
	options.Preload = true;
	options.IncludeSubDomains = true;
	options.MaxAge = TimeSpan.FromDays(60);
	options.ExcludedHosts.Add("https://orangestudio.club/");
	options.ExcludedHosts.Add("");
});

if (!builder.Environment.IsDevelopment())
{
	builder.Services.AddHttpsRedirection(options =>
	{
		options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
		options.HttpsPort = 443;
	});
}

builder.Services.AddAuthentication(
		CertificateAuthenticationDefaults.AuthenticationScheme)
	.AddCertificate(options =>
	{
		options.Events = new CertificateAuthenticationEvents
		{
			OnCertificateValidated = context =>
			{
				var claims = new[]
				{
					new Claim(
						ClaimTypes.NameIdentifier,
						context.ClientCertificate.Subject,
						ClaimValueTypes.String, context.Options.ClaimsIssuer),
					new Claim(
						ClaimTypes.Name,
						context.ClientCertificate.Subject,
						ClaimValueTypes.String, context.Options.ClaimsIssuer)
					};

				context.Principal = new ClaimsPrincipal(
					new ClaimsIdentity(claims, context.Scheme.Name));
				context.Success();

				return Task.CompletedTask;
			}
		};
	});

AddAuthorizationPolicies();

AddScoped();

void AddAuthorizationPolicies()
{

	builder.Services.AddAuthorization(options =>
	{
		options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.Admin));
		//options.AddPolicy(Constants.Policies.RequireEmployee, policy => policy.RequireRole(Constants.Roles.Employee));
		//options.AddPolicy(Constants.Policies.RequireManager, policy => policy.RequireRole(Constants.Roles.Manager));
		//options.AddPolicy(Constants.Policies.RequireClerk, policy => policy.RequireRole(Constants.Roles.Clerk));
		//options.AddPolicy(Constants.Policies.RequireHost, policy => policy.RequireRole(Constants.Roles.Host));
		//options.AddPolicy(Constants.Policies.RequireChiefInspector, policy => policy.RequireRole(Constants.Roles.ChiefInspector));
		//options.AddPolicy(Constants.Policies.RequireInspector, policy => policy.RequireRole(Constants.Roles.Inspector));
		//options.AddPolicy(Constants.Policies.RequireSparInspector, policy => policy.RequireRole(Constants.Roles.SparInspector));
		//options.AddPolicy(Constants.Policies.RequireAssistant, policy => policy.RequireRole(Constants.Roles.Assistant));
		//options.AddPolicy(Constants.Policies.RequireSpar, policy => policy.RequireRole(Constants.Roles.Spar));
		//options.AddPolicy(Constants.Policies.RequireCheckLine, policy => policy.RequireRole(Constants.Roles.CheckLine));
	});
}

void AddScoped()
{
	builder.Services.AddScoped<ILoggerHelperRepository, LoggerHelper>();
}


var app = builder.Build();

var loggerFactory = app.Services.GetService<ILoggerFactory>();
//loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"]);

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
//pattern: "{controller=Lighting}/{action=Index}/{id?}");

//pattern: "{controller=ManageDownload}/{action=manage_download_page}");
//pattern: "{controller=news}/{action=manage_news_page}");
pattern: "{controller=ManageJob}/{action=manage_job_page}");
//pattern: "{controller=ManageContact}/{action=manage_Contact_page}");
//pattern: "{controller=ProjectRef}/{action=manage_page}");
//product
//pattern: "{controller=ManageProduct}/{action=Manage_Category_Page}");
//pattern: "{controller=ManageProduct}/{action=Manage_Model_Page}");
//pattern: "{controller=ManageProduct}/{action=Manage_Product_Page}");
//pattern: "{controller=Product}/{action=Product}");

//pattern: "{controller=ManageSmartSolution}/{action=Manage_Page}");
//pattern: "{controller=ManageSmartSolution}/{action=Manage_Category_Page}");

app.MapRazorPages();

app.Run();
 