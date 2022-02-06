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
    /// Logique d'interaction pour OptionAdherent.xaml
    /// </summary>
    public partial class OptionAdherent : Page
    {
        private ApiPage _api;
        private DateTime _semaine;
        private int _id;
        public OptionAdherent(DateTime semaine,int idAdherent)
        {
            InitializeComponent();
            _api = new ApiPage();
            _semaine = semaine;
            _id = idAdherent;
        }

        private void DownloadBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start($"{_api.ClientApi.BaseUrl.TrimEnd('/')}/Global/{Uri.EscapeDataString(_semaine.ToString("s", System.Globalization.CultureInfo.InvariantCulture))}/cloture/{_id}");

        }
    }
}
