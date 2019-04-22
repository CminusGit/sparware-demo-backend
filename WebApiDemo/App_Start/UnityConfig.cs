using Application.Url.Context;
using External.GoogleChartApi;
using Model.GoogleChartApi.Abstraction;
using Persistence.Url;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace WebApiDemo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUrlContext, UrlContext>();
            container.RegisterType<IUrlRepository, UrlRepository>();
            container.RegisterType<IGoogleChartQrCodeBuilder, GoogleChartQrCodeBuilder>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}