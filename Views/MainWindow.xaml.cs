﻿using ADO.NET_Task3.Helpers;
using ADO.NET_Task3.ViewModels;
using ADO.NET_Task3.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO.NET_Task3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = mainWindowViewModel;
            App.MyGrid = MyGrid;
            var homePage = new HomePageUC();
            var homePageViewModel = new HomePageUCViewModel();
            homePage.DataContext = homePageViewModel;
            homePageViewModel.SearchTb = homePage.SearchTB;
            App.MyGrid.Children.Add(homePage);
            //DatabaseHelper.AddProductsToListFromDatabase(402,20);
        }
    }
}
