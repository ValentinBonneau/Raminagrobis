using Raminagrobis.WPF2.Pages;
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

namespace Raminagrobis.WPF2.Windows.Panier
{
    /// <summary>
    /// Logique d'interaction pour AjouterParAdherentWindow.xaml
    /// </summary>
    public partial class AjouterParAdherentWindow : Window
    {
        private ApiPage _api;
        private System.IO.Stream CSV { get; set; }
        private int idAdh { get; set; }
        public AjouterParAdherentWindow(int idAdherent)
        {
            InitializeComponent();
            _api = new ApiPage();
            this.idAdh = idAdherent;
        }

        private void BtnFile_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".csv";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                BtnFile.Content = $"Ouvrir ('{filename}' selectioné)";
                CSV = dlg.OpenFile();
            }
        }

        private async void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (CSV != null)
            {
                await _api.ClientApi.PanierAsync(idAdh,DatePick.DisplayDate, new FileParameter(CSV));
                this.Close();
            }

        }
    }
}
