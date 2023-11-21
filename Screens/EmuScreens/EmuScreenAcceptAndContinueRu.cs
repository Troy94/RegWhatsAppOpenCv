using RegWhat_sUp;
using RegWhat_sUp.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.Screens.EmuScreens
{
    internal class EmuScreenAcceptAndContinueRu : BaseScreen
    {
        private static string EmuButtonAcceptAndContinue = ParserUI.PathToEmuTemplates + @"\buttonAcceptAndContinue.png";
        public EmuScreenAcceptAndContinueRu()
        : base(typeof(EmuScreenAcceptAndContinueRu).Name)
        {
            AddAllowFeatures(EmuButtonAcceptAndContinue);
        }
        public override bool PerformActionOnTheScreen()
        {
            pushTapByItemOrImage(EmuButtonAcceptAndContinue);
            return true;
        }
    }
}
