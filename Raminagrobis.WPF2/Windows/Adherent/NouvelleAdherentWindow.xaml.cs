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
using Raminagrobis.WPF2.Pages;

namespace Raminagrobis.WPF2.Windows.Adherent
{
    /// <summary>
    /// Logique d'interaction pour NouvelleAdherentWindow.xaml
    /// </summary>
    public partial class NouvelleAdherentWindow : Window
    {
        private ApiPage _api;
        public NouvelleAdherentWindow()
        {
            InitializeComponent();
            _api = new ApiPage();
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            _api.ClientApi.AdherentPOSTAsync(new ApiClient.AdherentTemp()
            {
                Nom = pNom.Text,
                PrenomC = pPrenomC.Text,
                NomC = pNomC.Text,
                Adresse = pAdresse.Text,
                Email = pEmail.Text,
                SexeC = (string)(pSexeC.SelectedItem as ComboBoxItem).Content,
                DateA = pDateA.DisplayDate
            });
            this.Close();
        }
    }
}
