using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace FFXIV_API
{
    class Program
    {
        static void Main(string[] args)
        {

            //Replace this with your actual API key
            //If you have API Key just comment this out and add it to the 'apikey'
            string ApiKeyRead = System.IO.File.ReadAllText(@"C:\Users\karin\OneDrive\Desktop\APIKeys\Api_Key_FFXIV.txt");
            string apiKey = ApiKeyRead;
           
            // Prompt the user to enter an item name to search for
            Console.Write("Enter an item name to search for: ");
            string itemName = Console.ReadLine();

            // Construct the API URL with the search query and API key
            string url = $"https://xivapi.com/search?string={itemName}&key={apiKey}";

            // Create a new WebClient instance
            WebClient client = new WebClient();
            // Download the API data as a string
            string data = client.DownloadString(url);
            dynamic Item = JsonConvert.DeserializeObject(data);
            string Name_Object = "";
            int count = Enumerable.Count<dynamic>(Item.Results);
            for (int x = 0; x < count; x++)
            {
                Name_Object = Item.Results[x].Name;
                Console.WriteLine(Name_Object);
            }

            // Print the API data to the console
            //Console.WriteLine(Name_Object);
            Console.ReadKey();

        }
    }
}
