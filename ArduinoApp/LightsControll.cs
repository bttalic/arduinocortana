using Microsoft.Maker.RemoteWiring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoApp
{
    class LightsControll
    {

        private static LightsControll controll;

        public static LightsControll SetLightControll(string bulb, string action)
        {
            controll = new LightsControll(bulb, action);

            return controll;
        }

        public static LightsControll GetLightControll()
        {
            if (controll == null)
            {
                controll = new LightsControll();
            }

            return controll;
        }

        private LightsControll()
        { }

        private LightsControll(string bulb, string action)
        {
            SetValues(bulb, action);
        }

        public byte Pin { get; set; }

        public PinState State { get; private set; }


        private void SetValues(string bulb, string action)
        {
            switch (bulb.ToLower())
            {
                case "red":
                    Pin = 13;
                    break;
                case "green":
                    Pin = 12;
                    break;
                case "blue":
                    Pin = 11;
                    break;
            }

            switch (action.ToLower())
            {
                case "on":
                    State = PinState.HIGH;
                    break;
                case "off":
                    State = PinState.LOW;
                    break;
            }
        }
    }
}
