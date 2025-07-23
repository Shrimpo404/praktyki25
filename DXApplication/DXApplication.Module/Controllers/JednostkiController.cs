using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DXApplication.Module.BusinessObjects;



namespace DXApplication.Module.Controllers
{
    public class JednostkiController : ViewController<ListView>
    {
        private PopupWindowShowAction szukajPopup;
        private SimpleAction wyczyscFiltry;

        public JednostkiController()
        {
            TargetObjectType = typeof(Jednostki);

            szukajPopup = new PopupWindowShowAction(this, "SzukajJednostki", PredefinedCategory.Filters)
            {
                Caption = "Szukaj jednostki",
                ImageName = "Action_Search"
            };
            szukajPopup.CustomizePopupWindowParams += SzukajPopup_CustomizePopupWindowParams;
            szukajPopup.Execute += SzukajPopup_Execute;

            wyczyscFiltry = new SimpleAction(this, "WyczyscFiltryJednostki", PredefinedCategory.Filters)
            {
                Caption = "Wyczyść filtry",
                ImageName = "Action_Clear"
            };
            wyczyscFiltry.Execute += (s, e) =>
            {
                View.CollectionSource.Criteria.Remove("SearchCriteria");
            };
        }

        private void SzukajPopup_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var os = Application.CreateObjectSpace(typeof(JednostkiSearchParam));
            var param = os.CreateObject<JednostkiSearchParam>();

            var dv = Application.CreateDetailView(os, param);
            dv.ViewEditMode = ViewEditMode.Edit;

            e.View = dv;
            e.DialogController.SaveOnAccept = true;
        }

        private void SzukajPopup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var param = e.PopupWindowViewCurrentObject as JednostkiSearchParam;

            CriteriaOperator criteria = CriteriaOperator.Parse("JEDNOSTKI_ID > 0");

            if (!string.IsNullOrWhiteSpace(param.JednostkaKod))
            {
                criteria = new GroupOperator(GroupOperatorType.And, criteria,
                    CriteriaOperator.Parse("Contains(JEDNOSTKI_KOD, ?)", param.JednostkaKod));
            }

            if (!string.IsNullOrWhiteSpace(param.JednostkaOpis))
            {
                criteria = new GroupOperator(GroupOperatorType.And, criteria,
                    CriteriaOperator.Parse("Contains(JEDNOSTKI_OPIS, ?)", param.JednostkaOpis));
            }

            View.CollectionSource.Criteria["SearchCriteria"] = criteria;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            View.CollectionSource.Criteria["Base"] = CriteriaOperator.Parse("JEDNOSTKI_ID > 0");
        }
    }
}