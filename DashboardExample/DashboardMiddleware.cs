using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace DashboardExample
{
    public static class DashboardMiddleware
    {
	    public static IServiceCollection AddDashboard(this IServiceCollection services)
	    {
			services.AddMvc();

		    services.Configure<RazorViewEngineOptions>(opt =>
		    {
				opt.ViewLocationExpanders.Add(new DashboardExampleLocationRemapper());
		    });

		    return services;
	    }

        public static IApplicationBuilder UseDashboard(this IApplicationBuilder app, DashboardOptions dashboardOptions = null)
        {
	        var pathMatch = (dashboardOptions?.Path ?? "dashboard").Trim('/');
			
			/*
			 * Add a route with a dataToken that we can use to try to ensure we only match to classes in the DashboardExample project.
			 * 
			 * This attempts to prevent clashes if the user is also using MVC. If they also have a HomeController with an Index action
			 * then the NamespaceConstraint attribute on our controller along with the data token below will ensure this route only
			 * matches to our HomeController Index action.
			 */
	        app.UseMvc(routes =>
	        {
				routes.MapRoute(
						name: "DashboardExample",
						template: pathMatch + "/{controller=Home}/{action=Index}/{id?}", 
						defaults: null,
						constraints: null,
						dataTokens: new { Namespace = "DashboardExample.DashboardExample.Controllers" });
	        });

            return app;
        }
    }
}
