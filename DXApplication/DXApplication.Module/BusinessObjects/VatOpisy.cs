using DevExpress.ExpressApp.DC; 
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("VAT_OPISY")]
    [XafDefaultProperty(nameof(Opis))] 
    [OptimisticLocking(false)]
    public class VatOpisy : XPLiteObject
    {
        public VatOpisy(Session session) : base(session) { }

        private int _VatOpisyId;
        [Key(false)] 
        [Persistent("VAT_OPISY_ID")]
        [Browsable(false)] 
        public int VatOpisyId
        {
            get => _VatOpisyId;
            set => SetPropertyValue(nameof(VatOpisyId), ref _VatOpisyId, value);
        }

        private string _Kod;
        [Persistent("VAT_OPISY_KOD"), Size(20)]
        [XafDisplayName("Kod Opisu VAT")]
        public string Kod
        {
            get => _Kod;
            set => SetPropertyValue(nameof(Kod), ref _Kod, value);
        }

        private string _Opis;
        [Persistent("VAT_OPISY_OPIS"), Size(255)]
        [XafDisplayName("Opis VAT")]
        public string Opis
        {
            get => _Opis;
            set => SetPropertyValue(nameof(Opis), ref _Opis, value);
        }

        [Association("VatOpisy-VatPowiazania")]
        public XPCollection<VatPowiazania> Powiazania => GetCollection<VatPowiazania>(nameof(Powiazania));

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (VatOpisyId == 0)
            {
                var maxIdObj = Session.ExecuteScalar("SELECT COALESCE(MAX(VAT_OPISY_ID),0) FROM VAT_OPISY");
                VatOpisyId = System.Convert.ToInt32(maxIdObj) + 1;
            }
        }
    }
}