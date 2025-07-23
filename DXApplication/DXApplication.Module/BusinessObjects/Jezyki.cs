using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.ComponentModel;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("JEZYKI")]
    [XafDefaultProperty(nameof(JEZYK_OPIS))]
    public class Jezyki : XPLiteObject
    {
        public Jezyki(Session session) : base(session) { }

        private int _JEZYKI_ID;

        [Key(false)]
        [Persistent("JEZYKI_ID")]
        [Browsable(false)]
        [Appearance("DisableJEZYKI_ID", Enabled = false, Criteria = "True", Context = "DetailView")]
        [XafDisplayName("ID")]
        public int JEZYKI_ID
        {
            get => _JEZYKI_ID;
            set => SetPropertyValue(nameof(JEZYKI_ID), ref _JEZYKI_ID, value);
        }

        private string _JEZYK_KOD;

        [Persistent("JEZYK_KOD")]
        [Size(15)]
        [XafDisplayName("Jezyk kod")]
        [ModelDefault("Index", "0")]
        public string JEZYK_KOD
        {
            get => _JEZYK_KOD?.TrimEnd();
            set => SetPropertyValue(nameof(JEZYK_KOD), ref _JEZYK_KOD, value);
        }

        private string _JEZYK_OPIS;

        [Persistent("JEZYK_OPIS")]
        [Size(50)]
        [XafDisplayName("Jezyk opis")]
        [ModelDefault("Index", "1")]
        public string JEZYK_OPIS
        {
            get => _JEZYK_OPIS?.TrimEnd();
            set => SetPropertyValue(nameof(JEZYK_OPIS), ref _JEZYK_OPIS, value);
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (JEZYKI_ID == 0)
            {
                var maxIdObj = Session.ExecuteScalar("SELECT COALESCE(MAX(JEZYKI_ID),0) FROM JEZYKI");
                JEZYKI_ID = Convert.ToInt32(maxIdObj) + 1;
            }
        }
    }
}
