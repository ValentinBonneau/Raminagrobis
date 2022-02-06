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
using System.Windows.Shapes;
using Raminagrobis.WPF2.ApiClient;
using Raminagrobis.WPF2.Pages;

namespace Raminagrobis.WPF2.Windows.Fournisseur
{
    /// <summary>
    /// Logique d'interaction pour NouveauFournisseurWindow.xaml
    /// </summary>
    public partial class NouveauFournisseurWindow : Window
    {
        private ApiPage _api;
        public NouveauFournisseurWindow()
        {
            InitializeComponent();
            _api = new ApiPage();
        }

        private async void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            await _api.ClientApi.FournisseursPOSTAsync(new FournisseurTemp()
            {
                Nom = pNom.Text,
                NomC = pNomC.Text,
                PrenomC = pPrenomC.Text,
                SexeC = (string)(pSexeC.SelectedItem as ComboBoxItem).Content ,
                Email = pEmail.Text,
                Adresse = pAdresse.Text,
            }) ;
            this.Close();
        }
    }
}
