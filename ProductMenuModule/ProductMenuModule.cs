using Prism.Modularity;
using Prism.Unity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using ProductMenuModule.Views;
using DomainAccess.Interfaces;
using DomainAccess.Implementation;

namespace ProductMenuModule
{
    public class ProductMenuModule : IModule
    {
        private IRegionManager regionManager;
        private IUnityContainer unityContainer;
        public ProductMenuModule(IRegionManager regionManager,IUnityContainer unityContainer)
        {
            this.regionManager = regionManager;
            this.unityContainer = unityContainer;
        }

        public void Initialize()
        {
            unityContainer.RegisterTypeForNavigation<ProductMenu>();
            unityContainer.RegisterTypeForNavigation<ProductPage>();
            unityContainer.RegisterTypeForNavigation<ProductCatalog>();
            unityContainer.RegisterType<IProductRepository, ProductRepository>();

            regionManager.RegisterViewWithRegion("ProductMenuModule", () => unityContainer.Resolve<ProductMenu>());
            
        }
    }
}
