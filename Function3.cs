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
                string[] pair = text.Split("|"[0]);
                List<double> q = MakeVec(pair[0]);
                List<double> a = MakeVec(pair[1]);
            }
            //TODO: backprop initialisieren; Anzahl Neuronen == Anzahl doubles; 
            // trainieren - lernrate sinken lassen
            

            return text == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, "Hello " + text);
        }

        public static List<double> MakeVec(string myString)
        {
            Dictionary<char, byte> Cmap = new Dictionary<char, byte>()
            {
              { "A"[0], byte.Parse("6") },
              { "B"[0], byte.Parse("16") },
              { "C"[0], byte.Parse("12") },
              { "D"[0], byte.Parse("8") },
              { "E"[0], byte.Parse("1") },
              { "F"[0], byte.Parse("18") },
              { "G"[0], byte.Parse("13") },
              { "H"[0], byte.Parse("9") },
              { "I"[0], byte.Parse("3") },
              { "J"[0], byte.Parse("24") },
              { "K"[0], byte.Parse("19") },
              { "L"[0], byte.Parse("11") },
              { "M"[0], byte.Parse("14") },
              { "N"[0], byte.Parse("2") },
              { "O"[0], byte.Parse("15") },
              { "P"[0], byte.Parse("21") },
              { "Q"[0], byte.Parse("27") },
              { "R"[0], byte.Parse("5") },
              { "S"[0], byte.Parse("4") },
              { "T"[0], byte.Parse("7") },
              { "U"[0], byte.Parse("10") },
              { "V"[0], byte.Parse("22") },
              { "W"[0], byte.Parse("17") },
              { "X"[0], byte.Parse("26") },
              { "Y"[0], byte.Parse("25") },
              { "Z"[0], byte.Parse("20") },
            };


            string[] stri = myString.Split(" "[0]);
            List<double> res = new List<double>();
            foreach (string st in stri)
            {
                double d = 0.5;
                double ci = 1;
                foreach (char c in st)
                {
                    ci = ci * 0.1;
                    d += Cmap[c] * ci;
                }
                res.Add(d);
            }
            return res;
        } 


    }
}
