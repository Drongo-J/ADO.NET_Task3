using ADO.NET_Task3.Commands;
using ADO.NET_Task3.Helpers;
using ADO.NET_Task3.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ADO.NET_Task3.ViewModels
{
    public class HomePageUCViewModel : BaseViewModel
    {
        public RelayCommand MouseEnterCommand { get; set; }
        public RelayCommand MouseLeaveCommand { get; set; }
        public RelayCommand IsNotFocusedCommand { get; set; }
        public RelayCommand KeyDownCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand MoreCommand { get; set; }

        public ObservableCollection<ProductUC> ProductViews { get; set; }

        public TextBox SearchTb { get; set; }

        public HomePageUCViewModel()
        {
            ProductViews = App.ProductViews;

             App.DatabaseHelper.AddProductsToCollectionFromDatabase(400, 20, ProductViews);


            //await AddProductsToViewAsync();
                
            MoreCommand = new RelayCommand((uc) =>
            {
                var uc2 = uc;

            });

            KeyDownCommand = new RelayCommand((key) =>
            {
                var _key = key as string;
                if (_key[key.ToString().Length - 1] == '\r')
                {
                    SearchCommand.Execute(null);
                }
            });

            MouseEnterCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == Constants.SearchBoxDefaultText)
                {
                    SearchTb.Text = String.Empty;
                }
            });

            MouseLeaveCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == String.Empty && SearchTb.IsFocused == false)
                {
                    SearchTb.Text = Constants.SearchBoxDefaultText;
                }
            });


            IsNotFocusedCommand = new RelayCommand((i) =>
            {
                string text = SearchTb.Text.Trim();
                if (text == String.Empty || text == Constants.SearchBoxDefaultText)
                {
                    SearchTb.Text = Constants.SearchBoxDefaultText;
                }
            });

            SearchCommand = new RelayCommand((s) =>
            {


            });
        }

        private async Task AddProductsToViewAsync()
        {
            await App.DatabaseHelper.AddProductsToCollectionFromDatabase(400, 20, App.ProductViews);
        }
    }
}
