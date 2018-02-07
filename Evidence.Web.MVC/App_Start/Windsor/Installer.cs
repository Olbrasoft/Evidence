using System.Data.Entity;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Evidence.BLL;
using Evidence.DAL;
using Evidence.DTO;

namespace Evidence.Web.MVC.Windsor
{
    public class Installer: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient());
            
            container.Register(Component.For<DbContext>()
                .ImplementedBy<EvidenceDbContext>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IManager<Product>>()
                .ImplementedBy<ProductsManager>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IManager<Category>>()
                .ImplementedBy<CategoriesManager>()
                .LifestylePerWebRequest());

            container.Register(Component.For<IReadManager<ProductView>>()
                .ImplementedBy<ProductsViewManager>()
                .LifestylePerWebRequest());

        }
    }
}