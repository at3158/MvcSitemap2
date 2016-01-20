using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using $rootnamespace$.DI;
using $rootnamespace$.DI.Unity;
using $rootnamespace$.DI.Unity.ContainerExtensions;


internal class CompositionRoot
{
    public static IDependencyInjectionContainer Compose()
    {
        var container = new UnityContainer();
        container.AddNewExtension<MvcSiteMapProviderContainerExtension>();

        return new UnityDependencyInjectionContainer(container);
    }
}
