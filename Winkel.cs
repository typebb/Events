﻿using System;

namespace Events
{
    public class Winkel
    {
        public event EventHandler<WinkelEventArgs> Winkelverkoop;

        public void VerkoopProduct (Bestelling p)
        {
            Console.WriteLine($"verkoopProduct - {p}");
            OnWinkelverkoop(p);
        }
        protected virtual void OnWinkelverkoop (Bestelling p)
        {
            Winkelverkoop?.Invoke(this, new WinkelEventArgs { Bestelling = p });
        }
    }
}
