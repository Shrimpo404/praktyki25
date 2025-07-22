using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("AUTO_NUM_SCHEMAT")]
    public class AutoNumSchemat : XPLiteObject
    {
        public AutoNumSchemat(Session session) : base(session) {
            this.Session.LockingOption = LockingOption.None;
        }

        [Key(false)]
        [Appearance("DisableAUTO_NUM_SCHEMAT_ID", Enabled = false, Criteria = "True", Context = "DetailView")]
        [Persistent("AUTO_NUM_SCHEMAT_ID")]
        [Browsable(true)]
        [XafDisplayName("ID")]
        [ModelDefault("Index", "0")]
        public int AUTO_NUM_SCHEMAT_ID
        {
            get => autoNumSchematId;
            set => SetPropertyValue(nameof(AUTO_NUM_SCHEMAT_ID), ref autoNumSchematId, value);
        }
        private int autoNumSchematId;

        [Persistent("TYP")]
        [XafDisplayName("Typ")]
        [ModelDefault("Index", "2")]
        public short TYP
        {
            get => typ;
            set => SetPropertyValue(nameof(TYP), ref typ, value);
        }
        private short typ;

        [Persistent("SEPARATOR")]
        [Size(20)]
        [XafDisplayName("Separator kodu")]
        [ModelDefault("Index", "4")]
        public string SEPARATOR
        {
            get => separator;
            set => SetPropertyValue(nameof(SEPARATOR), ref separator, value);
        }
        private string separator;

        [Persistent("RESET_TYP")]
        [XafDisplayName("Resetowanie")]
        [ModelDefault("Index", "7")]
        public short RESET_TYP
        {
            get => resetTyp;
            set => SetPropertyValue(nameof(RESET_TYP), ref resetTyp, value);
        }
        private short resetTyp;

        [Persistent("SCHEMAT")]
        [Size(100)]
        [XafDisplayName("Schemat")]
        [ModelDefault("Index", "3")]
        public string SCHEMAT
        {
            get => schemat;
            set => SetPropertyValue(nameof(SCHEMAT), ref schemat, value);
        }
        private string schemat;

        [Persistent("INS_DATE")]
        [ModelDefault("DisplayFormat", "dd.MM.yyyy HH:mm")]
        [ModelDefault("EditMask", "dd.MM.yyyy HH:mm")]
        [XafDisplayName("Utworzona dnia")]
        [ModelDefault("Index", "9")]
        public DateTime INS_DATE
        {
            get => insDate;
            set => SetPropertyValue(nameof(INS_DATE), ref insDate, value);
        }
        private DateTime insDate;

        [Persistent("INSERTED_BY")]
        [Size(50)]
        [XafDisplayName("Utworzona przez")]
        [ModelDefault("Index", "10")]
        public string INSERTED_BY
        {
            get => insertedBy;
            set => SetPropertyValue(nameof(INSERTED_BY), ref insertedBy, value);
        }
        private string insertedBy;

        [Persistent("EDI_DATE")]
        [ModelDefault("DisplayFormat", "dd.MM.yyyy HH:mm")]
        [ModelDefault("EditMask", "dd.MM.yyyy HH:mm")]
        [XafDisplayName("Edi date")]
        public DateTime EDI_DATE
        {
            get => ediDate;
            set => SetPropertyValue(nameof(EDI_DATE), ref ediDate, value);
        }
        private DateTime ediDate;

        [Persistent("EDITING")]
        [Size(50)]
        [XafDisplayName("Editing")]
        public string EDITING
        {
            get => editing;
            set => SetPropertyValue(nameof(EDITING), ref editing, value);
        }
        private string editing;

        [Persistent("LICZBA_CYFR_W_NR_KOL")]
        [XafDisplayName("Liczba cyfr w nr kol.")]
        [ModelDefault("Index", "8")]
        public short LICZBA_CYFR_W_NR_KOL
        {
            get => liczbaCyfrWNrKol;
            set => SetPropertyValue(nameof(LICZBA_CYFR_W_NR_KOL), ref liczbaCyfrWNrKol, value);
        }
        private short liczbaCyfrWNrKol;

        [Persistent("ZNAK_1")]
        [Size(20)]
        [XafDisplayName("Znak")]
        [ModelDefault("Index", "6")]
        public string ZNAK_1
        {
            get => znak1;
            set => SetPropertyValue(nameof(ZNAK_1), ref znak1, value);
        }
        private string znak1;

        [Persistent("AUTO_NUM_SCHEMAT_KOD")]
        [Size(20)]
        [XafDisplayName("Kod")]
        [ModelDefault("Index", "1")]
        public string AUTO_NUM_SCHEMAT_KOD
        {
            get => autoNumSchematKod;
            set => SetPropertyValue(nameof(AUTO_NUM_SCHEMAT_KOD), ref autoNumSchematKod, value);
        }
        private string autoNumSchematKod;

        [Persistent("AUTO_NUM_SCHEMAT_OPIS")]
        [Size(60)]
        [XafDisplayName("Opis")]
        [ModelDefault("Index", "13")]
        public string AUTO_NUM_SCHEMAT_OPIS
        {
            get => autoNumSchematOpis;
            set => SetPropertyValue(nameof(AUTO_NUM_SCHEMAT_OPIS), ref autoNumSchematOpis, value);
        }
        private string autoNumSchematOpis;

        [Persistent("SCHEMAT_KOD")]
        [Size(100)]
        [XafDisplayName("Schemat kod")]
        [ModelDefault("Index", "11")]
        public string SCHEMAT_KOD
        {
            get => schematKod;
            set => SetPropertyValue(nameof(SCHEMAT_KOD), ref schematKod, value);
        }
        private string schematKod;

        [Persistent("SCHEMAT_OPIS")]
        [Size(100)]
        [XafDisplayName("Schemat opis")]
        [ModelDefault("Index", "12")]
        public string SCHEMAT_OPIS
        {
            get => schematOpis;
            set => SetPropertyValue(nameof(SCHEMAT_OPIS), ref schematOpis, value);
        }
        private string schematOpis;

        [Persistent("SEPARATOR_OPIS")]
        [Size(20)]
        [XafDisplayName("Separator opis")]
        [ModelDefault("Index", "5")]
        public string SEPARATOR_OPIS
        {
            get => separatorOpis;
            set => SetPropertyValue(nameof(SEPARATOR_OPIS), ref separatorOpis, value);
        }
        private string separatorOpis;


        protected override void OnSaving()
        {
            if (Session.IsNewObject(this) && AUTO_NUM_SCHEMAT_ID == 0)
            {
                AUTO_NUM_SCHEMAT_ID = Convert.ToInt32(Session.ExecuteScalar("SELECT GEN_ID(SET_AUTO_NUM_SCHEMAT_ID, 1) FROM RDB$DATABASE"));
            }
            base.OnSaving();
        }

    }
}
