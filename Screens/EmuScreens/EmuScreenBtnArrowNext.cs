using RegWhat_sUp;
using RegWhat_sUp.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.Screens.EmuScreens
{
    internal class EmuScreenBtnArrowNext : BaseScreen
    {
        public static string emuBtnArrowNext = ParserUI.PathToEmuTemplates + @"\btnArrowNext.png";
        public EmuScreenBtnArrowNext()
        : base(typeof(EmuScreenBtnArrowNext).Name)
        {
            AddAllowFeatures(emuBtnArrowNext);

        }
        public override bool PerformActionOnTheScreen()
        {
            pushTapByItemOrImage(emuBtnArrowNext);            
            return true;
        }
    }
}
