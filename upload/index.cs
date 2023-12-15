using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter your text: ");
        string text = Console.ReadLine(); // Get user input

        string url = $"https://api.cirrus.center/api/v1/tools/upload/?url={text}";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string jsonResponse = reader.ReadToEnd();
                    var decodedResult = JsonConvert.DeserializeObject(jsonResponse);
                    if (decodedResult != null)
                    {
                        Console.WriteLine(JsonConvert.SerializeObject(decodedResult));
                    }
                    else
                    {
                        Console.WriteLine("Error: Unable to decode JSON response.");
                        Console.WriteLine("HTTP Code: " + response.StatusCode);
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: Missing \"text\" parameter. Make sure all special characters and spaces are substituted for a -");
                Console.WriteLine("HTTP Code: " + response.StatusCode);
            }
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)ex.Response;
                Console.WriteLine("Error: Missing \"text\" parameter.");
                Console.WriteLine("HTTP Code: " + httpResponse.StatusCode);
            }
        }
    }
}