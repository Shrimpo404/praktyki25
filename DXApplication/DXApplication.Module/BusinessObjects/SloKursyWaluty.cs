using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model; 

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("SLO_KURSY_WALUTY")]
    public class SloKursyWaluty : XPLiteObject
    {
        public SloKursyWaluty(Session session) : base(session) { }

        [Key(true)]
        [Persistent("SLO_KURSY_WALUTY_ID")]
        [Browsable(false)]
        public int SLO_KURSY_WALUTY_ID { get; set; }

        [NonPersistent]
        [DevExpress.Xpo.DisplayName("Kod")]
        [VisibleInListView(true)] 
        [VisibleInLookupListView(true)]
        public string WalutaKod => Waluta?.WALUTA_KOD;

   
        [Association("Waluta-KursyWalut")]
        [Persistent("WALUTA_ID")]
        [VisibleInListView(false)] 
        [VisibleInLookupListView(false)]
        public Waluta Waluta { get; set; }

        [Persistent("KURS_Z_DNIA")]
        [DevExpress.Xpo.DisplayName("Kurs z dnia")]
        public DateTime KursZDnia { get; set; }

        [Persistent("NUMER_TABELI")]
        public string NumerTabeli { get; set; }

        [Persistent("KURS")]
        public string Kurs { get; set; }

        [Persistent("DATA_OD")]
        public DateTime WazneOd { get; set; }

        [Persistent("DATA_DO")]
        public DateTime WazneDo { get; set; }
    }
}