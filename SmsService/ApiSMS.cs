using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.SmsService
{
    public class ApiSMS
    {
        public string LastResponse;
        private static ApiSMS _instanceApiSMS;       

        public static ApiSMS Instance
        {
            get
            {
                if (_instanceApiSMS == null)
                    _instanceApiSMS = new ApiSMS();
                return _instanceApiSMS;
            }
        }

        public async void SendSmsServiceRequest(SmsResponseCommand SmsResponseCommand)
        {

            string currentCommand;

                switch (SmsResponseCommand)
                {
                    case SmsResponseCommand.GetNum:
                    currentCommand = SmsResponse.UrlGetNum;

                        break;

                    case SmsResponseCommand.GetBalance:
                    currentCommand = SmsResponse.UrlGetBalance;
                        break;

                    case SmsResponseCommand.GetSmsCode:                    
                    
                        currentCommand = SmsResponse.UrlGetSmsCode;
                        break;

                    default:
                    currentCommand = SmsResponse.UrlGetBalance;
                    break;
                }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //HttpResponseMessage response = await client.GetAsync(currentCommand);
                    //LastResponse = await response.Content.ReadAsStringAsync();
                    HttpResponseMessage response = client.GetAsync(currentCommand).Result;
                    LastResponse = response.Content.ReadAsStringAsync().Result;
                    //STATUS_OK:582236
                    Thread.Sleep(2000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public bool GetPhoneNumber()
        {
            //SendSmsServiceRequest(SmsResponseCommand.GetBalance);
            SendSmsServiceRequest(SmsResponseCommand.GetNum);
            Thread.Sleep(2000);           
                     
            ApiResponse.Instance.ProcessResponse(LastResponse);
            return true;            
        }

        public string[] GetSmsCodeFromNumber()
        {
            SendSmsServiceRequest(SmsResponseCommand.GetSmsCode);
           string[] result = LastResponse.Split(":");

            return result;
        }
    }
}
