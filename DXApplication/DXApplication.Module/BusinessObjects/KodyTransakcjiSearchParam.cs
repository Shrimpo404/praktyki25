using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DomainComponent]
    public class KodyTransakcjiSearchParam
    {
        [XafDisplayName("Kod transakcji kod")]
        public string Kod { get; set; }

        [XafDisplayName("Kod transakcji opis")]
        public string Opis { get; set; }
    }
}
