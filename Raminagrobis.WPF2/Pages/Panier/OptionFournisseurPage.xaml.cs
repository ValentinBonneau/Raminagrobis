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


namespace Raminagrobis.WPF2.Pages.Panier
{
    /// <summary>
    /// Logique d'interaction pour OptionFournisseurPage.xaml
    /// </summary>
    public partial class OptionFournisseurPage : Page
    {
        private DateTime _semaine;
        private int _id;
        private ApiPage _api;
        public OptionFournisseurPage(DateTime semaine,int idFournisseur)
        {
            InitializeComponent();
            _api = new ApiPage();
            _id = idFournisseur;
            _semaine = semaine;
        }

        private void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            var url = $"{_api.ClientApi.BaseUrl.TrimEnd('/')}/Global/{Uri.EscapeDataString(_semaine.ToString("s", System.Globalization.CultureInfo.InvariantCulture))}/Fournissseur/{_id}";
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            System.Diagnostics.Process.Start(psi);
        }

        private async void UploadBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".csv";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                var CSV = dlg.OpenFile();
                await _api.ClientApi.FournisseurPOSTAsync(_semaine, _id, new ApiClient.FileParameter(CSV));
            }
        }
    }
}
