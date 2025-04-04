using Newtonsoft.Json;
namespace ClassLibraryIntegration
{
    public class Taxrate
    {
        public async Task<TaxRateInfo> FetchData(int zip)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://www.taxrate.io/api/v1/rate/getratebyzip?api_key=34SN0oMhTXV37LjyZHetz8hP231MKXDnI0WzrxDTnx5XKUW413hC7KjTX468T2fb&zip={zip}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                TaxRateInfo taxRateInfo = JsonConvert.DeserializeObject<TaxRateInfo>(content);
                return taxRateInfo;
            }
        }
    }
}
