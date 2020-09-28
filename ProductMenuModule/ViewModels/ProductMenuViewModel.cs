using DevExpress.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMenuModule.ViewModels
{
    public class ProductMenuViewModel : ViewModelBase
    {
        public DelegateCommand NavigateCommand { get; private set; }
        private IRegionManager regionManager;

        public ProductMenuViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
 
            regionManager.RequestNavigate("ProductMenuModule", new Uri("ProductCatalog",UriKind.Relative));
        }
    }
}
