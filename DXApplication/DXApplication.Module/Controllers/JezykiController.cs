using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DXApplication.Module.BusinessObjects;

namespace DXApplication.Module.Controllers
{

    public class JezykiController : ViewController<ListView>
    {
        private PopupWindowShowAction szukajPopup;
        private SimpleAction wyczyscFiltry;

        public JezykiController()
        {
            TargetObjectType = typeof(Jezyki);

            szukajPopup = new PopupWindowShowAction(this, "SzukajJezyka", PredefinedCategory.Filters)
            {
                Caption = "Szukaj języka",
                ImageName = "Action_Search"
            };
            szukajPopup.CustomizePopupWindowParams += SzukajPopup_CustomizePopupWindowParams;
            szukajPopup.Execute += SzukajPopup_Execute;

            wyczyscFiltry = new SimpleAction(this, "WyczyscFiltryJezyk", PredefinedCategory.Filters)
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
            var os = Application.CreateObjectSpace(typeof(JezykiSearchParam));
            var param = os.CreateObject<JezykiSearchParam>();

            var dv = Application.CreateDetailView(os, param);
            dv.ViewEditMode = ViewEditMode.Edit;

            e.View = dv;
            e.DialogController.SaveOnAccept = true;
        }

        private void SzukajPopup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var param = e.PopupWindowViewCurrentObject as JezykiSearchParam;

            CriteriaOperator criteria = CriteriaOperator.Parse("JEZYKI_ID > 0");

            if (!string.IsNullOrWhiteSpace(param.JezykKod))
            {
                criteria = new GroupOperator(GroupOperatorType.And, criteria,
                    CriteriaOperator.Parse("Contains(JEZYK_KOD, ?)", param.JezykKod));
            }

            if (!string.IsNullOrWhiteSpace(param.JezykOpis))
            {
                criteria = new GroupOperator(GroupOperatorType.And, criteria,
                    CriteriaOperator.Parse("Contains(JEZYK_OPIS, ?)", param.JezykOpis));
            }

            View.CollectionSource.Criteria["SearchCriteria"] = criteria;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            View.CollectionSource.Criteria["Base"] = CriteriaOperator.Parse("JEZYKI_ID > 0");
        }
    }
}
