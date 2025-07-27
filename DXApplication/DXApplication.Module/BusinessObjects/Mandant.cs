using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
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
        public int MandantId { get; set; }

        [Persistent("MANDANT_KOD")]
        public string Kod { get; set; }

        [Persistent("MANDANT_OPIS")]
        public string Opis { get; set; }

    }
}
