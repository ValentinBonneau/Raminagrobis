﻿using Raminagrobis.API.Client;
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
using System.IO;
using System.Collections.ObjectModel;
using System.Net.Http.Handlers;
using System.Windows.Threading;
using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace RaminagrobisWPF
{
    /// <summary>
    /// Logique d'interaction pour ajouterAdherent.xaml
    /// </summary>
    public partial class ajouterReference : Page
    {

        public ajouterReference()
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
        

    }
}
