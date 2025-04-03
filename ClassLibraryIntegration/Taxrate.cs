using Newtonsoft.Json;
namespace ClassLibraryIntegration
{
    public class Taxrate
    {
        public static async Task<TaxRateInfo> FetchData(int zip)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://www.taxrate.io/api/v1/rate/getratebyzip?api_key=34SN0oMhTXV37LjyZHetz8hP231MKXDnI0WzrxDTnx5XKUW413hC7KjTX468T2fb&zip={zip}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            TaxRateInfo taxRateInfo = JsonConvert.DeserializeObject<TaxRateInfo>(content);
            return taxRateInfo;
        }
    }
    public class UsageData
    {
        public int UsagePct { get; set; }
        public string Usage { get; set; }
        public string Quota { get; set; }
    }

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
