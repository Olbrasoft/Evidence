using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Evidence.Web.MVC.Windsor;
using WebActivatorEx;


[assembly: PreApplicationStartMethod(typeof(Activator), "PreStart")]
[assembly: ApplicationShutdownMethod(typeof(Activator), "Shutdown")]

namespace Evidence.Web.MVC.Windsor
{
    public static class Activator
    {
        private static IWindsorContainer _container;

        private static void BootstrapContainer()
        {
            _container = new WindsorContainer()
                .Install(FromAssembly.This());
            var controllerFactory = new ControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        public static void PreStart()
        {
           BootstrapContainer();
        }
        
        public static void Shutdown()
        {
            _container?.Dispose();
        }
    }
}