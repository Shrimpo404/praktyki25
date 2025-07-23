using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DXApplication.Module.BusinessObjects;



namespace DXApplication.Module.Controllers
{
    public class PlanPracyController : ViewController<ListView>
    {
        private PopupWindowShowAction szukajPopup;
        private SimpleAction wyczyscFiltry;

        public PlanPracyController()
        {
            TargetObjectType = typeof(PlanPracy);

            szukajPopup = new PopupWindowShowAction(this, "SzukajPlanuPracy", PredefinedCategory.Filters)
            {
                Caption = "Szukaj planu pracy",
                ImageName = "Action_Search"
            };
            szukajPopup.CustomizePopupWindowParams += SzukajPopup_CustomizePopupWindowParams;
            szukajPopup.Execute += SzukajPopup_Execute;

            wyczyscFiltry = new SimpleAction(this, "WyczyscFiltryPlanuPracy", PredefinedCategory.Filters)
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
            var os = Application.CreateObjectSpace(typeof(PlanPracySearchParam));
            var param = os.CreateObject<PlanPracySearchParam>();

            var dv = Application.CreateDetailView(os, param);
            dv.ViewEditMode = ViewEditMode.Edit;

            e.View = dv;
            e.DialogController.SaveOnAccept = true;
        }


        private void SzukajPopup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var param = e.PopupWindowViewCurrentObject as PlanPracySearchParam;

            CriteriaOperator criteria = CriteriaOperator.Parse("PLAN_PRACY_ID > 0");

            if (!string.IsNullOrWhiteSpace(param.PlanKod))
            {
                criteria = new GroupOperator(GroupOperatorType.And, criteria,
                    CriteriaOperator.Parse("Contains(PLAN_PRACY_KOD, ?)", param.PlanKod));
            }

            if (!string.IsNullOrWhiteSpace(param.PlanOpis))
            {
                criteria = new GroupOperator(GroupOperatorType.And, criteria,
                    CriteriaOperator.Parse("Contains(PLAN_PRACY_OPIS, ?)", param.PlanOpis));
            }

            View.CollectionSource.Criteria["SearchCriteria"] = criteria;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            View.CollectionSource.Criteria["Base"] = CriteriaOperator.Parse("PLAN_PRACY_ID > 0");
        }
    }
}