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
    public partial class MainPage : Page
    {
        private ApiPage _api;
        public MainPage()
        {
            InitializeComponent();
            _api = new ApiPage();
        }

        private void Calandrier_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var date = (DateTime)(sender as DatePicker).SelectedDate;
            var PanierG = _api.ClientApi.ClotureAsync(new DateTimeOffset(date));
            var lignePanierG = new List<LignePanierGDisplay>();
            if(PanierG.Result.LignesG.Count > 0)
            {
                foreach (var item in PanierG.Result.LignesG)
                {
                    lignePanierG.Add(new LignePanierGDisplay()
                    {
                        Id = item.Id,
                        Quantite = item.Quantite,
                        Reference = item.Reference,
                        Prix = item.Prix.Prix,
                        Fournisseur = item.Prix.IdFournisseur
                    });
                }
                Liste.ItemsSource = lignePanierG;
                optionPage.Content = new OptionPage(date);
            }

        }
    }


    internal class LignePanierGDisplay{
        public int? Id { get; set; }

        public string Reference { get; set; }

        public int Quantite { get; set; }

        public double Prix { get; set; }

        public int Fournisseur { get; set; }
    }
}
