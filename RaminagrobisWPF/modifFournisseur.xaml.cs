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
    /// Logique d'interaction pour modifFournisseur.xaml
    /// </summary>
    public partial class modifFournisseur : Page
    {
        public modifFournisseur(FournisseurTemp fournisseur)
        {
            InitializeComponent();
            this.id.Text = fournisseur.ID.ToString();
            this.nom.Text = fournisseur.Nom;
            this.prenomC.Text = fournisseur.PrenomC;
            this.nomC.Text = fournisseur.NomC;
            this.sexe.Text = fournisseur.SexeC;
            this.adresse.Text = fournisseur.Adresse;
            this.email.Text = fournisseur.Email;
            
        }
        private void Modif(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44355/", new HttpClient());
            FournisseurTemp fournisseur = new FournisseurTemp()
            {
                ID = Int32.Parse(this.id.Text),
                Nom = this.nom.Text,
                PrenomC = this.prenomC.Text,
                NomC = this.nomC.Text,
                SexeC = this.sexe.Text,
                Email = this.email.Text,
                Adresse = this.adresse.Text
            };

            clientApi.FournisseursPUTAsync(Int32.Parse(this.id.Text), fournisseur);
        }
    }
}
