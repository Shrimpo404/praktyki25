using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("WALUTA")]
    [DefaultProperty("WALUTA_KOD")]
    public class Waluta : XPLiteObject
    {
        public Waluta(Session session) : base(session) { }

        [Key(true)]
        [Persistent("WALUTA_ID")]
        [Browsable(false)]
        public int WALUTA_ID { get; set; }

        [Persistent("WALUTA_KOD")]
        [DevExpress.Xpo.DisplayName("Waluta Kod")]
        public string WALUTA_KOD { get; set; }

        [Persistent("WALUTA_OPIS")]
        [DevExpress.Xpo.DisplayName("Waluta Opis")]
        public string WALUTA_OPIS { get; set; }

        [Persistent("KURS")]
        [DevExpress.Xpo.DisplayName("Kurs budżetu")]
        public string KURS { get; set; }

        [Association("Waluta-KursyWalut")]
        public XPCollection<SloKursyWaluty> KursyWalut =>
            GetCollection<SloKursyWaluty>(nameof(KursyWalut));
    }
}