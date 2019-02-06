using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using Microsoft.Win32;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO.Ports;

namespace BTBS
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string[] filesToSend;
        private List<string> portNames;
        private SerialPort Port;
        
        public MainWindow()
        {
            InitializeComponent();
            FindPorts();
        }

        private void FindPorts()
        {
            portNames = new List<string>();
            string[] ports = SerialPort.GetPortNames();
            foreach(string port in ports)
            {

                portNames.Add(port);
            }
            PortsList.ItemsSource = portNames;
        }

        private void BrowseFilesButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string folderPath = dialog.FileName;
                FilePathBox.Text = folderPath;

                filesToSend = (from file in Directory.GetFiles(folderPath)
                               where System.IO.Path.GetExtension(file) == ".bmp"
                               select file).ToArray();

                foreach (var file in filesToSend)
                {
                   DisplayImage(file);
                }
            }
        }

        private void DisplayImage(string filePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(filePath);
            bitmap.EndInit();
            Image image = new Image();
            image.Source = bitmap;
            ImageStackPanel.Children.Add(image);
            ImageStackPanel.Children.Add(new Separator() { Height= 40});
        }

        private void ChangeDataBits_Checked(object sender, RoutedEventArgs e)
        {
            DataBitsBox.IsEnabled = true;
        }

        private void ChangeDataBits_Unchecked(object sender, RoutedEventArgs e)
        {
            DataBitsBox.IsEnabled = false;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputCorectness())
            {
                string[] files = new string[filesToSend.Length];
                Array.Copy(filesToSend, files, filesToSend.Length);

                //port settings
                string portName = portNames[PortsList.SelectedIndex];
                int baudRate = int.Parse(BaudRateBox.Text);
                Parity parity = (Parity) ParityBox.SelectedIndex;
                int dataBits = int.Parse(DataBitsBox.Text);
                StopBits stopBits = (StopBits)StopBitBox.SelectedIndex +1;


                try
                {
                    Port = new SerialPort(portName, baudRate, parity, dataBits, stopBits);
                    foreach (string file in files)
                    {
                        if (File.Exists(file))
                        {
                            SendFile(file);
                        }
                    }
                    Port.Dispose();
                }catch(IOException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                MessageBox.Show("Files were send succesfully!");
            }
        }

        private void SendFile(string filePath)
        {
            Port.Open();
            byte[] buffer = File.ReadAllBytes(filePath);
            Port.Write(buffer, 0, buffer.Length);
            Port.Close();
        }

        private bool CheckInputCorectness()
        {
            if( filesToSend == null || filesToSend.Length == 0)
            {
                MessageBox.Show("No bitmap files were found in selected folder");
                return false;
            }

            if (PortsList.SelectedItem == null)
            {
                MessageBox.Show("Select port!");
                return false;
            }

            if(!int.TryParse(BaudRateBox.Text,out int result))
            {
                MessageBox.Show("Baud rate must be an integer!");
                return false;
            }

            if (ParityBox.SelectedItem == null)
            {
                MessageBox.Show("Select parity bit setting!");
                return false;
            }

            if (!int.TryParse(DataBitsBox.Text, out int result2))
            {
                MessageBox.Show("Data bits setting must be an integer!");
                return false;
            }

            if (StopBitBox.SelectedItem == null)
            {
                MessageBox.Show("Select number of stop bits!");
                return false;
            }


            return true;
        }
    }
}
