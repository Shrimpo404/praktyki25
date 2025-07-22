using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Base;
using DXApplication.Module.BusinessObjects;
using System.Linq;

public class AutoNumSchematFilterController : ViewController
{
    private PopupWindowShowAction filterAction;
    private SimpleAction clearAction;
    private AutoNumSchematFilter filterObject;

    public AutoNumSchematFilterController()
    {
        TargetObjectType = typeof(AutoNumSchemat);
        TargetViewType = ViewType.ListView;

        filterAction = new PopupWindowShowAction(this, "FilterByTyp", PredefinedCategory.Filters)
        {
            Caption = "Warunki wyszukiwania",
            ImageName = "Action_Filter"
        };

        filterAction.CustomizePopupWindowParams += FilterAction_CustomizePopupWindowParams;
        filterAction.Execute += FilterAction_Execute;

        clearAction = new SimpleAction(this, "ClearFilterValues", PredefinedCategory.PopupActions)
        {
            Caption = "Wyczyść",
            PaintStyle = ActionItemPaintStyle.Caption
        };
        clearAction.Execute += ClearAction_Execute;
    }

    private void FilterAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
    {
        IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(AutoNumSchematFilter));
        filterObject = objectSpace.CreateObject<AutoNumSchematFilter>();

        using (IObjectSpace dataObjectSpace = Application.CreateObjectSpace(typeof(AutoNumSchemat)))
        {
            var uniqueTypValues = dataObjectSpace.GetObjects<AutoNumSchemat>()
                .Select(s => s.TYP).Distinct().OrderBy(t => t);
            foreach (var typ in uniqueTypValues)
            {
                var typItem = objectSpace.CreateObject<TypItem>();
                typItem.Id = typ;
                typItem.TypValue = typ;
                filterObject.TypValues.Add(typItem);
            }
        }

        e.View = Application.CreateDetailView(objectSpace, filterObject, true);
        e.DialogController.SaveOnAccept = false;

        e.DialogController.AcceptAction.Caption = "Szukaj";
        e.DialogController.CancelAction.Active["HideCancelButton"] = false;

        e.DialogController.Actions.Add(clearAction);
    }

    private void ClearAction_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        if (this.filterObject != null)
        {
            this.filterObject.SelectedTyp = null;
            this.filterObject.KodFilter = null;
            this.filterObject.SchematOpisFilter = null;
        }
    }

    private void FilterAction_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
    {
        var criteria = new List<CriteriaOperator>();

        if (filterObject != null && filterObject.SelectedTyp != null)
        {
            criteria.Add(new BinaryOperator("TYP", filterObject.SelectedTyp.TypValue));
        }

        if (filterObject != null && !string.IsNullOrWhiteSpace(filterObject.KodFilter))
        {
            criteria.Add(new BinaryOperator("SCHEMAT_KOD", $"%{filterObject.KodFilter}%", BinaryOperatorType.Like));
        }

        if (filterObject != null && !string.IsNullOrWhiteSpace(filterObject.SchematOpisFilter))
        {
            criteria.Add(new BinaryOperator("SCHEMAT_OPIS", $"%{filterObject.SchematOpisFilter}%", BinaryOperatorType.Like));
        }

        if (criteria.Count > 0)
        {
            ((ListView)View).CollectionSource.Criteria["Filter1"] = new GroupOperator(GroupOperatorType.And, criteria);
        }
        else
        {
            ((ListView)View).CollectionSource.Criteria.Remove("Filter1");
        }
    }
    protected override void OnDeactivated()
    {
        clearAction.Execute -= ClearAction_Execute;
        base.OnDeactivated();
    }
}
