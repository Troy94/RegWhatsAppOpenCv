using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using InputManager;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using RegWhatsAppOpenCv;
using RegWhatsAppOpenCv.SmsService;

namespace RegWhat_sUp.Screens
{
    public class BaseScreen
    {
        public string _name;
        public List<string> AllowFeatures;
        public List<string> BlockedFeatures;
        public static string PathToScreenshot = Environment.CurrentDirectory + "\\screenshot.png";

      
        public struct MatchCoordinates
        {
            public int X { get; set; }
            public int Y { get; set; }
            public bool IsFound { get; set; }
        }


        public BaseScreen(string name)
        {
            AllowFeatures = new List<string>();
            BlockedFeatures = new List<string>();
            _name = name;
        }
        public void AddAllowFeatures(string feature)
        {
            AllowFeatures.Add(feature);
        }
        public void AddBlockFeatures(string feature)
        {
            BlockedFeatures.Add(feature);
        }
        private MatchCoordinates CheckFeature(string feature)
        {
            double threshold = 0.8;  // Значение можно настроить в зависимости от требований
            MatchCoordinates matchCoordinates = new MatchCoordinates();
            try
            {               
                Mat screenShot = Cv2.ImRead(PathToScreenshot);
                Mat imageFeature = Cv2.ImRead(feature);             
                Cv2.CvtColor(imageFeature, imageFeature, ColorConversionCodes.BGR2RGB);

                if (screenShot.Empty())
                {
                    Console.WriteLine("Ошибка при загрузке скриншота.");     
                    return matchCoordinates;
                }

                if (imageFeature.Empty())
                {
                    return matchCoordinates;
                }

                // Приводим template к формату изображения
                //Cv2.CvtColor(imageFeature, imageFeature, ColorConversionCodes.BGR2RGB);

                // Ищем шаблон на изображении
                Mat result = new Mat();
                Cv2.MatchTemplate(screenShot, imageFeature, result, TemplateMatchModes.CCoeffNormed);

                // Находим максимальное значение в матрице результатов
                Cv2.MinMaxLoc(result, out _, out _, out _, out OpenCvSharp.Point maxLoc);

                if (result.At<float>(maxLoc.Y, maxLoc.X) > threshold)
                {
                    Console.WriteLine("Совпадение найдено!");
                    matchCoordinates = new MatchCoordinates
                    {
                        X = maxLoc.X,
                        Y = maxLoc.Y,
                        IsFound = true
                    };                    
                }               
                else
                {
                    matchCoordinates = new MatchCoordinates
                    {                       
                        IsFound = false
                    };
                }

            }
            catch (Exception ex)
            {
                
            }

            return matchCoordinates;

        }

        public bool DetectScreen()
        {
            try
            {
               // Mat image = Cv2.ImRead(PathToScreenshot);
                if (AllowFeatures.Count == 0)
                {
                    //MainForm.LogBox.AppendText("Allow features = 0");
                }

                foreach (var feature in AllowFeatures)
                {
                    if (CheckFeature(feature).IsFound)
                    {                        
                        Thread.Sleep(1000);
                        return true;
                    }
                }
                foreach (var blockedFeature in BlockedFeatures)
                {
                    if (CheckFeature(blockedFeature).IsFound)
                    {
                        Thread.Sleep(1000);
                        return false;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
               // MainForm.LogBox.AppendText(ex.ToString());
            }
            return false;
        }
        public virtual bool PerformActionOnTheScreen()
        {
            return false;
        }
        protected bool pushTapByItemOrImage(string feature)
        {
            Thread.Sleep(2000);
            MouseSimulation.PushOn(CheckFeature(feature));
            return true;
        }

        protected bool insertText (string text)
        {
            Thread.Sleep(2000);
            MouseSimulation.InsertText(text);
            Thread.Sleep(2000);
            return true;
        }

        public static BaseScreen LoadScreen(Type typeScreen)
        {

            return (BaseScreen)Activator.CreateInstance(type: typeScreen);
        }


    }
}


