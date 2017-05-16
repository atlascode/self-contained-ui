using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DashboardExample
{
	internal class DashboardExampleLocationRemapper : IViewLocationExpander
	{
		private readonly IEnumerable<string> preCompiledViewLocations;

		public DashboardExampleLocationRemapper()
		{
			// custom view locations for the pre-compiled views
			this.preCompiledViewLocations = new[]
			{
				"/DashboardExample/Views/{1}/{0}.cshtml",
				"/DashboardExample/Views/Shared/{1}/{0}.cshtml",
			};
		}

		/// <inheritdoc />
		public void PopulateValues(ViewLocationExpanderContext context)
		{
			// check if we're trying to execute an action from a DashboardExample route
			if (context.ActionContext.ActionDescriptor.MatchesNamespaceInRoute(context))
			{
				/*
				 * by adding a value it identifies the view location is different from any similar locations in the user's project
				 * e.g. if the user also has a file at /Views/Home/Index.cshtml this will make sure that's not matched the same
				 * as ours at /DashboardExample/Views/Home/Index.cshtml even though they're both /Home/Index.cshtml views
				 */
				context.Values.Add("DashboardExample", bool.TrueString);
			}
		}

		/// <inheritdoc />
		public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
		{
			string isDashboardExample;
			if (context.Values.TryGetValue("DashboardExample", out isDashboardExample) && isDashboardExample == bool.TrueString)
			{
				return this.preCompiledViewLocations;
			}
			else
			{
				return viewLocations;
			}
		}
	}
}