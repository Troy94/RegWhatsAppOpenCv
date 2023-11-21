using RegWhat_sUp;
using RegWhat_sUp.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhatsAppOpenCv.Screens.EmuScreens
{
    internal class EmuScreenFinish : BaseScreen
    {
        public static string emuAccountIcons = ParserUI.PathToEmuTemplates + @"\accountIcons.png";
        public EmuScreenFinish()
        : base(typeof(EmuScreenFinish).Name)
        {
            AddAllowFeatures(emuAccountIcons);

        }
        public override bool PerformActionOnTheScreen()
        {
            MessageBox.Show("FINISH");
            return true;
        }
    }
}
