using Autofac;
using Umbraco.Web;
using UmbracoCMSDIMixedMode.Web.Services;

namespace UmbracoCMSDIMixedMode.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleService>()
                .As<ISampleService>();

            builder.Register(c => UmbracoContext.Current).AsSelf();
        }
    }
}