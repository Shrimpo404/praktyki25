using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.ExpressApp.DC;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("KLIENCI")]
    public class Klient : XPLiteObject
    {
        public Klient(Session session) : base(session) { }

        [Key(true)]
        [Persistent("KLIENCI_ID")]
        public int Id { get; set; }

        [Persistent("KLIENCI_KOD")]
        [XafDisplayName("Firma kod")]
        public string Kod { get; set; }

        [Persistent("KLIENCI_OPIS")]
        [XafDisplayName("Firma opis")]
        public string Opis { get; set; }

        [Association("Firma-Wydzialy")]
        public XPCollection<Wydzial> Wydzialy => GetCollection<Wydzial>(nameof(Wydzialy));
    }
}
