using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Xpo.Metadata;
using DevExpress.ExpressApp.DC;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("VAT_POWIAZANIA")]
    [OptimisticLocking(false)]
    [XafDefaultProperty(nameof(DisplayMember))]
    public class VatPowiazania : XPLiteObject
    {
        public VatPowiazania(Session session) : base(session) { }

        private int _VatPowiazaniaId;
        [Key(false)]
        [Persistent("VAT_POWIAZANIA_ID")]
        [Browsable(false)]
        public int VatPowiazaniaId
        {
            get => _VatPowiazaniaId;
            set => SetPropertyValue(nameof(VatPowiazaniaId), ref _VatPowiazaniaId, value);
        }

        private VatOpisy _vatOpisy;
        [Association("VatOpisy-VatPowiazania")]
        [Persistent("VAT_OPISY_ID")]
        [XafDisplayName("Opis VAT")]
        public VatOpisy VatOpisy
        {
            get => _vatOpisy;
            set => SetPropertyValue(nameof(VatOpisy), ref _vatOpisy, value);
        }

        private VatSposoby _vatSposoby;
        [Association("VatSposoby-VatPowiazania")]
        [Persistent("VAT_SPOSOBY_ID")]
        [XafDisplayName("Sposób VAT")]
        public VatSposoby VatSposoby
        {
            get => _vatSposoby;
            set => SetPropertyValue(nameof(VatSposoby), ref _vatSposoby, value);
        }

        private VatWartosci _vatWartosci;
        [Association("VatWartosci-VatPowiazania")]
        [Persistent("VAT_WARTOSCI_ID")]
        [XafDisplayName("Wartość VAT")]
        public VatWartosci VatWartosci
        {
            get => _vatWartosci;
            set => SetPropertyValue(nameof(VatWartosci), ref _vatWartosci, value);
        }

        private string _vatOpisyKod;
        [Persistent("VAT_OPISY_KOD")]
        [Size(20)]
        [XafDisplayName("Kod Opisu (kopia)")]
        public string VatOpisyKod
        {
            get => _vatOpisyKod;
            set => SetPropertyValue(nameof(VatOpisyKod), ref _vatOpisyKod, value);
        }

        private string _vatOpisyOpis;
        [Persistent("VAT_OPISY_OPIS")]
        [Size(255)]
        [XafDisplayName("Opis (kopia)")]
        public string VatOpisyOpis
        {
            get => _vatOpisyOpis;
            set => SetPropertyValue(nameof(VatOpisyOpis), ref _vatOpisyOpis, value);
        }

        private string _vatSposobyKod;
        [Persistent("VAT_SPOSOBY_KOD")]
        [Size(20)]
        [XafDisplayName("Kod Sposobu (kopia)")]
        public string VatSposobyKod
        {
            get => _vatSposobyKod;
            set => SetPropertyValue(nameof(VatSposobyKod), ref _vatSposobyKod, value);
        }

        private string _vatSposobyOpis;
        [Persistent("VAT_SPOSOBY_OPIS")]
        [Size(255)]
        [XafDisplayName("Opis Sposobu (kopia)")]
        public string VatSposobyOpis
        {
            get => _vatSposobyOpis;
            set => SetPropertyValue(nameof(VatSposobyOpis), ref _vatSposobyOpis, value);
        }

        private string _vatWartosciKod;
        [Persistent("VAT_WARTOSCI_KOD")]
        [Size(20)]
        [XafDisplayName("Kod Wartości (kopia)")]
        public string VatWartosciKod
        {
            get => _vatWartosciKod;
            set => SetPropertyValue(nameof(VatWartosciKod), ref _vatWartosciKod, value);
        }

        private decimal _wartosc;
        [Persistent("WARTOSC")]
        [XafDisplayName("Wartość (kopia)")]
        public decimal Wartosc
        {
            get => _wartosc;
            set => SetPropertyValue(nameof(Wartosc), ref _wartosc, value);
        }

        [NonPersistent]
        [VisibleInListView(true), VisibleInDetailView(true)]
        public string DisplayMember
        {
            get
            {
                return $"{VatOpisy?.Kod} / {VatSposoby?.Kod} / {VatWartosci?.Kod}";
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (VatPowiazaniaId == 0)
            {
                var maxIdObj = Session.ExecuteScalar("SELECT COALESCE(MAX(VAT_POWIAZANIA_ID),0) FROM VAT_POWIAZANIA");
                VatPowiazaniaId = System.Convert.ToInt32(maxIdObj) + 1;
            }
        }
    }
}