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

namespace TSHEProjektArbeit.Views
{
    /// <summary>
    /// Interaktionslogik für KannIchNochFahren.xaml
    /// </summary>
    public partial class KannIchNochFahren : UserControl
    {
       
        public KannIchNochFahren()
        {
            InitializeComponent();
        }


        // Button zum Ausführen der personenbezogenen Promillewert-Berechnung
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Die in der Datenbank ausgewählte Person wird hiermit verwendet
            var person = ((MainWindow)Application.Current.MainWindow).SelectedPersonForMainWindow;

            // Darstellung der Ergebnisse der Promillewert-Berechnung
            if (person.KannIchNochFahren)
            {
                No.Visibility = Visibility.Hidden;
                Yes.Visibility = Visibility.Visible;
                Ausgabe.Text =  person.Ergebnis.ToString();
            }

            else
            {
                Yes.Visibility = Visibility.Hidden;
                No.Visibility = Visibility.Visible;
                Ausgabe.Text = person.Ergebnis.ToString();
            }
        }

        // Button zur Anzeige der aktuell ausgewählten Person
        private void PersonButton_Click(object sender, RoutedEventArgs e)
        {
            var person = ((MainWindow)Application.Current.MainWindow).SelectedPersonForMainWindow;
            PersonBlock.Text = person.Name;
        }
    }







}
