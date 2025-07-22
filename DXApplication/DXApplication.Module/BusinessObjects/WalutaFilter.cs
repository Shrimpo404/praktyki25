using DevExpress.ExpressApp.Data;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;
using System.Runtime.CompilerServices;

[DomainComponent]
public class WalutaFilter : INotifyPropertyChanged
{
    private string walutaKodFilter;
    private string walutaOpisFilter;

    [Key]
    [Browsable(false)]
    public int Id { get; set; }
    [XafDisplayName("Waluta kod")]
    public string WalutaKodFilter
    {
        get => walutaKodFilter;
        set
        {
            if (walutaKodFilter != value)
            {
                walutaKodFilter = value;
                OnPropertyChanged();
            }
        }
    }

    [XafDisplayName("Waluta opis")]
    public string WalutaOpisFilter
    {
        get => walutaOpisFilter;
        set
        {
            if (walutaOpisFilter != value)
            {
                walutaOpisFilter = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
