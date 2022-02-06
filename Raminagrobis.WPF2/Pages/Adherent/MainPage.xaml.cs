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
using Raminagrobis.WPF2.Windows.Adherent;

namespace Raminagrobis.WPF2.Pages.Adherent
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
            var adherent = await _api.ClientApi.AdherentAllAsync();
            Liste.ItemsSource = adherent;
            Liste.Columns.First().IsReadOnly = true;
        }

        private void Liste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var adh = ((sender as DataGrid).SelectedItem as AdherentTemp);
            if(adh != null)
            {
                optionPage.Content = new OptionsPage(adh);
            }
            else
            {
                optionPage.Content = null;
            }
            
        }

        private void BtnNouveau_Click(object sender, RoutedEventArgs e)
        {
            var nouvelleAdherent = new NouvelleAdherentWindow();
            nouvelleAdherent.Show();
        }

        async private void Btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            var adherent = await _api.ClientApi.AdherentAllAsync();
            Liste.ItemsSource = adherent;
            Liste.Columns.First().IsReadOnly = true;
        }
    }
}
