using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events
{
    public class Groothandelaar
    {
        private Dictionary<string, List<Bestelling>> bestellingen;
        public Groothandelaar()
        {
            bestellingen = new Dictionary<string, List<Bestelling>>();
        }
        public void OnInkomendeBestelling(object source, StockbeheerEventArgs args)
        {
            List<Bestelling> bestelling = new List<Bestelling>();
            if (!bestellingen.ContainsKey(args.Bestelling.Adres))
            {
                bestelling.Add(args.Bestelling);
                bestellingen.Add(args.Bestelling.Adres, bestelling);
            }
            else
            {
                bestelling = bestellingen[args.Bestelling.Adres];
                bestelling.Add(args.Bestelling);
                bestellingen[args.Bestelling.Adres] = bestelling;
            }
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
            return s.ToString();
        }
        public KeyValuePair<string, List<Bestelling>> GetLaatsteBestelling()
        {
            KeyValuePair<string, List<Bestelling>> laatsteBestelling = bestellingen.LastOrDefault();
            return laatsteBestelling;
        }
    }
}
