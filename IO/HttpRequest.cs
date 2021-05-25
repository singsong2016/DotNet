
using System;
using RestSharp;
using Newtonsoft.Json;

namespace ConsoleCoreTest
{
    class Program
    {

        static void Main(string[] args)
        {
            var client = new RestClient("https://api.abuseipdb.com/api/v2/check");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Key", "YOUR_API_KEY");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("ipAddress", "118.25.6.39");
            request.AddParameter("maxAgeInDays", "90");
            request.AddParameter("verbose", "");

            IRestResponse response = client.Execute(request);

            dynamic parsedJson = JsonConvert.DeserializeObject(response.Content);

            Console.WriteLine(parsedJson.errors[0].detail);

            foreach (var item in parsedJson)
            {
                Console.WriteLine(item);
            }
        }

    }
}
