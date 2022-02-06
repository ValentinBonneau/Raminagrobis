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

namespace Raminagrobis.WPF2.Pages.Reference
{
    /// <summary>
    /// Logique d'interaction pour MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private ApiPage _api;
        public MainPage()
        {
            InitializeComponent();
            _api = new ApiPage();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var references = await _api.ClientApi.ReferenceAllAsync();
            Liste.ItemsSource = references;
        }
    }
}
