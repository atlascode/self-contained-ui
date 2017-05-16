using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Routing;

namespace DashboardExample
{
	/// <summary>
	/// Used to identify that a route will only match to an action if that action is in a namespace defined by the route
	/// </summary>
	internal class NamespaceConstraint : ActionMethodSelectorAttribute
	{
		public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
		{
			return action.MatchesNamespaceInRoute(routeContext);
		}
	}
}
