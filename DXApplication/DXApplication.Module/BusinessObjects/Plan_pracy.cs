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
    [Persistent("PLAN_PRACY")]
    [XafDefaultProperty(nameof(PLAN_PRACY_OPIS))]
    public class PlanPracy : XPLiteObject
    {
        public PlanPracy(Session session) : base(session) { }

        private int _PLAN_PRACY_ID;

        [Key(false)]
        [Persistent("PLAN_PRACY_ID")]
        [Browsable(false)]
        [Appearance("DisablePLAN_PRACY_ID", Enabled = false, Criteria = "True", Context = "DetailView")]
        [XafDisplayName("ID")]
        public int PLAN_PRACY_ID
        {
            get => _PLAN_PRACY_ID;
            set => SetPropertyValue(nameof(PLAN_PRACY_ID), ref _PLAN_PRACY_ID, value);
        }

        private string _PLAN_PRACY_KOD;

        [Persistent("PLAN_PRACY_KOD")]
        [Size(15)]
        [XafDisplayName("Plan pracy kod")]
        [ModelDefault("Index", "0")]
        public string PLAN_PRACY_KOD
        {
            get => _PLAN_PRACY_KOD?.TrimEnd();
            set => SetPropertyValue(nameof(PLAN_PRACY_KOD), ref _PLAN_PRACY_KOD, value);
        }

        private string _PLAN_PRACY_OPIS;

        [Persistent("PLAN_PRACY_OPIS")]
        [Size(50)]
        [XafDisplayName("Plan pracy opis")]
        [ModelDefault("Index", "1")]
        public string PLAN_PRACY_OPIS
        {
            get => _PLAN_PRACY_OPIS?.TrimEnd();
            set => SetPropertyValue(nameof(PLAN_PRACY_OPIS), ref _PLAN_PRACY_OPIS, value);
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (PLAN_PRACY_ID == 0)
            {
                var maxIdObj = Session.ExecuteScalar("SELECT COALESCE(MAX(PLAN_PRACY_ID), 0) FROM PLAN_PRACY");
                PLAN_PRACY_ID = Convert.ToInt32(maxIdObj) + 1;
            }
        }
    }
}