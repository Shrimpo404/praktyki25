using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using System.Linq;

public class DisableExportViewController : ViewController<ListView>
{
    private readonly string[] listViewsToDisableExport = { 
        "AutoNumSchemat_ListView", 
        "Waluta_ListView"
    };

    public DisableExportViewController() { }

    protected override void OnActivated()
    {
        base.OnActivated();

        if (listViewsToDisableExport.Contains(View.Id))
        {
            var exportController = Frame.GetController<ExportController>();
            if (exportController != null)
            {
                exportController.ExportAction.Active["ExportDisabled"] = false;
            }
        }
    }
}
