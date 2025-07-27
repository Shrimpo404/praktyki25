using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("ZAKLADY")]
    public class Zaklad : XPLiteObject
    {
        public Zaklad(Session session) : base(session) { }

        [Key(true)]
        [Persistent("ZAKLADY_ID")]
        [Browsable(false)]
        public int Id { get; set; }

        [Persistent("ZAKLADY_OPIS")]
        [XafDisplayName("Zakład opis")]
        public string Opis { get; set; }

        [Persistent("ZAKLADY_KOD")]
        [XafDisplayName("Zakład kod")]
        public string Kod { get; set; }

        [Association("Mandant-Zaklady")]
        [Persistent("MDT")]
        [XafDisplayName("Mandat")]
        public Mandant Mandant { get; set; }
    }
}
