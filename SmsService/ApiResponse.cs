using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.SmsService
{
    public class ApiResponse
    {
        private static ApiResponse _instance;
        public static ApiResponse Instance => _instance ?? (_instance = new ApiResponse());
        string dirJsonFileSave = Directory.GetCurrentDirectory() + "\\Phone.json";

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("number")]
            public string Number { get; set; }
       
        private ApiResponse() { }

        
        public void ProcessResponse(string jsonResponse)
        {
            //ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
            string[] response = jsonResponse.Split(":");

            if (jsonResponse != null)
            {                
                Id = response[1];
                if (response[2].Substring(0, 3) == "380")
                {
                    Number = response[2].Substring(3);
                    //response[2].Substring (0, 3);

                }
                else
                {
                    Number = response[2];
                }
                    File.AppendAllText(dirJsonFileSave, jsonResponse + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Ошибка ответа.");
            }
        }
    }
}
