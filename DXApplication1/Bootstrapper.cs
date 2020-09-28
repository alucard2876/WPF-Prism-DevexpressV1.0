using DomainAccess.Implementation;
using DomainAccess.Interfaces;
using DXApplication1.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;

namespace DXApplication1
{
    public class Bootstrapper : UnityBootstrapper
    {
        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            var productMenuModule = typeof(ProductMenuModule.ProductMenuModule);
            ModuleCatalog.AddModule(new Prism.Modularity.ModuleInfo { ModuleName = productMenuModule.Name, ModuleType = productMenuModule.AssemblyQualifiedName });
            //var productCatalogModule = typeof(ProductMenuModule.ProductCatalogModule);
            //ModuleCatalog.AddModule(new Prism.Modularity.ModuleInfo { ModuleName=productCatalogModule.Name,ModuleType=productCatalogModule.AssemblyQualifiedName});
            //var productPage = typeof(ProductMenuModule.ProductPageModule);
            //ModuleCatalog.AddModule(new Prism.Modularity.ModuleInfo { ModuleName = productPage.Name, ModuleType = productPage.AssemblyQualifiedName });

        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show() ;
        }
        protected override DependencyObject CreateShell()
        {
            
            return Container.TryResolve<Shell>();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
    }
}
