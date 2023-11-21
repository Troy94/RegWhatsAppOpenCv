using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.SmsService
{
    public enum SmsResponseCommand
    {
        GetNum,
        GetBalance,
        GetSmsCode,
        Default
    }

    public class SmsResponse
    {
        public new static string KeySms = "7510a7ac673dbc8148cdf6f2c6b95582";
        //public new static string UrlGetNum = "https://api.grizzlysms.com/stubs/handler_api.php?api_key=" + KeySms + "&action=getRentNumber&service=wa&country=1&rent_time=4"
        public new static string UrlGetNum = "https://api.grizzlysms.com/stubs/handler_api.php?api_key=" + KeySms + "&action=getNumber&service=wa&country=1";    

        public new static string UrlGetBalance = "https://api.grizzlysms.com/stubs/handler_api.php?api_key=" + KeySms + "&action=getBalance";
        public new static string UrlGetSmsCode = "https://api.grizzlysms.com/stubs/handler_api.php?api_key=" + KeySms + "&action=getStatus&id=" + ApiResponse.Instance.Id;
    }
}


