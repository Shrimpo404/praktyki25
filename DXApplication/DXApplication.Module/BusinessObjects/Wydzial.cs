using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("LC_WYDZIALY")]
    public class Wydzial : XPLiteObject
    {
        public Wydzial(Session session) : base(session) { }

        [Key(true)]
        [Persistent("LC_WYDZIALY_ID")]
        [Browsable(false)]
        public int Id { get; set; }

        [Persistent("LC_WYDZIALY_KOD")]
        [XafDisplayName("Wydział kod")]
        public string Kod { get; set; }

        [Persistent("LC_WYDZIALY_OPIS")]
        [XafDisplayName("Wydział opis")]
        public string Opis { get; set; }

        [Association("Firma-Wydzialy")]
        [Persistent("KLIENCI_ID")]
        [XafDisplayName("Firma")]
        public Klient Firma { get; set; }

        [Persistent("PODSTAWOWY")]
        [XafDisplayName("Podstawowy")]
        public int Podstawowy { get; set; }

        [Persistent("BRAMKA")]
        [XafDisplayName("Bramka")]
        public int Bramka { get; set; }
    }
}
