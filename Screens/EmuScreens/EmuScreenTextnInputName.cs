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
    internal class EmuScreenTextnInputName : BaseScreen
    {
        public static string emuTextEnterName = ParserUI.PathToEmuTemplates + @"\textEnterName.png";
        public EmuScreenTextnInputName()
        : base(typeof(EmuScreenTextnInputName).Name)
        {
            AddAllowFeatures(emuTextEnterName);

        }
        public override bool PerformActionOnTheScreen()
        {
            pushTapByItemOrImage(emuTextEnterName);
            insertText("Jhon Jhonson");
            pushTapByItemOrImage(EmuScreenInsertPhoneNumber.EmuBtnGreenContinue);
            return true;
        }
    }
}
