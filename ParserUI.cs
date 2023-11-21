using RegWhat_sUp.Screens;
using RegWhatsAppOpenCv;
using RegWhatsAppOpenCv.Screens;
using RegWhatsAppOpenCv.Screens.EmuScreens;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegWhat_sUp
{
    public class ParserUI
    {
        #region Variables

        private static ParserUI _instanceParserUi;
        public List<BaseScreen> _listScreens;
        private int _attemptUnknownScreen = 0;
        public static Bitmap ImageBitmap;
        public static string PathToTemplates = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Screens\ScreensImageTemplates";
        public static string PathToEmuTemplates = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Screens\ScreensImageTemplates\emu";
        public static string PathToScreenshot = Environment.CurrentDirectory + @"\screenshot.png";
     
        #endregion

        private ParserUI()
        {
            InitScreens();
        }

        public static ParserUI Instance
        {
            get
            {
                if (_instanceParserUi == null)
                    _instanceParserUi = new ParserUI();
                return _instanceParserUi;
            }
        }

        public void InitScreens()
        {
            _listScreens = new List<BaseScreen>
            {               
                BaseScreen.LoadScreen(typeof(EmuScreenStart)),
                BaseScreen.LoadScreen(typeof(EmuScreenAcceptAndContinueRu)),
                BaseScreen.LoadScreen(typeof(EmuScreenInsertPhoneNumber)),
                BaseScreen.LoadScreen(typeof(EmuScreenSmsCode)),
                BaseScreen.LoadScreen(typeof(EmuScreenWithPopUpButtonNotNow)),
                BaseScreen.LoadScreen(typeof(EmuScreenWithPopUpButtonCancel)),
                BaseScreen.LoadScreen(typeof(EmuScreenTextnInputName)),                
                BaseScreen.LoadScreen(typeof(EmuScreenBtnArrowNext)),                
                BaseScreen.LoadScreen(typeof(EmuScreenFinish)),
                BaseScreen.LoadScreen(typeof(EmuScreenWithPopUpButtonOk))
        };
        }
        private void makeScreen()
        {
            if (ImageBitmap != null)
            {
                ImageBitmap = null;
            }
            ImageBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            var gfx = Graphics.FromImage(ImageBitmap);
            gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, ImageBitmap.Size);
            ImageBitmap.Save("screenshot.png");
            //ImagePix = Image.FromFile(Directory.GetCurrentDirectory + "\\screenshot.png");
        }
        public Bitmap ConvertToBlackAndWhite(Bitmap originalImage)
        {
            Bitmap blackAndWhiteImage = new Bitmap(originalImage.Width, originalImage.Height);
            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalColor = originalImage.GetPixel(x, y);
                    int grayScale = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    blackAndWhiteImage.SetPixel(x, y, newColor);
                }
            }

            return blackAndWhiteImage;
        }
        public static Bitmap IncreaseContrast(Bitmap originalImage)
        {
            Bitmap contrastImage = new Bitmap(originalImage.Width, originalImage.Height);

            int contrastValue = 30; // Значение контрастности (может быть изменено)

            BitmapData originalData = originalImage.LockBits(new Rectangle(0, 0, originalImage.Width, originalImage.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData contrastData = contrastImage.LockBits(new Rectangle(0, 0, contrastImage.Width, contrastImage.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                byte* originalPointer = (byte*)originalData.Scan0;
                byte* contrastPointer = (byte*)contrastData.Scan0;

                int stride = originalData.Stride - 4 * originalImage.Width;

                for (int y = 0; y < originalImage.Height; y++)
                {
                    for (int x = 0; x < originalImage.Width; x++)
                    {
                        byte blue = originalPointer[0];
                        byte green = originalPointer[1];
                        byte red = originalPointer[2];
                        byte alpha = originalPointer[3];

                        // Расчет нового значения цвета с учетом контрастности
                        int newValue = (contrastValue * (blue - 128) + 128);
                        blue = (byte)Math.Max(0, Math.Min(255, newValue));

                        newValue = (contrastValue * (green - 128) + 128);
                        green = (byte)Math.Max(0, Math.Min(255, newValue));

                        newValue = (contrastValue * (red - 128) + 128);
                        red = (byte)Math.Max(0, Math.Min(255, newValue));

                        contrastPointer[0] = blue;
                        contrastPointer[1] = green;
                        contrastPointer[2] = red;
                        contrastPointer[3] = alpha;

                        originalPointer += 4;
                        contrastPointer += 4;
                    }

                    originalPointer += stride;
                    contrastPointer += stride;
                }
            }

            originalImage.UnlockBits(originalData);
            contrastImage.UnlockBits(contrastData);

            return contrastImage;
        }
        public BaseScreen DetectScreenByOCR()
        {
            Thread.Sleep(4000);
            makeScreen();            
            foreach (var screen in _listScreens)
            {
                var result = screen.DetectScreen();
                if (result)
                {
                    _attemptUnknownScreen = 0;                    
                    //MessageBox.Show(screen._name);
                    MainForm.LogBox.BeginInvoke(
                     (MethodInvoker)(() => MainForm.LogBox.AppendText(
                     $"Detect screen: {screen._name}" +
                     Environment.NewLine)));                   
                    screen.PerformActionOnTheScreen();
                    return screen;
                }
            }
            _attemptUnknownScreen++;

            MainForm.LogBox.BeginInvoke(
                    (MethodInvoker)(() => MainForm.LogBox.AppendText(
                    $"Detect screen: Unknown, try: {_attemptUnknownScreen}"
                    + Environment.NewLine)));         

            Thread.Sleep(1000);
            return new ScreenUnknow();
        }
    }
}
