using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events
{
    public class Groothandelaar
    {
        public event EventHandler<StockbeheerEventArgs> BestellingVerzenden;
        private Dictionary<string, List<Bestelling>> bestellingen;
        public Groothandelaar()
        {
            bestellingen = new Dictionary<string, List<Bestelling>>();
        }
        protected virtual void OnBestellingVerzenden(Bestelling p)
        {
            BestellingVerzenden?.Invoke(this, new StockbeheerEventArgs { Bestelling = p });
        }
        public void OnInkomendeBestelling(object source, StockbeheerEventArgs args)
        {
            if (!bestellingen.ContainsKey(args.Bestelling.Adres))
            {
                bestellingen.Add(args.Bestelling.Adres, new List<Bestelling> { args.Bestelling });
            }
            else
            {
                bestellingen[args.Bestelling.Adres].Add(args.Bestelling);
            }
            OnBestellingVerzenden(bestellingen[args.Bestelling.Adres].Find(b => b.Product == args.Bestelling.Product));
        }
        public string ShowAlleBestellingen()
        {
            StringBuilder s = new StringBuilder();
            foreach (KeyValuePair<string, List<Bestelling>> r in bestellingen)
            {
                s.Append($"Bestelling: {r.Key} \n");
                foreach (Bestelling b in r.Value)
                {
                    s.Append(b.Product + "," + b.Aantal + "\n");
                }
            }
            return $"{s}------------------";
        }
        public KeyValuePair<string, List<Bestelling>> GetLaatsteBestelling()
        {
            KeyValuePair<string, List<Bestelling>> laatsteBestelling = bestellingen.LastOrDefault();
            return laatsteBestelling;
        }
    }
}
