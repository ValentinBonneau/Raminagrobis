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
using Raminagrobis.WPF2.ApiClient;
using Raminagrobis.WPF2.Windows.Fournisseur;

namespace Raminagrobis.WPF2.Pages.Fournisseur
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
            var fournisseur = await _api.ClientApi.FournisseursAllAsync();
            Liste.ItemsSource = fournisseur;
            Liste.Columns.First().IsReadOnly = true;
        }

        private void Liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var fourn = ((sender as DataGrid).SelectedItem as FournisseurTemp);
            if (fourn != null)
            {
                optionPage.Content = new OptionsPage(fourn);
            }
        }

        private void BtnNouveau_Click(object sender, RoutedEventArgs e)
        {
            var win = new NouveauFournisseurWindow();
            win.Show();
        }

        private async void Btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            Liste.ItemsSource = await _api.ClientApi.FournisseursAllAsync();
        }
    }
}
