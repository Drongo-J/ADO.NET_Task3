using ADO.NET_Task3.Commands;
using ADO.NET_Task3.Helpers;
using ADO.NET_Task3.Models;
using ADO.NET_Task3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ADO.NET_Task3.ViewModels
{
    public class MoreAboutProductWindowViewModel : BaseViewModel
    {
        public Window ProductWindow { get; set; }

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }

        private Product product;

        public Product Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }


        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged(); }
        }

        public MoreAboutProductWindowViewModel(Product product, ImageSource _imageSource, Window productWindow)
        {
            Product = product;
            ImageSource = _imageSource;
            ProductWindow = productWindow;

            DeleteCommand = new RelayCommand(async (d) =>
            {
                await DatabaseHelper.DeleteProductById(Product.Id);
                ProductWindow.Close();
                MessageBox.Show("Product was deleted successfully!");
                //DatabaseHelper.AddProductsToCollectionFromDatabase(400,20, ((App.MyGrid.Children[0] as HomePageUC).DataContext as HomePageUCViewModel).ProductViews);
                //DatabaseHelper.AddProductsToCollectionFromDatabase(400, 20, App.ProductViews);
                App.ProductViews.Remove(App.ProductViews.FirstOrDefault(p => p.Id.Text == Product.Id.ToString()));
                //var view = ProductViews.FirstOrDefault(p => (p.DataContext as ProductUCViewModel).Product.Id == Product.Id);
                //ProductViews.Remove(view);
            });

            SaveChangesCommand = new RelayCommand(async (e) => 
            {
                await DatabaseHelper.UpdateProduct(Product);
                ProductWindow.Close();
                MessageBox.Show("Product was updated successfully!");
            });
        }
    }
}
