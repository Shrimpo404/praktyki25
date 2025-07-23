using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DomainComponent]
    public class JednostkiSearchParam
    {
        [XafDisplayName("Jednostka kod")]
        public string JednostkaKod { get; set; }

        [XafDisplayName("Jednostka opis")]
        public string JednostkaOpis { get; set; }
    }
}