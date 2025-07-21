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
        [Persistent("AUTO_KOD_SCHEMAT_ID")]
        public int AutoKodSchematID { get; set; }

        [Persistent("KOD_SCHEMAT")]
        public string KodSchemat { get; set; }

        [Persistent("OPIS_SCHEMATU")]
        public string OpisSchematu { get; set; }

        [Persistent("TYP")]
        public int Typ { get; set; }

        [Persistent("SCHEMAT_KODU")]
        public string SchematKodu { get; set; }

        [Persistent("SCHEMAT_OPISU")]
        public string SchematOpisu { get; set; }


    }
}