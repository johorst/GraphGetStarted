using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace NewDataHorst
{
    public static class Function3
    {
        [FunctionName("Function3")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string text = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "text", true) == 0)
                .Value;

            if (text == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                text = data?.text;
            }


            Dictionary<string, byte> Cmap = new Dictionary<string, byte>()
            {
              { "A", byte.Parse("6") },
              { "B", byte.Parse("16") },
              { "C", byte.Parse("12") },
              { "D", byte.Parse("8") },
              { "E", byte.Parse("1") },
              { "F", byte.Parse("18") },
              { "G", byte.Parse("13") },
              { "H", byte.Parse("9") },
              { "I", byte.Parse("3") },
              { "J", byte.Parse("24") },
              { "K", byte.Parse("19") },
              { "L", byte.Parse("11") },
              { "M", byte.Parse("14") },
              { "N", byte.Parse("2") },
              { "O", byte.Parse("15") },
              { "P", byte.Parse("21") },
              { "Q", byte.Parse("27") },
              { "R", byte.Parse("5") },
              { "S", byte.Parse("4") },
              { "T", byte.Parse("7") },
              { "U", byte.Parse("10") },
              { "V", byte.Parse("22") },
              { "W", byte.Parse("17") },
              { "X", byte.Parse("26") },
              { "Y", byte.Parse("25") },
              { "Z", byte.Parse("20") },
            };

            string[] stri = text.Split(" "[0]);
            foreach(string str in stri) {
                foreach(char ch in str)
                {

                }
            }



            return text == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, "Hello " + text);
        }


    }
}
