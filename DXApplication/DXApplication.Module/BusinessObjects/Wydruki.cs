using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("WYDRUKI")]
    public class Wydruki : XPLiteObject
    {
        public Wydruki(Session session) : base(session) { }

        [Key(true)]
        [Persistent("KATEGORIA")]
        [Browsable(false)]
        public int Kategoria { get; set; }

        [Persistent("WYDRUK_KOD")]
        public int WydrukKod { get; set; }

        [Persistent("WYDRUK_OPIS")]
        public string WydrukOpis { get; set; }

        [Persistent("RAPORT")]
        public string Raport { get; set; }

        [Persistent("WIDOCZNY")]
        public short Widoczny { get; set; }

        [Persistent("ARCHIWIZUJ")]
        public short Archiwizuj { get; set; }

        [Persistent("UTWORZONY_PRZEZ")]
        public string UtworzonyPrzez { get; set; }

        [Persistent("DATA_DODANIA")]
        public DateTime DataDodania { get; set; }

        [Persistent("EDYTOWANY_PRZEZ")]
        public String EdytowanyPrzez { get; set; }

        [Persistent("DATA_EDYCJI")]
        public DateTime DataEdycji { get; set; }

    }
}