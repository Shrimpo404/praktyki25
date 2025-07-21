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
        public string WALUTA_KOD { get; set; }

        [Persistent("WALUTA_OPIS")]
        public string WALUTA_OPIS { get; set; }

        [Association("Waluta-KursyWalut")]
        public XPCollection<SloKursyWaluty> KursyWalut
        {
            get { return GetCollection<SloKursyWaluty>(nameof(KursyWalut)); }
        }
    }
}