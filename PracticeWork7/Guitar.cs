using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWork7
{
    internal class Guitar : Instrument
    {
        public int Strings { get; private set; }

        public Guitar(string model, string manufacturer, decimal price, int strings) : base(model, manufacturer, price)
        {
            Strings = strings;
        }

        public override string ToString()
        {
            return $"{Manufacturer} {Model}, {Price} грн, {Strings} струн";
        }
    }
}
