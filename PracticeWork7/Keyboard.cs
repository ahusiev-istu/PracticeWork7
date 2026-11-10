using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWork7
{
    internal class Keyboard : Instrument
    {
        public int Keys { get; private set; }

        public Keyboard(string model, string manufacturer, decimal price, int keys) : base(model, manufacturer, price)
        {
            Keys = keys;
        }

        public override string ToString()
        {
            return $"{Manufacturer} {Model}, {Price} грн, {Keys} клавіш";
        }
    }
}
