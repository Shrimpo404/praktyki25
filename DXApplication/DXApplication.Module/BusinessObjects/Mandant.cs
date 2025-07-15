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
    [Persistent("MANDANT")]
    public class Mandant : XPLiteObject
    {
        public Mandant(Session session) : base(session) { }

        [Key, Browsable(false)]
        [Persistent("MANDANT_ID")]
        public int MANDANT_ID
        {
            get => mandant_id;
            set => SetPropertyValue(nameof(MANDANT_ID), ref mandant_id, value);
        }
        private int mandant_id;

        [Persistent("MANDANT_KOD")]
        public string MANDANT_KOD
        {
            get => mandant_kod;
            set => SetPropertyValue(nameof(MANDANT_KOD), ref mandant_kod, value);
        }
        private string mandant_kod;

        [Persistent("MANDANT_OPIS")]
        public string MANDANT_OPIS
        {
            get => mandant_opis;
            set => SetPropertyValue(nameof(MANDANT_OPIS), ref mandant_opis, value);
        }
        private string mandant_opis;
    }
}
