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
    [Persistent("KODY_TRANSAKCJI")]
    [XafDefaultProperty(nameof(OPIS))]
    public class KodyTransakcji : XPLiteObject
    {
        public KodyTransakcji(Session session) : base(session) { }

        private int _KODY_TRANSAKCJI_ID;

        [Key(false)]
        [Persistent("KODY_TRANSAKCJI_ID")]
        [Browsable(false)]
        [Appearance("DisableKODY_TRANSAKCJI_ID", Enabled = false, Criteria = "True", Context = "DetailView")]
        [XafDisplayName("ID")]
        public int KODY_TRANSAKCJI_ID
        {
            get => _KODY_TRANSAKCJI_ID;
            set => SetPropertyValue(nameof(KODY_TRANSAKCJI_ID), ref _KODY_TRANSAKCJI_ID, value);
        }

        private string _KOD;

        [Persistent("KOD")]
        [Size(15)]
        [XafDisplayName("Kod transakcji")]
        [ModelDefault("Index", "0")]
        public string KOD
        {
            get => _KOD?.TrimEnd();
            set => SetPropertyValue(nameof(KOD), ref _KOD, value);
        }

        private string _OPIS;

        [Persistent("OPIS")]
        [Size(50)]
        [XafDisplayName("Kod transakcji opis")]
        [ModelDefault("Index", "1")]
        public string OPIS
        {
            get => _OPIS?.TrimEnd();
            set => SetPropertyValue(nameof(OPIS), ref _OPIS, value);
        }

        private bool _DEPOZYT;

        [Persistent("DEPOZYT")]
        [XafDisplayName("Depozyt")]
        [ModelDefault("Index", "2")]
        public bool DEPOZYT
        {
            get => _DEPOZYT;
            set => SetPropertyValue(nameof(DEPOZYT), ref _DEPOZYT, value);
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (KODY_TRANSAKCJI_ID == 0)
            {
                var maxIdObj = Session.ExecuteScalar("SELECT COALESCE(MAX(KODY_TRANSAKCJI_ID), 0) FROM KODY_TRANSAKCJI");
                int maxId = Convert.ToInt32(maxIdObj);
                KODY_TRANSAKCJI_ID = maxId + 1;
            }
        }
    }
}
