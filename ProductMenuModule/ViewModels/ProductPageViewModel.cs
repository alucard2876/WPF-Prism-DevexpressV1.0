using DevExpress.Mvvm;
using Domain.Entities;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMenuModule.ViewModels
{
    public class ProductPageViewModel : ViewModelBase, INavigationAware
    {
        private IRegionManager regionManager;

        public Product Product
        {
            get => GetProperty(() => Product);
            private set => SetProperty(() => Product, value);
        }

        public DelegateCommand BackNavigate { get; private set; }

        public ProductPageViewModel(IRegionManager manager)
        {
            regionManager = manager;
            BackNavigate = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
            var region = regionManager.Regions["ProductMenuModule"];
            region.NavigationService.Journal.GoBack();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Product = navigationContext.Parameters["Product"] as Product;
        }
    }
}
