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

namespace Raminagrobis.WPF2.Pages.Fournisseur
{
    /// <summary>
    /// Logique d'interaction pour OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        private FournisseurTemp _fourn;
        private ApiPage _api;

        public OptionsPage(FournisseurTemp fourn)
        {
            InitializeComponent();
            _fourn = fourn;
            _api = new ApiPage();
        }

        private async void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
            await _api.ClientApi.FournisseursPUTAsync((int)_fourn.Id, _fourn);
            NavigationService.Navigate(null);
        }

        private async void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            await _api.ClientApi.FournisseursDELETEAsync((int)_fourn.Id);
            NavigationService.Navigate(null);
        }

        private async void BtnAjouterRef_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csv";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                var CSV = dlg.OpenFile();
                if (CSV != null)
                {
                    await _api.ClientApi.ReferencePOSTAsync((int)_fourn.Id, new FileParameter(CSV));
                }
            }
        }
    }
}
