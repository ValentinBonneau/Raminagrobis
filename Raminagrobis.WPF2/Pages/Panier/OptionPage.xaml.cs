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


namespace Raminagrobis.WPF2.Pages.Panier
{
    /// <summary>
    /// Logique d'interaction pour OptionPage.xaml
    /// </summary>
    public partial class OptionPage : Page
    {
        private ApiPage _api;
        private DateTime _semaine;
        public OptionPage(DateTime semaine)
        {
            InitializeComponent();

            _api = new ApiPage();
            _semaine = semaine;

            FournisseurChoix.ItemsSource = _api.ClientApi.FournisseursAllAsync().Result;
            FournisseurChoix.DisplayMemberPath = "Nom";
            AdherentChoix.ItemsSource = _api.ClientApi.AdherentAllAsync().Result;
            AdherentChoix.DisplayMemberPath = "Nom";
            
        } 
        private void FournisseurChoix_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BoutonsPourFournisseur.Content = new OptionFournisseurPage(_semaine, (int)((sender as ComboBox).SelectedItem as FournisseurTemp).Id);
        }

        private void AdherentChoix_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BoutonsPourAdherent.Content = new OptionAdherent(_semaine,(int)((sender as ComboBox).SelectedItem as AdherentTemp).Id);
        }
    }
}
