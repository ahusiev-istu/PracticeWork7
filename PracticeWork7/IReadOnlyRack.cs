using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWork7
{
    internal interface IReadOnlyRack<out T> where T : Instrument
    {
        string Name { get; }
        int Count { get; }
        decimal TotalPrice { get; }
        T this[int index] { get; }
    }
}
