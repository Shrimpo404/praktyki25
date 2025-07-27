using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("MANDANT")]
    public class Mandant : XPLiteObject
    {
        public Mandant(Session session) : base(session) { }

        [Key(true)]
        [Persistent("MANDANT_ID")]
        [Browsable(false)]
        public int Id { get; set; }

        [Persistent("MANDANT_KOD")]
        [XafDisplayName("Mandat kod")]
        public string Kod { get; set; }

        [Persistent("MANDANT_OPIS")]
        [XafDisplayName("Mandat opis")]
        public string Opis { get; set; }

        [Association("Mandant-Zaklady")]
        public XPCollection<Zaklad> Zaklady => GetCollection<Zaklad>(nameof(Zaklady));
    }
}
