using RegWhat_sUp;
using RegWhat_sUp.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.Screens.EmuScreens
{
    internal class EmuScreenWithPopUpButtonCancel : BaseScreen
    {
        public static string emuBtnCancelNowPopUp = ParserUI.PathToEmuTemplates + @"\PopUpButtonCancel.png";
        public EmuScreenWithPopUpButtonCancel()
        : base(typeof(EmuScreenWithPopUpButtonCancel).Name)
        {
            AddAllowFeatures(emuBtnCancelNowPopUp);
           
        }
        public override bool PerformActionOnTheScreen()
        {
            pushTapByItemOrImage(emuBtnCancelNowPopUp);
            return true;
        }
    }
}
