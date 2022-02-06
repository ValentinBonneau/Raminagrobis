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
using Raminagrobis.WPF2.Windows.Panier;

namespace Raminagrobis.WPF2.Pages.Adherent
{
    /// <summary>
    /// Logique d'interaction pour OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        private AdherentTemp _adh;
        private ApiPage _api;
        public OptionsPage(AdherentTemp adherent)
        {
            _adh = adherent;
            _api = new ApiPage();
            InitializeComponent();
        }

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
            _api.ClientApi.AdherentPUTAsync((int)_adh.Id, _adh);
            NavigationService.Navigate(null);
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            _api.ClientApi.AdherentDELETEAsync((int)_adh.Id);
            NavigationService.Navigate(null);
        }

        private void BtnAjouterPanier_Click(object sender, RoutedEventArgs e)
        {
            var nouveauPanier = new AjouterParAdherentWindow((int)_adh.Id);
            nouveauPanier.Show();
        }
    }
}
