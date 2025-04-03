
namespace ClassLibraryIntegration
{
    public class TaxRateInfo
    {
        public string Result { get; set; }
        public string Found { get; set; }
        public string Msg { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string TaxName { get; set; }
        public double Rate { get; set; }
        public double RatePct { get; set; }
        public string RateSign { get; set; }
        public object RateState { get; set; }
        public object RateCity { get; set; }
        public object RateCounty { get; set; }
        public object RateSpecial { get; set; }
        public UsageData UsageData { get; set; }
    }
}
