using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Program
{
    public static async Task Main(string[] args)
    {
        var url = "https://api.cirrus.center/api/v1/random/8ball/";
        using (var client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                try
                {
                    var decodedResult = JsonConvert.DeserializeObject(result);
                    Console.WriteLine(JsonConvert.SerializeObject(decodedResult));
                }
                catch (JsonException)
                {
                    Console.WriteLine("Error: Unable to decode JSON response.");
                }
            }
            else
            {
                Console.WriteLine($"Error: Check API docs. HTTP Status Code: {response.StatusCode}");
            }
        }
    }
}