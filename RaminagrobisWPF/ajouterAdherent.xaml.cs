using Raminagrobis.API.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using RaminagrobisDTO;

namespace RaminagrobisWPF
{
    /// <summary>
    /// Logique d'interaction pour ajouterAdherent.xaml
    /// </summary>
    public partial class ajouterAdherent : Page
    {

        public ajouterAdherent()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Ca serait mieux de mettre l'URL dans un fichier de config plutôt qu'en dur ici
            var clientApi = new Client("https://localhost:44355/", new HttpClient());

            //le async et le await c'est de la programmation asynchrone en C#
            var adherent = await clientApi.AdherentAllAsync();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44355/", new HttpClient());

            AdherentTemp Adherent = new AdherentTemp();
            Adherent.Nom = nom.Text;
            Adherent.PrenomC = prenomC.Text;
            Adherent.NomC = nomC.Text;
            Adherent.SexeC = sexe.Text;
            Adherent.Adresse = adresse.Text;
            Adherent.Email = email.Text;
            Adherent.DateA = date.DisplayDate;

            clientApi.AdherentPOSTAsync(Adherent);
        }
    }
}
