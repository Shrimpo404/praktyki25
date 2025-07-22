using DevExpress.ExpressApp.DC;
using System.ComponentModel;

[DomainComponent]
[DefaultProperty("TypValue")]
public class TypItem
{
    [DevExpress.ExpressApp.Data.Key]
    [Browsable(false)]
    public short Id { get; set; }

    [XafDisplayName("Typ")]
    public short TypValue { get; set; }
}
