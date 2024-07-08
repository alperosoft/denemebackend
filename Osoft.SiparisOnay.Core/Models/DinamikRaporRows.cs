namespace Osoft.SiparisOnay.Core.Models
{
    public class DinamikRaporRows
    {
        //public string[] property { get; set; } = new string[61];
        public string? property0 { get; set; } = "";
        public string property1 { get; set; } = "";
        public string property2 { get; set; } = "";
        public string property3 { get; set; } = "";
        public string property4 { get; set; } = "";
        public string property5 { get; set; } = "";
        public string property6 { get; set; } = "";
        public string property7 { get; set; } = "";
        public string property8 { get; set; } = "";
        public string property9 { get; set; } = "";
        public string property10 { get; set; } = "";
        public string property11 { get; set; } = "";
        public string property12 { get; set; } = "";
        public string property13 { get; set; } = "";
        public string property14 { get; set; } = "";
        public string property15 { get; set; } = "";
        public string property16 { get; set; } = "";
        public string property17 { get; set; } = "";
        public string property18 { get; set; } = "";
        public string property19 { get; set; } = "";
        public string property20 { get; set; } = "";
        public string property21 { get; set; } = "";
        public string property22 { get; set; } = "";
        public string property23 { get; set; } = "";
        public string property24 { get; set; } = "";
        public string property25 { get; set; } = "";
        public string property26 { get; set; } = "";
        public string property27 { get; set; } = "";
        public string property28 { get; set; } = "";
        public string property29 { get; set; } = "";
        public string property30 { get; set; } = "";
        public string property31 { get; set; } = "";
        public string property32 { get; set; } = "";
        public string property33 { get; set; } = "";
        public string property34 { get; set; } = "";
        public string property35 { get; set; } = "";
        public string property36 { get; set; } = "";
        public string property37 { get; set; } = "";
        public string property38 { get; set; } = "";
        public string property39 { get; set; } = "";
        public string property40 { get; set; } = "";
        public string property41 { get; set; } = "";
        public string property42 { get; set; } = "";
        public string property43 { get; set; } = "";
        public string property44 { get; set; } = "";
        public string property45 { get; set; } = "";
        public string property46 { get; set; } = "";
        public string property47 { get; set; } = "";
        public string property48 { get; set; } = "";
        public string property49 { get; set; } = "";
        public string property50 { get; set; } = "";
        public string property51 { get; set; } = "";
        public string property52 { get; set; } = "";
        public string property53 { get; set; } = "";
        public string property54 { get; set; } = "";
        public string property55 { get; set; } = "";
        public string property56 { get; set; } = "";
        public string property57 { get; set; } = "";
        public string property58 { get; set; } = "";
        public string property59 { get; set; } = "";
        public string property60 { get; set; } = "";
        public void SetPropertyValue(string columnName, string value)
        {
            // Özellik adının, sütun adına eşit olan bir özelliği bulun
            var property = GetType().GetProperty(columnName);

            // Eğer özellik bulunamazsa veya değer null ise işlemi sonlandır
            if (property == null || value == null)
            {
                return;
            }

            // Eğer değer boş bir dize ise, özelliği boş bir dize olarak ayarla
            if (string.IsNullOrEmpty(value))
            {
                property.SetValue(this, string.Empty);
            }
            else
            {
                // Değerin türünü, özelliğin türüne dönüştür
                var convertedValue = Convert.ChangeType(value, property.PropertyType);

                // Özelliğin değerini ayarla
                property.SetValue(this, convertedValue);
            }
        }
    }
}
