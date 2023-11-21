using RegWhat_sUp;
using RegWhat_sUp.Screens;
using RegWhatsAppOpenCv.SmsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.Screens.EmuScreens
{
    internal class EmuScreenSmsCode : BaseScreen
    {
        private static string emuTextSmsCode = ParserUI.PathToEmuTemplates + @"\textSmsCode2.png";

        public EmuScreenSmsCode()
        : base(typeof(EmuScreenSmsCode).Name)
        {
            AddAllowFeatures(emuTextSmsCode);
        }
        public override bool PerformActionOnTheScreen()
        {            
            pushTapByItemOrImage(emuTextSmsCode);            
            string[] smsResponse = ApiSMS.Instance.GetSmsCodeFromNumber();
            while (smsResponse[1] == "WAIT_CODE")
            {
                Thread.Sleep(1000);
                smsResponse = ApiSMS.Instance.GetSmsCodeFromNumber();
            }
            insertText(smsResponse[1]);
            return true;
        }
    }
}
