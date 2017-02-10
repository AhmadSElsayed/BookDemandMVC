using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BookDemandMVC.Utilities
{
    public class Utility
    {
        public static async Task<T> GetApi<T>(string Link)
        {
            Link = ConfigurationManager.ConnectionStrings["WebService"].ConnectionString + Link;
            var client = new HttpClient();
            var json = await client.GetStringAsync(Link);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}