using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DomainComponent]
    public class PlanPracySearchParam
    {
        [XafDisplayName("Plan pracy kod")]
        public string PlanKod { get; set; }

        [XafDisplayName("Plan pracy opis")]
        public string PlanOpis { get; set; }
    }
}