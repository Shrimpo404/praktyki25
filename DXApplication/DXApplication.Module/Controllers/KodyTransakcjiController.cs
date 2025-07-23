using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DXApplication.Module.BusinessObjects;

namespace DXApplication.Module.Controllers
{
    public class KodyTransakcjiController : ViewController<ListView>
    {
        private PopupWindowShowAction szukajPopup;
        private SimpleAction wyczyscFiltry;

        public KodyTransakcjiController()
        {
            TargetObjectType = typeof(KodyTransakcji);

            szukajPopup = new PopupWindowShowAction(this, "SzukajTransakcji", PredefinedCategory.Filters)
            {
                Caption = "Szukaj transakcji",
                ImageName = "Action_Search"
            };

            szukajPopup.CustomizePopupWindowParams += SzukajPopup_CustomizePopupWindowParams;
            szukajPopup.Execute += SzukajPopup_Execute;

            wyczyscFiltry = new SimpleAction(this, "WyczyscFiltry", PredefinedCategory.Filters)
            {
                Caption = "Wyczyść filtry",
                ImageName = "Action_Clear"
            };

            wyczyscFiltry.Execute += (s, e) =>
            {
                View.CollectionSource.Criteria.Remove("SearchCriteria");
                View.CollectionSource.Criteria.Remove("FilterKod");
                View.CollectionSource.Criteria.Remove("FilterOpis");
            };
        }

        private void SzukajPopup_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(KodyTransakcjiSearchParam));
            var param = objectSpace.CreateObject<KodyTransakcjiSearchParam>();

            var detailView = Application.CreateDetailView(objectSpace, param);
            detailView.ViewEditMode = ViewEditMode.Edit;

            e.View = detailView;
            e.DialogController.SaveOnAccept = true;
        }

        private void SzukajPopup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var param = e.PopupWindowViewCurrentObject as KodyTransakcjiSearchParam;

            CriteriaOperator criteria = CriteriaOperator.Parse("KODY_TRANSAKCJI_ID > 0");

            if (!string.IsNullOrWhiteSpace(param.Kod))
            {
                criteria = new GroupOperator(GroupOperatorType.And,
                    criteria,
                    CriteriaOperator.Parse("Contains(KOD, ?)", param.Kod));
            }

            if (!string.IsNullOrWhiteSpace(param.Opis))
            {
                criteria = new GroupOperator(GroupOperatorType.And,
                    criteria,
                    CriteriaOperator.Parse("Contains(OPIS, ?)", param.Opis));
            }

            View.CollectionSource.Criteria["SearchCriteria"] = criteria;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            View.CollectionSource.Criteria["Base"] = CriteriaOperator.Parse("KODY_TRANSAKCJI_ID > 0");
        }
    }
}
