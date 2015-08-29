using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Maker.Serial;
using Microsoft.Maker.RemoteWiring;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ArduinoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private RemoteDevice arduino;

        public MainPage()
        {
            this.InitializeComponent();
            UsbSerial connection =new UsbSerial("VID_2341", "PID_0043");
            arduino = new RemoteDevice(connection);
            //just start typing this and you can autocomplete using tab
            connection.ConnectionEstablished += Connection_ConnectionEstablished;
            arduino.DeviceReady += TurnOnLight;
            connection.begin(57600, SerialConfig.SERIAL_8N1);
        }

        private void Connection_ConnectionEstablished()
        {
            //just enabling the buttons
            OnButton.IsEnabled = true;
            OffButton.IsEnabled = true;
           
        }

        private void TurnOnLight()
        {
            LightsControll controll = LightsControll.GetLightControll();
            arduino.digitalWrite(controll.Pin, controll.State);
        }

        private void OnButton_Click(object sender, RoutedEventArgs e)
        {
            arduino.digitalWrite(13, PinState.HIGH);
        }

        private void OffButton_Click(object sender, RoutedEventArgs e)
        {
            arduino.digitalWrite(13, PinState.LOW);
        }
    }
}
