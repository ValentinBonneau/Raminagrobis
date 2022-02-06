using Raminagrobis.API.Client;
using RaminagrobisDTO;
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

namespace RaminagrobisWPF
{
    /// <summary>
    /// Logique d'interaction pour modifAdherent.xaml
    /// </summary>
    public partial class modifAdherent : Page
    {
        public modifAdherent(AdherentTemp adherent)
        {
            InitializeComponent();
            this.id.Text = adherent.ID.ToString();
            this.nom.Text = adherent.Nom;
            this.prenomC.Text = adherent.PrenomC;
            this.nomC.Text = adherent.NomC;
            this.sexe.Text = adherent.SexeC;
            this.adresse.Text = adherent.Adresse;
            this.email.Text = adherent.Email;
            this.date.Text = adherent.DateA.ToString();
        }

        private void Modif(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44355/", new HttpClient());
            AdherentTemp adherent = new AdherentTemp()
            {
                ID = Int32.Parse(this.id.Text),
                Nom = this.nom.Text,
                PrenomC = this.prenomC.Text,
                NomC = this.nomC.Text,
                SexeC = this.sexe.Text,
                Email = this.email.Text,
                Adresse = this.adresse.Text,
                
            };

            clientApi.AdherentPUTAsync(Int32.Parse(this.id.Text), adherent);
        }
    }
}
