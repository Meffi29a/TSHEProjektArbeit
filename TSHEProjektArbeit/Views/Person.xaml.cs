using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Collections.ObjectModel;

namespace TSHEProjektArbeit.Views
{
    /// <summary>
    /// Interaktionslogik für Person.xaml
    /// </summary>
       
    public partial class Person : UserControl
    {
        private int _SelectedPersonId = 0;

        public ObservableCollection<Personen> PersonenInDB { get; set; } = new ObservableCollection<Personen>();
        public Personen NewPerson { get; set; } = new Personen();
        public Personen SelectedPerson
        {
            get
            {
                return  ((MainWindow)Application.Current.MainWindow).SelectedPersonForMainWindow;
            }
            set
            {
               // var person = ((MainWindow)Application.Current.MainWindow).SelectedPersonForMainWindow;
               

                ((MainWindow)Application.Current.MainWindow).SelectedPersonForMainWindow.Id = value.Id;
                ((MainWindow)Application.Current.MainWindow).SelectedPersonForMainWindow.Name = value.Name;
                ((MainWindow)Application.Current.MainWindow).SelectedPersonForMainWindow.Gewicht = value.Gewicht;
                ((MainWindow)Application.Current.MainWindow).SelectedPersonForMainWindow.Alter = value.Alter;
                ((MainWindow)Application.Current.MainWindow).SelectedPersonForMainWindow.Geschlecht = value.Geschlecht;

            }
        }
        public Person()
        {
            var ergebniss = wannkannichfahren(20, SelectedPerson);


            NewPerson.Name = "Person";
            using (var DB = new AlCulatorBD())
            {
                var persons = DB.Personen.ToList();
               
                NewPerson.Id = persons.First().Id;
                NewPerson.Name = persons.First().Name;
                NewPerson.Gewicht = persons.First().Gewicht;
                NewPerson.Alter = persons.First().Alter;
                NewPerson.Geschlecht = persons.First().Geschlecht;

                foreach (var person in persons)
                {
                    PersonenInDB.Add(person);
                }

            }

            this.Language = XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name);

            InitializeComponent();
            DataContext = this;
        }


        private int wannkannichfahren(int alkohol, Personen probant)
        {

            return 4;


        }



        //strg + k, + c
        private void AddPersonToDB_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void AddPersonToDB_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            try
            {
                using (var DB = new AlCulatorBD())
                {
                    var karteikartePerson = new Personen()
                    {
                        
                        Name = NewPerson.Name,
                        Alter = NewPerson.Alter,
                        Geschlecht = NewPerson.Geschlecht,
                        Gewicht = NewPerson.Gewicht,
                        Groesse = NewPerson.Groesse,
                      

                    };
                    DB.Personen.Add(karteikartePerson);

                    DB.SaveChanges();
                }

            }
            catch (DbEntityValidationException Ex)
            {
                MessageBox.Show("There was a problem accessing the database, please try again.");

            }



            // MessageBox.Show("The New command was invoked");
            //PersonenInDB.Add(NewPerson);
           PersonenInDB.Clear();

            using (var DB = new AlCulatorBD())
            {
                var persons = DB.Personen.ToList();

                foreach (var person in persons)
                {


                    PersonenInDB.Add(person);

                }

            }




        }
    }
}
