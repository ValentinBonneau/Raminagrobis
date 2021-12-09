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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Ca serait mieux de mettre l'URL dans un fichier de config plutôt qu'en dur ici
            var clientApi = new Client("https://localhost:44355/", new HttpClient());

            //le async et le await c'est de la programmation asynchrone en C#
            LesFenetres.MainWindow = this;
        }


        private void BtnClickRef(object sender, RoutedEventArgs e)
        {
            LesFenetres.Reference= new Reference();
            Main.Content = LesFenetres.Reference;
        }
        private void BtnClickFournisseur(object sender, RoutedEventArgs e)
        {
            LesFenetres.Fournisseur = new Fournisseur();
            Main.Content = LesFenetres.Fournisseur;
        }

        private void BtnClickAdh(object sender, RoutedEventArgs e)
        {
            LesFenetres.Adherent = new Adherent();
            Main.Content = LesFenetres.Adherent;
        }
        private void BtnClickPanier(object sender, RoutedEventArgs e)
        {
            LesFenetres.Panier = new Panier();
            Main.Content = LesFenetres.Panier;
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content != null)
            {
                if (Main.Content.GetType() == typeof(Fournisseur))
                {
                    Main.Content = new ajouterFournisseur();
                }
                if (Main.Content.GetType() == typeof(Adherent))
                {
                    Main.Content = new ajouterAdherent();
                }
                if (Main.Content.GetType() == typeof(Reference))
                {
                    Main.Content = new ajouterReference();
                }
            }
        }
        

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content != null)
            {
                if (Main.Content.GetType() == typeof(Fournisseur))
                {
                    Main.Content = new supprFournisseur();
                }
                if (Main.Content.GetType() == typeof(Adherent))
                {
                    Main.Content = new supprAdherent();
                }
                if (Main.Content.GetType() == typeof(Reference))
                {
                    Main.Content = new supprReference();
                }

            }
        }
        private void Modif_Click(object sender, RoutedEventArgs e)
        {
            if (Main.Content != null)
            {
                if (Main.Content.GetType() == typeof(Reference))
                {

                    ReferenceTemp reference = (ReferenceTemp)LesFenetres.Reference.liste.SelectedItem;
                    Main.Content = new modifReference(reference);
                }
                if (Main.Content.GetType() == typeof(Fournisseur))
                {
                    FournisseurTemp fournisseur = (FournisseurTemp)LesFenetres.Fournisseur.liste.SelectedItem;
                    Main.Content = new modifFournisseur(fournisseur);
                }
                if (Main.Content.GetType() == typeof(Adherent))
                {
                    AdherentTemp adherent = (AdherentTemp)LesFenetres.Adherent.liste.SelectedItem;
                    Main.Content = new modifAdherent(adherent);
                }
            }
        }
       public void Hide_Button()
        {
            modif.Visibility = Visibility.Hidden;
        }
        public void View_Button()
        {
            modif.Visibility = Visibility.Visible;
        }

    }
}
