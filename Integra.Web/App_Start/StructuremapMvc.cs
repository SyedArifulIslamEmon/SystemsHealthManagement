using Integra.Web.DependencyResolution;
using StructureMap;
using System.Web.Http;
using System.Web.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Integra.Web.App_Start.StructuremapMvc), "Start")]

namespace Integra.Web.App_Start
{
	public static class StructuremapMvc
	{
		public static void Start()
		{
			IContainer container = IoC.Initialize();
			DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new StructureMapDependencyResolver(container);
		}
	}
}