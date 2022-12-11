using ADO.NET_Task3.Commands;
using ADO.NET_Task3.Models;
using ADO.NET_Task3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ADO.NET_Task3.ViewModels
{
    public class ProductUCViewModel : BaseViewModel
    {
        public RelayCommand MoreCommand { get; set; }

        public Product Product { get; set; }

        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }

        public ProductUCViewModel(Product _product)
        {
            Product = _product;
            ImageSource = Helpers.ImageHelpers.StringToImageSource(Product.Image);

            MoreCommand = new RelayCommand((e) =>
            {
                var aboutProductView = new MoreAboutProductWindow();
                var aboutProductViewModel = new MoreAboutProductWindowViewModel(Product, ImageSource, aboutProductView);
                aboutProductView.DataContext = aboutProductViewModel;
                aboutProductView.Show();    
            });
        }
    }
}
