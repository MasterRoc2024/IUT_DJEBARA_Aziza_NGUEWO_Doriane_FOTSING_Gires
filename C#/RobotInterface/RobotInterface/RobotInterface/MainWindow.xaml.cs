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

namespace RobotInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        private ExtendedSerialPort serialPort1;
        public MainWindow()
        {
            InitializeComponent();
            serialPort1 = new ExtendedSerialPort("COM3", 115200, Parity.None, 8, StopBits.One);
            serialPort1.Open();

            callback SerialPort1_DataReceived;
            serialPort1 = new ReliableSerialPort("COM3", 115200, Parity.None, 8, StopBits.One);
            serialPort1.DataReceived += SerialPort1_DataReceived
            serialPort1.Open();
            public void SerialPort1_DataReceived(object sender, DataReceivedArgs e)
            { }

        }

        public void SerialPort1_DataReceived(object sender, DataReceivedArgs e)
        {
            textBoxReception.Text += Encoding.UTF8.GetString(e.Data, 0, e.Data.Length);
        }
        private void Envoyer_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();

        }
        private void SendMessage()
        {
            textBoxReception.Text += "Reçu:" + " " + textBoxEmission.Text + "\n";
            textBoxEmission.Text = textBoxEmission.Text;
            serialPort1.WriteLine("bonjour");

        }

        private void serialPort1_DataReceived(object? sender, DataReceivedArgs e)
        {
            throw new NotImplementedException();
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    internal class callback
    {
    }
}