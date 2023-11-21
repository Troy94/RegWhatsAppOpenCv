using RegWhat_sUp;
using RegWhat_sUp.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.Screens.EmuScreens
{
    internal class EmuScreenWithPopUpButtonNotNow : BaseScreen
    {
        private static string emuBtnNotNowPopUp = ParserUI.PathToEmuTemplates + @"\PopUpButtonNotNow.png";
        public EmuScreenWithPopUpButtonNotNow()
        : base(typeof(EmuScreenWithPopUpButtonNotNow).Name)
        {
            AddAllowFeatures(emuBtnNotNowPopUp);
            AddBlockFeatures(EmuScreenWithPopUpButtonOk.emuPopUpButtonOk);
        }
        public override bool PerformActionOnTheScreen()
        {
            pushTapByItemOrImage(emuBtnNotNowPopUp);
            return true;
        }
    }
}
