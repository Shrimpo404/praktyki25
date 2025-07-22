using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("WALUTA")]
    public class Waluta : XPLiteObject
    {
        public Waluta(Session session) : base(session) {
            this.Session.LockingOption = LockingOption.None;
        }

        [Key(false)]
        [Appearance("DisableWALUTA_ID", Enabled = false, Criteria = "True", Context = "DetailView")]
        [Persistent("WALUTA_ID")]
        [Browsable(false)]
        [XafDisplayName("ID")]
        public int WALUTA_ID
        {
            get => walutaId;
            set => SetPropertyValue(nameof(WALUTA_ID), ref walutaId, value);
        }
        private int walutaId;

        [Persistent("WALUTA_KOD")]
        [XafDisplayName("Waluta kod")]
        [ModelDefault("Index", "0")]
        [Size(15)]
        public string WALUTA_KOD
        {
            get => walutaKod?.TrimEnd(); 
            set => SetPropertyValue(nameof(WALUTA_KOD), ref walutaKod, value);
        }
        private string walutaKod;

        [Persistent("WALUTA_OPIS")]
        [XafDisplayName("Waluta opis")]
        [ModelDefault("Index", "1")]
        [Size(50)]
        public string WALUTA_OPIS
        {
            get => walutaOpis?.TrimEnd();
            set => SetPropertyValue(nameof(WALUTA_OPIS), ref walutaOpis, value);
        }
        private string walutaOpis;

        [Persistent("KURS")]
        [XafDisplayName("Kurs budżetowy")]
        [ModelDefault("Index", "2")]
        [Size(15)]
        public decimal KURS
        {
            get => kurs;
            set => SetPropertyValue(nameof(KURS), ref kurs, value);
        }
        private decimal kurs;

        [Persistent("INSERTED_BY")]
        [Browsable(false)]
        [Size(50)]
        public string INSERTED_BY
        {
            get => insertedBy;
            set => SetPropertyValue(nameof(INSERTED_BY), ref insertedBy, value);
        }
        private string insertedBy;

        [Persistent("INSERTING")]
        [Browsable(false)]
        [Size(50)]
        public string INSERTING
        {
            get => inserting;
            set => SetPropertyValue(nameof(INSERTING), ref inserting, value);
        }
        private string inserting;

        [Persistent("INS_DATE")]
        [Browsable(false)]
        public DateTime INS_DATE
        {
            get => insDate;
            set => SetPropertyValue(nameof(INS_DATE), ref insDate, value);
        }
        private DateTime insDate;

        [Persistent("EDITING")]
        [Browsable(false)]
        [Size(50)]
        public string EDITING
        {
            get => editing;
            set => SetPropertyValue(nameof(EDITING), ref editing, value);
        }
        private string editing;

        [Persistent("EDI_DATE")]
        [Browsable(false)]
        public DateTime EDI_DATE
        {
            get => ediDate;
            set => SetPropertyValue(nameof(EDI_DATE), ref ediDate, value);
        }
        private DateTime ediDate;

        [Persistent("ANAL_PROFIT_KURS")]
        [Browsable(false)]
        public double ANAL_PROFIT__KURS
        {
            get => analProfitKurs;
            set => SetPropertyValue(nameof(ANAL_PROFIT__KURS), ref analProfitKurs, value);
        }
        private double analProfitKurs;

        [Persistent("WIEKOWANIE_KURS")]
        [Browsable(false)]
        public double WIEKOWANIE_KURS
        {
            get => wiekowanieKurs;
            set => SetPropertyValue(nameof(WIEKOWANIE_KURS), ref wiekowanieKurs, value);
        }
        private double wiekowanieKurs;

        protected override void OnSaving()
        {
            if (Session.IsNewObject(this) && WALUTA_ID == 0)
            {
                WALUTA_ID = Convert.ToInt32(Session.ExecuteScalar("SELECT GEN_ID(SET_WALUTA_ID, 1) FROM RDB$DATABASE"));
            }

            base.OnSaving();
        }
    }
}
