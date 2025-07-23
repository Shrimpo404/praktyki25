using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using DevExpress.ExpressApp.ConditionalAppearance;
using System;
using System.ComponentModel;



namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("JEDNOSTKI")]
    [XafDefaultProperty(nameof(JEDNOSTKI_OPIS))]
    public class Jednostki : XPLiteObject
    {
        public Jednostki(Session session) : base(session) { }

        private int _JEDNOSTKI_ID;

        [Key(false)]
        [Persistent("JEDNOSTKI_ID")]
        [Browsable(false)]
        [Appearance("DisableJEDNOSTKI_ID", Enabled = false, Criteria = "True", Context = "DetailView")]
        [XafDisplayName("ID")]
        public int JEDNOSTKI_ID
        {
            get => _JEDNOSTKI_ID;
            set => SetPropertyValue(nameof(JEDNOSTKI_ID), ref _JEDNOSTKI_ID, value);
        }

        private string _JEDNOSTKI_KOD;

        [Persistent("JEDNOSTKI_KOD")]
        [Size(15)]
        [XafDisplayName("Jednostka kod")]
        [ModelDefault("Index", "0")]
        public string JEDNOSTKI_KOD
        {
            get => _JEDNOSTKI_KOD?.TrimEnd();
            set => SetPropertyValue(nameof(JEDNOSTKI_KOD), ref _JEDNOSTKI_KOD, value);
        }

        private string _JEDNOSTKI_OPIS;

        [Persistent("JEDNOSTKI_OPIS")]
        [Size(50)]
        [XafDisplayName("Jednostka opis")]
        [ModelDefault("Index", "1")]
        public string JEDNOSTKI_OPIS
        {
            get => _JEDNOSTKI_OPIS?.TrimEnd();
            set => SetPropertyValue(nameof(JEDNOSTKI_OPIS), ref _JEDNOSTKI_OPIS, value);
        }

        private bool? _PRZELICZENIOWA;

        [Persistent("PRZELICZENIOWA")]
        [XafDisplayName("Przeliczeniowa")]
        [ModelDefault("Index", "2")]
        public bool? PRZELICZENIOWA
        {
            get => _PRZELICZENIOWA;
            set => SetPropertyValue(nameof(PRZELICZENIOWA), ref _PRZELICZENIOWA, value);
        }

        private bool? _NIEPODZIELNA;

        [Persistent("NIEPODZIELNA")]
        [XafDisplayName("Niepodzielna")]
        [ModelDefault("Index", "3")]
        public bool? NIEPODZIELNA
        {
            get => _NIEPODZIELNA;
            set => SetPropertyValue(nameof(NIEPODZIELNA), ref _NIEPODZIELNA, value);
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (JEDNOSTKI_ID == 0)
            {
                var maxIdObj = Session.ExecuteScalar("SELECT COALESCE(MAX(JEDNOSTKI_ID),0) FROM JEDNOSTKI");
                JEDNOSTKI_ID = Convert.ToInt32(maxIdObj) + 1;
            }
        }
    }
}