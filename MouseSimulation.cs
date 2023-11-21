using InputManager;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using static RegWhat_sUp.Screens.BaseScreen;

namespace RegWhatsAppOpenCv
{
  
    internal class MouseSimulation
    {
        //ParserUI parserUi = ParserUI.Instance;
        private static MouseSimulation _instanceMouseSimulation;
        private static InputSimulator simulator = new InputSimulator();
        public static MouseSimulation Instance
        {
            get
            {
                if (_instanceMouseSimulation == null)
                    _instanceMouseSimulation = new MouseSimulation();
                return _instanceMouseSimulation;
            }
        }
        public static bool PushOn(MatchCoordinates coords)
        {
            Mouse.Move(coords.X + 5, coords.Y);
            Mouse.PressButton(Mouse.MouseKeys.Left);
           return true;
        }

        public static bool InsertText(string text)
        {

            //simulator.Keyboard.TextEntry(text);
            Thread.Sleep(3000);
            simulator.Keyboard.TextEntry(text);

            return true;
        }

    }
}
