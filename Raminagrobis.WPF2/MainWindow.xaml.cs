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

namespace Raminagrobis.WPF2
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabSelected = ((sender as TabControl).SelectedItem as TabItem).Name;
            switch (tabSelected)
            {
                case "TabItemFournisseur":
                    MainFrame.Content = new Pages.Fournisseur.MainPage();
                    break;
                case "TabItemAdherent":
                    MainFrame.Content = new Pages.Adherent.MainPage();
                    break;
                case "TabItemReference":
                    MainFrame.Content = new Pages.Reference.MainPage();
                    break;
                case "TabItemPanier":
                    MainFrame.Content = new Pages.Panier.MainPage();
                    break;
                default://meme chose que pour TabItemFournisseur
                    break;

            }
        }
    }
}
