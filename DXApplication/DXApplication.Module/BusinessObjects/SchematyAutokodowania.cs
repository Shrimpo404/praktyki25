using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("AUTO_KOD_SCHEMATY")]
    [DefaultProperty("AUTO_KOD_SCHEMATY")]
    public class SchematyAutokodowania : XPLiteObject
    {
        public SchematyAutokodowania(Session session) : base(session) { }

        [Key(true)]
        [Persistent("AUTO_KOD_SCHEMATY_ID")]
        public int AutoKodSchematID { get; set; }

        [Persistent("SCHEMAT_KOD")]
        public string Kod_Schemat { get; set; }

        [Persistent("SCHEMAT_OPIS")]
        public string Opis_Schemat { get; set; }

        [Persistent("TYP")]
        public int Typ { get; set; }

        [Persistent("AUTO_KOD_SCHEMATY_KOD")]
        public string Schemat_Kodu { get; set; }

        [Persistent("AUTO_KOD_SCHEMATY_OPIS")]
        public string Schemat_Opisu { get; set; }


    }
}