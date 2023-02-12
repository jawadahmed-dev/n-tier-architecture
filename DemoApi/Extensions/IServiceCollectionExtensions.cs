using Domain.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace DemoApi.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection InstallMvc(this IServiceCollection services, IConfiguration configuration)
		{
			InstallController(services);
			InstallJwt(services, configuration);
			InstallSwagger(services, configuration);

			return services;
		}

		private static void InstallJwt(IServiceCollection services, IConfiguration configuration)
		{
			var jwtOptions = new JwtOptions();
			configuration.GetSection(nameof(JwtOptions)).Bind(jwtOptions);

			services.AddAuthentication(options =>
			{
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
				.AddJwtBearer(options => {
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),
						ValidateIssuer = false,
						ValidateAudience = false,
						RequireExpirationTime = false,
						ValidateLifetime = true
					};
				});
		}

		private static void InstallSwagger(IServiceCollection services, IConfiguration configuration)
		{
			services.AddSwaggerGen(options => {
				options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TweetBook Api", Version = "v1" });
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please insert JWT with Bearer into field",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				});

				options.AddSecurityRequirement(new OpenApiSecurityRequirement {
				   {
					 new OpenApiSecurityScheme
					 {
					   Reference = new OpenApiReference
					   {
						 Type = ReferenceType.SecurityScheme,
						 Id = "Bearer"
					   }
					  },
					  new string[] { }
					}
				  });
			});
		}

		private static void InstallController(IServiceCollection services)
		{
			services.AddControllersWithViews();
		}
	}
}
