using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

[DomainComponent]
public class AutoNumSchematFilter : INotifyPropertyChanged
{
    private TypItem selectedTyp;
    private string kodFilter;
    private string schematOpisFilter;

    public AutoNumSchematFilter()
    {
        TypValues = new List<TypItem>();
    }

    [XafDisplayName("Schemat typ")]
    [DataSourceProperty("TypValues")]
    public TypItem SelectedTyp
    {
        get => selectedTyp;
        set
        {
            if (selectedTyp != value)
            {
                selectedTyp = value;
                OnPropertyChanged();
            }
        }
    }

    [XafDisplayName("Schemat kod")]
    public string KodFilter
    {
        get => kodFilter;
        set
        {
            if (kodFilter != value)
            {
                kodFilter = value;
                OnPropertyChanged();
            }
        }
    }

    [XafDisplayName("Schemat opis")]
    public string SchematOpisFilter
    {
        get => schematOpisFilter;
        set
        {
            if (schematOpisFilter != value)
            {
                schematOpisFilter = value;
                OnPropertyChanged();
            }
        }
    }

    [Browsable(false)]
    public List<TypItem> TypValues { get; }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
