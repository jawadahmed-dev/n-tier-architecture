using BussinessLogic.Extensions;
using DAL.Extensions;
using DemoApi.Domain.Options;
using DemoApi.Extensions;
using DemoApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public IConfiguration _configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.InstallMvc(_configuration)
				.InstallDataAccess(_configuration)
				.InstallBussinessLogic(_configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			// Swagger
			var swaggerOptions = new SwaggerOptions();
			_configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

			app.UseSwagger(options => {
				options.RouteTemplate = swaggerOptions.JsonRoute;
			});
			app.UseSwaggerUI(options => {
				options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
			});


			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseRouting();

			app.UseAuthorization();

			app.UseMiddleware<PerformanceMiddleware>();

			app.UseMiddleware<ExceptionHandlingMiddleware>();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

			
		}
	}
}
