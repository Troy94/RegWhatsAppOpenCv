using RegWhat_sUp;
using RegWhat_sUp.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.Screens.EmuScreens
{
    internal class EmuScreenWithPopUpButtonOk : BaseScreen
    {
        public static string emuPopUpButtonOk = ParserUI.PathToEmuTemplates + @"\PopUpButtonOk.png";

        public EmuScreenWithPopUpButtonOk()
        : base(typeof(EmuScreenWithPopUpButtonOk).Name)
        {
            AddAllowFeatures(emuPopUpButtonOk);
            AddBlockFeatures(EmuScreenWithPopUpButtonCancel.emuBtnCancelNowPopUp);
        }

        public override bool PerformActionOnTheScreen()
        {
            pushTapByItemOrImage(emuPopUpButtonOk);
            return true;
        }
    }
}
