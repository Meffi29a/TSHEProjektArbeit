using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace TSHEProjektArbeit
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Personen SelectedPersonForMainWindow { 
            get; 
            set; 
        } = new Personen();
        public ObservableCollection<Rezepte> GetränkeListe
        {
            get;
            set;
        } = new ObservableCollection<Rezepte>();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
