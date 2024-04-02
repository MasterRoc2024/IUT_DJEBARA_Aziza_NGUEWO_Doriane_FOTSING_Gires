using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExtendedSerialPort_NS;
using System.IO.Ports;
using System.Windows.Threading;
using RobotInterface;

namespace RobotInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private ExtendedSerialPort serialPort1;
        DispatcherTimer timerAffichage;

        Robot robot = new Robot();

        public MainWindow()
        {
            InitializeComponent();
            serialPort1 = new ExtendedSerialPort("COM3", 115200, Parity.None, 8, StopBits.One);
            serialPort1.DataReceived += SerialPort1_DataReceived;
            serialPort1.Open();

            timerAffichage = new DispatcherTimer();
            timerAffichage.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timerAffichage.Tick += TimerAffichage_Tick;
            timerAffichage.Start();
        }

        private void TimerAffichage_Tick(object? sender, EventArgs e)
        {
            while(robot.receivedText.Length>0) //Tant qu'il reste des octets stockés dans la queue
            {
                byte octet = robot.byteListReceived.Dequeue();
                textBoxReception.Text += octet;
            }
            //if(receivedText!="")
            //{
            //    textBoxReception.Text += receivedText;
            //    receivedText = "";
            //}
        }

        string receivedText;

        public void SerialPort1_DataReceived(object sender, DataReceivedArgs e)
        {
            for(int i=0; i< e.Data.Length; i++) //On itère sur tous les octets reçu de e.Data
            {
                byte octet = e.Data[i];
                robot.byteListReceived.Enqueue(octet); //On ajoute les octets un par un à la queue
            }
            //receivedText += Encoding.UTF8.GetString(e.Data, 0, e.Data.Length);
        }
        private void Envoyer_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();

        }
        private void SendMessage()
        {
            serialPort1.WriteLine("Bonjour");
        }

        private void ClearMessage()
        {

        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxReception.Text = "";
        }

        private void buttonTest_Click(object sender, RoutedEventArgs e)
        {
            byte[] byteList = new byte[20];
            for (int i = 0; i < 20; ++i)
            {
                byteList[i] = (byte)(2 * i);
            }
            serialPort1.Write(byteList, 0, byteList.Length);
        }
    }
}