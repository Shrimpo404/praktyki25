using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

public class DisableSearchViewController : ViewController<ListView>
{
    private readonly string[] listViewsToDisableSearch = { 
        "AutoNumSchemat_ListView", 
        "Waluta_ListView"
    };

    public DisableSearchViewController() { }

    protected override void OnActivated()
    {
        base.OnActivated();

        if (listViewsToDisableSearch.Contains(View.Id))
        {
            var filterController = Frame.GetController<FilterController>();
            if (filterController != null)
            {
                filterController.FullTextFilterAction.Active["SearchDisabled"] = false;
            }
        }
    }
}
