using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using ProductMenuModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMenuModule
{
    public class ProductCatalogModule : IModule
    {
        private IUnityContainer container;
        public ProductCatalogModule(IUnityContainer container)
        {
            this.container = container;
        }
        public void Initialize()
        {
            container.RegisterTypeForNavigation<ProductCatalog>();
            
        }
    }
}
