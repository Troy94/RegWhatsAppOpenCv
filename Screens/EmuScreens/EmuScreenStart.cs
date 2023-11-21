using RegWhat_sUp;
using RegWhat_sUp.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.Screens.EmuScreens
{
    internal class EmuScreenStart : BaseScreen
    {
        private static string EmuWhatsAppIcon = ParserUI.PathToEmuTemplates + @"\emuIconWhatsApp.png";

        public EmuScreenStart()
         : base(typeof(EmuScreenStart).Name)
        {
            AddAllowFeatures(EmuWhatsAppIcon);
        }
        public override bool PerformActionOnTheScreen()
        {
            pushTapByItemOrImage(EmuWhatsAppIcon);
            return true;
        }
    }
}
