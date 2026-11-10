using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeWork7
{
    internal class KeyboardRack(string name) : Rack<Keyboard>(name)
    {
        public int FullSizeCount
        {
            get
            {
                int count = 0;

                for (int i = 0; i < Count; i++)
                {
                    if (this[i].Keys == 88)
                        count++;
                }

                return count;
            }
        }
    }
}
