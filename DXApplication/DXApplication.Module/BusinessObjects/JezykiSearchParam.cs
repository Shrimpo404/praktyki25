using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DomainComponent]
    public class JezykiSearchParam
    {
        [XafDisplayName("Jezyk kod")]
        public string JezykKod { get; set; }

        [XafDisplayName("Jezyk opis")]
        public string JezykOpis { get; set; }
    }
}
