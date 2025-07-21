using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.ComponentModel;

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

        [Persistent("KURS_Z_DNIA")]
        public DateTime KursZDnia { get; set; }

        [Persistent("NUMER_TABELI")]
        public string NumerTabeli { get; set; }

        [Persistent("KURS")]
        public decimal Kurs { get; set; }

        [Persistent("DATA_OD")]
        public DateTime WazneOd { get; set; }

        [Persistent("DATA_DO")]
        public DateTime WazneDo { get; set; }

        [Association("Waluta-KursyWalut")]
        [Persistent("WALUTA_ID")] 
        public Waluta Waluta { get; set; }

    }
}