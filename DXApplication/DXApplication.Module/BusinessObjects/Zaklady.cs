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
    [Persistent("ZAKLADY")]
    public class Zaklady : XPLiteObject
    {
        public Zaklady(Session session) : base(session) { }
    }
}
