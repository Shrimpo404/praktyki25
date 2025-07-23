using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System.ComponentModel;

namespace DXApplication.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent("SYS_DOK_ZAS")]
    [DefaultProperty("SYS_DOK_ZAS")]
    public class Wydruki : XPLiteObject
    {
        public Wydruki(Session session) : base(session) { }

        [Key(true)]
        [Persistent("SYS_DOK_ZAS_ID")]
        [Browsable(false)]
        public int WydrukID { get; set; }

        [Persistent("RAPORT_KATEGORIA")]
        public int Kategoria { get; set; }

        [Persistent("SYS_DOK_ZAS_KOD")]
        public string WydrukiKod { get; set; }

        [Persistent("SYS_DOK_KOD_OPIS")]
        public string WydrukiOpis { get; set; }

        [Persistent("RAPORT")]
        public string Raport { get; set; }

        [Persistent("WIDOCZNY")]
        public short Widoczny { get; set; }

        [Persistent("ARCHIWIZUJ")]
        public short Archiwizuj { get; set; }

        [Persistent("INSERTED_BY")]
        public string UtworzonyPrzez { get; set; }

        [Persistent("INS_DATE")]
        public DateTime DataDodania { get; set; }

        [Persistent("EDITING")]
        public string EdytowanyPrzez { get; set; }

        [Persistent("EDI_DATE")]
        public DateTime DataEdycji { get; set; }


    }
}