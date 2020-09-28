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
    public class ProductPageModule : IModule
    {
        private IUnityContainer container;
        public ProductPageModule(IUnityContainer container)
        {
            this.container = container;
        }
        public void Initialize()
        {
            container.RegisterTypeForNavigation<ProductPage>();

        }
    }
}
