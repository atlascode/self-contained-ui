using System.Linq;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;

namespace DashboardExample
{
	internal static class RouteContextExtensions
	{
		/// <summary>
		/// Determines whether an action matches a namespace defined by the route
		/// </summary>
		/// <param name="action"></param>
		/// <param name="routeData"></param>
		/// <returns></returns>
		private static bool MatchesNamespaceInRoute(ActionDescriptor action, RouteData routeData)
		{
			var dataTokenNamespace = (string)routeData.DataTokens.FirstOrDefault(dt => dt.Key == "Namespace").Value;
			var actionNamespace = ((ControllerActionDescriptor)action).MethodInfo.DeclaringType.Namespace;

			return dataTokenNamespace == actionNamespace;
		}

		/// <summary>
		/// Determines whether an action matches a namespace defined by the route
		/// </summary>
		/// <param name="action"></param>
		/// <param name="routeContext"></param>
		/// <returns></returns>
		public static bool MatchesNamespaceInRoute(this ActionDescriptor action, RouteContext routeContext)
		{
			return MatchesNamespaceInRoute(action, routeContext.RouteData);
		}

		/// <summary>
		/// Determines whether an action matches a namespace defined by the route
		/// </summary>
		/// <param name="action"></param>
		/// <param name="viewLocationExpanderContext"></param>
		/// <returns></returns>
		public static bool MatchesNamespaceInRoute(this ActionDescriptor action, ViewLocationExpanderContext viewLocationExpanderContext)
		{
			return MatchesNamespaceInRoute(action, viewLocationExpanderContext.ActionContext.RouteData);
		}
	}
}