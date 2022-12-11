using ADO.NET_Task3.Commands;
using ADO.NET_Task3.Helpers;
using ADO.NET_Task3.Models;
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

        public Product Product { get; set; }

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
                await App.DatabaseHelper.DeleteProductById(Product.Id);
                ProductWindow.Close();
                MessageBox.Show("Product was deleted successfully!");
                var view = App.ProductViews.FirstOrDefault(p => (p.DataContext as ProductUCViewModel).Product.Id == Product.Id);
                App.ProductViews.Remove(view);
            });
        }
    }
}
