using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWork7
{
    internal abstract class Instrument
    {
        public string Model { get; private set; }
        public string Manufacturer { get; private set; }
        public decimal Price { get; private set; }
        public Instrument(string model, string manufacturer, decimal price)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
        }
        public override string ToString()
        {
            return $"{Manufacturer} {Model}, {Price} грн";
        }
    }
}
