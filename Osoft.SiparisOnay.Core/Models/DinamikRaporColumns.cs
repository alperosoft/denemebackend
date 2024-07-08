namespace Osoft.SiparisOnay.Core.Models
{
    public class DinamikRaporColumns
    {
        public DinamikRaporColumns()
        {
            this.DinamikRaporRows = new HashSet<DinamikRaporRows>();
        }
        public string[] propertyColumn { get; set; } = new string[61];
        public string summary { get; set; } = "";
        public string groupSummary { get; set; } = "";

        public virtual HashSet<DinamikRaporRows> DinamikRaporRows { get; set; }
    }
}
