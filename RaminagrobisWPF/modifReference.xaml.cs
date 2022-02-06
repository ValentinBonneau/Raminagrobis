﻿using Raminagrobis.API.Client;
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
    /// Logique d'interaction pour modifReference.xaml
    /// </summary>
    public partial class modifReference : Page
    {
        public modifReference(ReferenceTemp reference)
        {
            InitializeComponent();
            this.id.Text = reference.ID.ToString();
            this.refs.Text = reference.ReferenceO;
            this.nom.Text = reference.Nom;
            this.marque.Text = reference.Marque;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Ca serait mieux de mettre l'URL dans un fichier de config plutôt qu'en dur ici
            var clientApi = new Client("https://localhost:44355/", new HttpClient());

            
            
        }

        private void Modif(object sender, RoutedEventArgs e)
        {
            var clientApi = new Client("https://localhost:44355/", new HttpClient());

            
        }

        
    }
}
