using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Base;
using DXApplication.Module.BusinessObjects;
using System.Collections.Generic;

public class WalutaFilterController : ViewController
{
    private PopupWindowShowAction filterAction;
    private SimpleAction clearAction;
    private WalutaFilter filterObject;

    public WalutaFilterController()
    {
        TargetObjectType = typeof(Waluta);
        TargetViewType = ViewType.ListView;

        filterAction = new PopupWindowShowAction(this, "FilterWaluty", PredefinedCategory.Filters)
        {
            Caption = "Warunki wyszukiwania",
            ImageName = "Action_Filter"
        };
        filterAction.CustomizePopupWindowParams += FilterAction_CustomizePopupWindowParams;
        filterAction.Execute += FilterAction_Execute;

        clearAction = new SimpleAction(this, "ClearWalutaFilter", PredefinedCategory.PopupActions)
        {
            Caption = "Wyczyść",
            PaintStyle = ActionItemPaintStyle.Caption
        };
        clearAction.Execute += ClearAction_Execute;
    }

    private void FilterAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
    {
        IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(WalutaFilter));
        filterObject = objectSpace.CreateObject<WalutaFilter>();

        e.View = Application.CreateDetailView(objectSpace, filterObject, true);
        e.View.Caption = "Warunki wyszukiwania";
        e.DialogController.SaveOnAccept = false;

        e.DialogController.AcceptAction.Caption = "Szukaj";
        e.DialogController.CancelAction.Active["HideCancelButton"] = false;

        e.DialogController.Actions.Add(clearAction);
    }

    private void FilterAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
    {
        var criteria = new List<CriteriaOperator>();

        if (filterObject != null && !string.IsNullOrWhiteSpace(filterObject.WalutaKodFilter))
        {
            criteria.Add(new FunctionOperator(
                FunctionOperatorType.Contains,
                new OperandProperty("WALUTA_KOD"),
                new OperandValue(filterObject.WalutaKodFilter)
            ));
        }

        if (filterObject != null && !string.IsNullOrWhiteSpace(filterObject.WalutaOpisFilter))
        {
            criteria.Add(new FunctionOperator(
                FunctionOperatorType.Contains,
                new OperandProperty("WALUTA_OPIS"),
                new OperandValue(filterObject.WalutaOpisFilter)
            ));
        }

        if (criteria.Count > 0)
        {
            ((ListView)View).CollectionSource.Criteria["WalutaFilter"] = new GroupOperator(GroupOperatorType.And, criteria);
        }
        else
        {
            ((ListView)View).CollectionSource.Criteria.Remove("WalutaFilter");
        }
    }
    private void ClearAction_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        if (this.filterObject != null)
        {
            this.filterObject.WalutaKodFilter = null;
            this.filterObject.WalutaOpisFilter = null;
        }
    }

    protected override void OnDeactivated()
    {
        if (clearAction != null)
        {
            clearAction.Execute -= ClearAction_Execute;
        }
        base.OnDeactivated();
    }
}
