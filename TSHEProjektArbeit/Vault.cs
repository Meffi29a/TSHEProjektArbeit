using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSHEProjektArbeit
{
    public class Vault : INotifyPropertyChanged
    {



        public Personen SelectedPerson { 
            get;
            set;
        } 

        public Vault()
        {

            SelectedPerson = new Personen
            {
                Name = "Testperson",
                Alter = 40,
                Geschlecht = true,
                Gewicht = 60,
                Groesse = 170
            };
        }
       


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
