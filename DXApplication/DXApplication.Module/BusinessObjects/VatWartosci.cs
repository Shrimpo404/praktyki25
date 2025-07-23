using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("VAT_WARTOSCI")]
    [XafDefaultProperty(nameof(Kod))]
    [OptimisticLocking(false)]
    public class VatWartosci : XPLiteObject
    {
        public VatWartosci(Session session) : base(session) { }

        private int _VatWartosciId;
        [Key(false)] 
        [Persistent("VAT_WARTOSCI_ID")]
        [Browsable(false)]
        public int VatWartosciId
        {
            get => _VatWartosciId;
            set => SetPropertyValue(nameof(VatWartosciId), ref _VatWartosciId, value);
        }

        private string _Kod;
        [Persistent("VAT_WARTOSCI_KOD"), Size(20)]
        [XafDisplayName("Kod Wartości VAT")]
        public string Kod
        {
            get => _Kod;
            set => SetPropertyValue(nameof(Kod), ref _Kod, value);
        }

        private decimal _Wartosc;
        [Persistent("WARTOSC")]
        [XafDisplayName("Wartość VAT")]
        public decimal Wartosc
        {
            get => _Wartosc;
            set => SetPropertyValue(nameof(Wartosc), ref _Wartosc, value);
        }

        private string _Stawka;
        [Persistent("VAT_STAWKA"), Size(10)]
        [XafDisplayName("Stawka VAT")]
        public string Stawka
        {
            get => _Stawka;
            set => SetPropertyValue(nameof(Stawka), ref _Stawka, value);
        }

        [Association("VatWartosci-VatPowiazania")]
        public XPCollection<VatPowiazania> Powiazania => GetCollection<VatPowiazania>(nameof(Powiazania));

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (VatWartosciId == 0)
            {
                var maxIdObj = Session.ExecuteScalar("SELECT COALESCE(MAX(VAT_WARTOSCI_ID),0) FROM VAT_WARTOSCI");
                VatWartosciId = System.Convert.ToInt32(maxIdObj) + 1;
            }
        }
    }
}