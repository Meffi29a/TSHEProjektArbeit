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
    /// Interaktionslogik für Zutaten.xaml
    /// </summary>
    public partial class Zutaten : UserControl
    {
        public string TestText { get; set; } = "Blubbertest";
        public Zutaten()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
