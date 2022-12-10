using ADO.NET_Task3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ADO.NET_Task3.ViewModels
{
    public class MoreAboutProductWindowViewModel : BaseViewModel
    {
        public Product Product { get; set; }

        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; OnPropertyChanged();}
        }

        public MoreAboutProductWindowViewModel(Product product, ImageSource _imageSource)
        {
            Product = product;
            ImageSource = _imageSource;
        }
    }
}
