using ADO.NET_Task3.Commands;
using ADO.NET_Task3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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

        public TextBox SearchTb { get; set; }
        public string DefaultText = "Search for product . . .";

        public HomePageUCViewModel()
        {
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
                if (SearchTb.Text.Trim() == DefaultText)
                {
                    SearchTb.Text = String.Empty;
                }
            });

            MouseLeaveCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == String.Empty && SearchTb.IsFocused == false)
                {
                    SearchTb.Text = DefaultText;
                }
            });


            IsNotFocusedCommand = new RelayCommand((i) =>
            {
                string text = SearchTb.Text.Trim();
                if (text == String.Empty || text == DefaultText)
                {
                    SearchTb.Text = DefaultText;
                }
            });

            SearchCommand = new RelayCommand((s) => 
            {
                

            });
        }
    }
}
