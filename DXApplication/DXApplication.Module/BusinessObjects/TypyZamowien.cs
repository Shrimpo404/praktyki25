using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("ZAMOWIENIA_TYP")]
    public class ZamowieniaTyp : XPLiteObject
    {
        public ZamowieniaTyp(Session session) : base(session) { }

        [Key(true)]
        [Persistent("ZAMOWIENIA_TYP_ID")]
        [Browsable(false)]
        public int ZamowieniaTypId { get; set; }

        [Persistent("ZAMOWIENIA_TYP_OPIS")]
        public string Opis { get; set; }

        [Persistent("ZAMOWIENIE_RODZAJ")]
        public string Rodzaj { get; set; }

        [Persistent("PRODUKCJA")]
        public bool Produkcja { get; set; }

        [Persistent("KONTROLUJ_KLUCZ")]
        public bool KontrolujKlucz { get; set; }

        [Persistent("KONTROLUJ_KLUCZ_KLIENTA")]
        public bool KontrolujKluczKlienta { get; set; }

        [Persistent("NR_ZAM2KLUCZ")]
        public bool NrZam2Klucz { get; set; }

        [Persistent("KONTROLUJ_KOMISJE")]
        public bool KontrolujKomisje { get; set; }

        [Association("AutoNumSchemat-ZamowieniaTypy")]
        [Persistent("AUTO_NUM_SCHEMAT_ID")]
        public AutoNumSchemat AutoNumSchemat { get; set; }


        [Persistent("NUMER_START")]
        public int NumerStart { get; set; }

        [Persistent("INSERTED_BY")]
        public string InsertedBy { get; set; }

        [Persistent("INS_DATE")]
        public DateTime? InsertedDate { get; set; }

        [Persistent("EDITING")]
        public string Editing { get; set; }

        [Persistent("EDI_DATE")]
        public DateTime? EdiDate { get; set; }

        [Persistent("SCHEMAT_PRZYKLAD")]
        public string SchematPrzyklad { get; set; }

        [Persistent("AUTONUMER")]
        public bool Autonumer { get; set; }

        [Persistent("ZAMOWIENIA_TYP_KOD")]
        public string ZamowieniaTypKod { get; set; }

        [Persistent("EDI_KOD")]
        public string EdiKod { get; set; }

        [Persistent("BOOKING_RULES")]
        public string BookingRules { get; set; }

        [Persistent("WYKLUCZ_Z_MAT_DET_SERIA")]
        public bool WykluczZMatDetSeria { get; set; }

        [Persistent("BOOKING_ANONYMOUS_LEVEL")]
        public int BookingAnonymousLevel { get; set; }

        [Persistent("KONTROLA_WYSYLKI")]
        public bool KontrolaWysylki { get; set; }
    }

    [Persistent("AUTO_NUM_SCHEMAT")]
    public class AutoNumSchemat : XPLiteObject
    {
        public AutoNumSchemat(Session session) : base(session) { }

        [Key(true)]
        [Persistent("AUTO_NUM_SCHEMAT_ID")]
        [Browsable(false)]
        public int AutoNumSchematId { get; set; }

        [Persistent("AUTO_NUM_SCHEMAT_OPIS")]
        public string Opis { get; set; }

        [Association("AutoNumSchemat-ZamowieniaTypy")]
        public XPCollection<ZamowieniaTyp> ZamowieniaTypy => GetCollection<ZamowieniaTyp>(nameof(ZamowieniaTypy));
    }
}
