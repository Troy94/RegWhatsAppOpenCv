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
    public class EmuScreenInsertPhoneNumber : BaseScreen
    {
        private static string EmuInsertPhone= ParserUI.PathToEmuTemplates + @"\textEnterPhoneNumber.png";
        public static string EmuBtnGreenContinue = ParserUI.PathToEmuTemplates + @"\btnGreenContinue.png";
        
        public EmuScreenInsertPhoneNumber()
         : base(typeof(EmuScreenInsertPhoneNumber).Name)
        {
            AddAllowFeatures(EmuInsertPhone);
        }
        public override bool PerformActionOnTheScreen()
        {     
            pushTapByItemOrImage(EmuInsertPhone);
            DialogResult result = MessageBox.Show("Использовать тестовый номер без обратной СМС?", "Внимание!", MessageBoxButtons.YesNo);
            string jsonResponse = "";
            if (result == DialogResult.Yes)
            {
                jsonResponse = "ACCESS_NUMBER:55928095:976294930";
            }
            else
            {
                ApiSMS.Instance.GetPhoneNumber();
                Thread.Sleep(2000);
                jsonResponse = ApiSMS.Instance.LastResponse;
            }
                        
            ApiResponse.Instance.ProcessResponse(jsonResponse);

            insertText(ApiResponse.Instance.Number);

            Thread.Sleep(1000);
            pushTapByItemOrImage(EmuBtnGreenContinue);
            
            return true;
        }
    }
}
