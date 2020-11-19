using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Stockbeheer
    {
        public event EventHandler<StockbeheerEventArgs> Minimumstock;
        private Dictionary<ProductType, Bestelling> stock;
        public Stockbeheer()
        {
            stock = new Dictionary<ProductType, Bestelling>();
            foreach (ProductType p in Enum.GetValues(typeof(ProductType)))
                stock.Add(p, new Bestelling(p, 0, 100, ""));
        }
        public void OnWinkelverkoop(object source, WinkelEventArgs args)
        {
            stock[args.Bestelling.Product].Aantal -= args.Bestelling.Aantal;
            stock[args.Bestelling.Product].Adres = args.Bestelling.Adres;
            StockBestellen(args.Bestelling);
        }
        public void OnBestellingToegekomen(object source, StockbeheerEventArgs args)
        {
            stock[args.Bestelling.Product].Aantal += args.Bestelling.Aantal;
        }
        protected virtual void OnMinimumstock(Bestelling p)
        {
            Minimumstock?.Invoke(this, new StockbeheerEventArgs { Bestelling = p});
        }
        public void StockBestellen(Bestelling b)
        {
            if (stock[b.Product].Aantal <= 30)
            {
                b.Adres = stock[b.Product].Adres;
                b.Aantal = 100 - stock[b.Product].Aantal;
                OnMinimumstock(b);
            }
        }
        public string ShowRapport()
        {
            StringBuilder s = new StringBuilder();
            foreach (Bestelling r in stock.Values)
            {
                s.Append($"Stock:{r.Product}, {r.Aantal}\n");
            }
            return $"{s}------------------";
        }
        public void StockAanvullen(Bestelling b)
        {
            stock[b.Product].Aantal += b.Aantal;
        }
    }
}
