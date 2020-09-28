using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Domain.Entities;
using DomainAccess.Interfaces;
using Microsoft.Practices.Unity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMenuModule.ViewModels
{
    public class ProductCatalogViewModel : ViewModelBase
    {
        private IRegionManager regionManager;
        IUnityContainer container;
        public DelegateCommand NavigateCommand { get; private set; }
        public DelegateCommand<int> DeleteCommand { get; private set; }
        public DelegateCommand<int> CurrentProductCommand { get; private set; }
        public ObservableCollection<Product> Products
        {
            get => GetProperty(() => Products);
            private set => SetProperty(() => Products, value);
        }
        public Product CurrentProduct
        {
            get => GetProperty(() => CurrentProduct);
            set => SetProperty(() => CurrentProduct, value);
        }

        public ProductCatalogViewModel(IRegionManager regionManager,IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
            Products = this.container.Resolve<IProductRepository>().GetAllProduct().Data.ToObservableCollection();
            NavigateCommand = new DelegateCommand(Navigate);
            CurrentProductCommand = new DelegateCommand<int>(ToProduct);
            DeleteCommand = new DelegateCommand<int>(Delete);
        }

        private void Delete(int obj)
        {
            if (CurrentProduct.Id != obj)
                return;
            Products.Remove(CurrentProduct);
        }

        private void ToProduct(int obj)
        {
            if (CurrentProduct.Id != obj)
                return;
            var parametrs = new NavigationParameters();
            parametrs.Add("Product", CurrentProduct);
            regionManager.RequestNavigate("ProductMenuModule", "ProductPage", parametrs);
        }

        private void Navigate()
        {
            regionManager.RequestNavigate("ProductMenuModule", "ProductMenu");
        }
    }
}
