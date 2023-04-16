using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiRequest
{
    public class TakeStockData
    {
        public async Task TakeStockDataFromApi()
        {
            string url = "http://api.marketstack.com/v1/eod/2023-04-14?access_key=050ee6db389b4320ed90d015a28a4a9d&symbols=AAPL";
            HttpClient httpClient = new HttpClient();
            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                Root stockData = JsonConvert.DeserializeObject<Root>(jsonResponse);


            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
    }
}
