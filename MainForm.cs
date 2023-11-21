using OpenCvSharp;
using RegWhat_sUp;
using RegWhatsAppOpenCv.SmsService;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace RegWhatsAppOpenCv
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static Bitmap ImageBitmap;

        private void button1_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            Thread thread_ScreenDetector = new Thread(() =>
            {
                while (true)
                {
                    ParserUI.Instance.DetectScreenByOCR();
                }
            });
            thread_ScreenDetector.Start();

        }

        public void Cmd_StartWhatsApp()
        {

            string phoneNumber = "XXXXXXXXXXXXX";
            string text = "Hello";

            string command = $"start whatsapp://send?phone={phoneNumber}^&text={text}";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = false
            };

            Process.Start(startInfo);

        }

        private void button2_Click(object sender, EventArgs e)
        {           
            ApiSMS.Instance.SendSmsServiceRequest(SmsResponseCommand.GetBalance);
            Thread.Sleep(1000);
            MessageBox.Show(ApiSMS.Instance.LastResponse);          

        }
    }
}