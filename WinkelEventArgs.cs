using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class WinkelEventArgs : EventArgs
    {
        public Bestelling Bestelling { get; set; }
    }
}
