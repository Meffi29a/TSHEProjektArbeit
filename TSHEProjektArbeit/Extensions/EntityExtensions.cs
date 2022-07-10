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
                var _reinerAlkoholinGramm = 1.0;

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

        //Anwendung der Widmark-Formel zum Ausrechnen des Promillewerts der ausgewählten Person
        //Kennzeichnung des Bruchs als Double, da sonst merkwürdigerweise (??) als Integer gerundet wird 
        public double Ergebnis
        {
            get
            {
                var promillewert = (((double)this.ReinerAlkoholinGramm / this.Gewicht) * rWert);

                return promillewert;
            }
        }

        // Letztendliche Wahr-Falch-Abfrage

        public bool KannIchNochFahren
        {
            get
            {


                var _kannichnochfahren = true;
                var _promillecheck = true;

                // Überprüfung der gesetzlichen 0.5 Promille-Grenze, erstmal alterunabhängig
                //(roman) hier währe noch gut gewesen wenn man die Promillegrenzen als Variable rausgeführ hätte. Es kann sich eine Verordnung auch mal ändern, dann ist das programm nutzlos...
                if (Ergebnis <= 0.50 && Ergebnis > 0.00)
                {
                    _promillecheck = true;
                }
                else
                {
                    _promillecheck = false;
                }

                // Altersüberprüfung
                if (Ergebnis == 0)
                {
                    _kannichnochfahren = true;
                }
                else if (this.Alter >= 21 && _promillecheck)
                {
                    _kannichnochfahren = true;
                }
                else
                {
                    _kannichnochfahren = false;
                }

                return _kannichnochfahren;
            }
        }


        // rWert-Abfrage, wobei sich bewusst für die gegebenen Annäherungswerte entschieden wurde, aufgrund besserer Ergebnisse 
        public double rWert
        {
            get
            {
                var _rWertMann = 0.7;            // 1 - (2.447 - 0.0915 * this.Alter + 0.1074 * this.Groesse + 0.3362 * this.Gewicht) / 100;
                var _rWertFrau = 0.6;            // 1 - (-0.203 - 0.07 * this.Alter + 0.1069 * this.Groesse + 0.2466 * this.Gewicht) / 100;

                if (this.Geschlecht)
                {
                    return _rWertFrau;
                }
                else
                {
                    return _rWertMann;
                }
            }
        }
    }

        public partial class Rezepte
        {

        

        public double ReinerAlkoholInGrammGruppe5
            {
            /// <summary>
            /// Gruppe 5 Ihr habt grundsätzlich verstanden wie man einen Dtenbank mit "Entity Frames" abfrägt 
            /// Ihr habt verstanden wie man eine virtuelle Klasse erweitert um diese dann mit einer neuen Funktion Funktion zu versehen
            /// Eure Benennung von Variablen folgt den Richtlinien eines C# Programmierers
            /// Die Formatierunhg des codes ist 
            /// Ihr habt den code mit Kommentaren erweitert, das hilft anderen euren Code zu verstehen
            /// </summary>
            /// 
            // was macht das denn hier, Das ist ja nur blind aus der Vorlage mitkopiert :D
            //public bool IsSelectedInUi { get; set; } 

            get
            {
                    // Hilfsvariablen für die Berechnung
                    var summeAlkohol = 0.0; // Startwert
                    var dichteAlkohol = 0.789; // Konstante
                    var umrechnungsfaktor = 0.01; // Konstante für Umrechung % in dezimal

                    // Zugriff auf Datenbank
                    using (var datenbank = new AlCulatorBD())
                    {
                        // Abfrage der Mengen aus der Datenbank
                       // var reSuInhalte = datenbank.Re_Su.Where(x => x.Rezept_ID == 1).ToList(); // (Roman) das war der Dummy, der kann weg (Kein Mangel, das war so vorgegeben)
                        var reSuInhalte = datenbank.Re_Su.Where(x => x.Rezept_ID == this.Id).ToList(); //(Roman) Wir wollen ja vom expliziten Rezept daher die reflection


                        // Berechnungsschleife
                        foreach (var zeileReSu in reSuInhalte)
                        {
                            var inhaltInMilliliter = zeileReSu.Menge;
                            var substanz = datenbank.Substanzen.Where(y => y.Id == zeileReSu.Substanz_ID).First();
                            var volumenprozent = substanz.Volumengehlat;
                            var berechnung = (inhaltInMilliliter * volumenprozent * umrechnungsfaktor * dichteAlkohol);
                            summeAlkohol = summeAlkohol + berechnung;
                        }
                    }
                    return summeAlkohol; // Rückgabewert Alkohol in Gramm
                }
            }
        public double ReinerAlkoholInGrammGruppe7
        {
            /// <summary>
            /// Gruppe 7 Ihr habt grundsätzlich verstanden wie man einen Dtenbank mit "Entity Frames" abfrägt 
            /// Ihr habt verstanden wie man eine virtuelle Klasse erweitert um diese dann mit einer neuen Funktion Funktion zu versehen
            /// Eure Benennung von Variablen folgt den Richtlinien eines C# Programmierers
            /// Die Formatierunhg des codes ist sinvoll
            /// Ihr habt auf die Komentarfunktion verzichtet. Andere können euren Code daher nur aus dem zusammenhang verstehen
            /// </summary>

            get
            {
                var _reinerAlkoholinGramm = 0.0;

                using (var datenbank = new AlCulatorBD())
                {

                    var AlleReSuZeilenInRezept = datenbank.Re_Su.Where(x => x.Rezept_ID == 1).ToList();
                    List<Substanzen> alleSubstanzenInRezept = new List<Substanzen>();

                    foreach (var zeileReSu in AlleReSuZeilenInRezept)
                    {
                        var milliliter = zeileReSu.Menge;
                        var substanz = datenbank.Substanzen.Where(y => y.Id == zeileReSu.Substanz_ID).First();
                        alleSubstanzenInRezept.Add(substanz);
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



