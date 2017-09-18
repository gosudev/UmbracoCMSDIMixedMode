using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

using Umbraco.Core;
using Umbraco.Web;

namespace UmbracoCMSDIMixedMode.Web.Events
{
    public partial class ApplicationEvents : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            RegisterIoCContainer();
        }

        private void RegisterIoCContainer()
        {
            var builder = new ContainerBuilder();

            /* MVC Controllers */
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            /* WebApi Controllers */
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterModule<WebModule>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}