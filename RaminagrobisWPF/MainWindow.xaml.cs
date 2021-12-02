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

        }


        private void BtnClickRef(object sender, RoutedEventArgs e)
        {
            Main.Content = new Reference();
        }
        private void BtnClickFournisseur(object sender, RoutedEventArgs e)
        {
            Main.Content = new Fournisseur();
        }

        private void BtnClickAdh(object sender, RoutedEventArgs e)
        {
            Main.Content = new Adherent();
        }
        private void BtnClickPanier(object sender, RoutedEventArgs e)
        {
            Main.Content = new Panier();
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
    }
}
