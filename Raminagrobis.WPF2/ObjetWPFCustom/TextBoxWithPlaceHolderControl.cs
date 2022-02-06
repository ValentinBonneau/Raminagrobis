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

namespace Raminagrobis.WPF2.ObjetWPFCustom
{
    /// <summary>
    /// Suivez les étapes 1a ou 1b puis 2 pour utiliser ce contrôle personnalisé dans un fichier XAML.
    ///
    /// Étape 1a) Utilisation de ce contrôle personnalisé dans un fichier XAML qui existe dans le projet actif.
    /// Ajoutez cet attribut XmlNamespace à l'élément racine du fichier de balisage où il doit 
    /// être utilisé :
    ///
    ///     xmlns:MyNamespace="clr-namespace:Raminagrobis.WPF2.ObjetWPFCustom"
    ///
    ///
    /// Étape 1b) Utilisation de ce contrôle personnalisé dans un fichier XAML qui existe dans un autre projet.
    /// Ajoutez cet attribut XmlNamespace à l'élément racine du fichier de balisage où il doit 
    /// être utilisé :
    ///
    ///     xmlns:MyNamespace="clr-namespace:Raminagrobis.WPF2.ObjetWPFCustom;assembly=Raminagrobis.WPF2.ObjetWPFCustom"
    ///
    /// Vous devrez également ajouter une référence du projet contenant le fichier XAML
    /// à ce projet et regénérer pour éviter des erreurs de compilation :
    ///
    ///     Cliquez avec le bouton droit sur le projet cible dans l'Explorateur de solutions, puis sur
    ///     "Ajouter une référence"->"Projets"->[Recherchez et sélectionnez ce projet]
    ///
    ///
    /// Étape 2)
    /// Utilisez à présent votre contrôle dans le fichier XAML.
    ///
    ///     <MyNamespace:TextBoxWithPlaceHolderControl/>
    ///
    /// </summary>
    public class TextBoxWithPlaceHolderControl : TextBox
    {
        public string PlaceHolder { get; set; }
        private Brush PreviousBrush { get; set; }
        public TextBoxWithPlaceHolderControl() :base()
        {
            PreviousBrush = Foreground;
            Foreground = new SolidColorBrush(Color.FromRgb(148, 148, 148));
            this.Text = PlaceHolder;
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxWithPlaceHolderControl), new FrameworkPropertyMetadata(typeof(TextBoxWithPlaceHolderControl)));
        }
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            if (Text == PlaceHolder)
            {
                Foreground = PreviousBrush;
                Text = "";
            }
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);
            if (string.IsNullOrWhiteSpace(Text))
            {
                PreviousBrush = Foreground;
                Foreground = new SolidColorBrush(Color.FromRgb(148, 148, 148));
                Text = PlaceHolder;
            }
        }
    }
}
