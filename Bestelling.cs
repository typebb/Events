using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public enum ProductType
    {
        Tripel, Dubbel, Kriek, Pils
    }
    public class Bestelling
    {
        public ProductType Product { get; set; }
        public double Prijs { get; set; }
        public int Aantal { get; set; }
        public string Adres { get; set; }
        public Bestelling (ProductType product, double prijs, int aantal, string adres)
        {
            Product = product;
            Prijs = prijs;
            Aantal = aantal;
            Adres = adres;
        }
    }
}
