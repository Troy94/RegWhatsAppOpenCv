using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegWhat_sUp.Screens
{
    public class ScreenUnknow : BaseScreen
    {
        public ScreenUnknow()
            : base(typeof(ScreenUnknow).Name)
        {

        }

        public override bool PerformActionOnTheScreen()
        {
            
            return true;
        }


    }
}
