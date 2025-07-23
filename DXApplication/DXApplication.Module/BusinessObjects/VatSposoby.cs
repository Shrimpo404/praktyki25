using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("VAT_SPOSOBY")]
    [XafDefaultProperty(nameof(Opis))]
    [OptimisticLocking(false)]
    public class VatSposoby : XPLiteObject
    {
        public VatSposoby(Session session) : base(session) { }

        private int _VatSposobyId;
        [Key(false)] 
        [Persistent("VAT_SPOSOBY_ID")]
        [Browsable(false)]
        public int VatSposobyId
        {
            get => _VatSposobyId;
            set => SetPropertyValue(nameof(VatSposobyId), ref _VatSposobyId, value);
        }

        private string _Kod;
        [Persistent("VAT_SPOSOBY_KOD"), Size(20)]
        [XafDisplayName("Kod Sposobu VAT")]
        public string Kod
        {
            get => _Kod;
            set => SetPropertyValue(nameof(Kod), ref _Kod, value);
        }

        private string _Opis;
        [Persistent("VAT_SPOSOBY_OPIS"), Size(255)]
        [XafDisplayName("Opis Sposobu VAT")]
        public string Opis
        {
            get => _Opis;
            set => SetPropertyValue(nameof(Opis), ref _Opis, value);
        }

        [Association("VatSposoby-VatPowiazania")]
        public XPCollection<VatPowiazania> Powiazania => GetCollection<VatPowiazania>(nameof(Powiazania));

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (VatSposobyId == 0)
            {
                var maxIdObj = Session.ExecuteScalar("SELECT COALESCE(MAX(VAT_SPOSOBY_ID),0) FROM VAT_SPOSOBY");
                VatSposobyId = System.Convert.ToInt32(maxIdObj) + 1;
            }
        }
    }
}