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



        public int SelectedPersonId { 
            get;
            set;
        } 

        public Vault()
        {

            
        }
       


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
