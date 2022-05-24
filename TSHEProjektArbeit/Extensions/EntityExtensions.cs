using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TSHEProjektArbeit
{
    public partial class Personen
    {
        public bool IsSelectedInUi { get; set; }

        public double ReinerAlkoholinGramm
        {
            get
            {
                var _reinerAlkoholinGramm = 0.0;

                using (var datenbank = new AlCulatorBD())
                {

                    var AlleReSuZeilenInRezept = datenbank.Re_Su.Where(x => x.Rezept_ID == 1).ToList();
                    //List<Substanzen> alleSubstanzenInRezept = new List<Substanzen>(); //das hatten wir mal hinzugefügt, aber irgendwie doch nicht gebraucht! 

                    foreach (var zeileReSu in AlleReSuZeilenInRezept)
                    {
                        var milliliter = zeileReSu.Menge;
                        var substanz = datenbank.Substanzen.Where(y => y.Id == zeileReSu.Substanz_ID).First();
                        // alleSubstanzenInRezept.Add(substanz); //wird nie benutzt, kann also weg!
                        var volumengehalt = substanz.Volumengehlat;
                        var substanzinrezeptalkohol = (milliliter * volumengehalt * 0.01 * 0.789);
                        _reinerAlkoholinGramm = _reinerAlkoholinGramm + substanzinrezeptalkohol;
                    }
                }
                return _reinerAlkoholinGramm;
            }
        }
    }
}

