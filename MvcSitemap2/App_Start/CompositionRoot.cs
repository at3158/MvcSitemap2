using System;
using MvcSitemap2.DI;
using MvcSitemap2.DI.Grace;
using MvcSitemap2.DI.Grace.Modules;

internal class CompositionRoot
{
    public static IDependencyInjectionContainer Compose()
    {
// Create new container
        var container = new Grace.DependencyInjection.DependencyInjectionContainer();

// Install MVC sitemap provider
        container.Configure(new MvcSiteMapProviderModule());

// Install Controllers
        container.Configure(new MvcModule());

// Add your DI configuration here

        return new GraceDependencyInjectionContainer(container.RootScope);
    }
}
