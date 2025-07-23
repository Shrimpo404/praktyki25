using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("TAGI")]
    [DefaultProperty("TAGI_KOD")]
    public class Tagi : XPLiteObject
    {
        public Tagi(Session session) : base(session) { }

        [Key(true)]
        [Persistent("TAGI_ID")]
        [Browsable(false)]
        public int TAGI_ID { get; set; }

        [Persistent("TAGI_KOD")]
        [DevExpress.Xpo.DisplayName("Tagi kod")] 

        public string TAGI_KOD { get; set; }

        [Persistent("TAGI_OPIS")]
        [DevExpress.Xpo.DisplayName("Tagi opis")]
        public string TAGI_OPIS { get; set; }

        [Persistent("KOLEJNOSC")]
        [DevExpress.Xpo.DisplayName("Kolejność")]
        public string KOLEJNOSC { get; set; }
    }
}