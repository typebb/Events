using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public class Sales
    {
        private Dictionary<string, List<Bestelling>> rapport;
        public Sales()
        {
            rapport = new Dictionary<string, List<Bestelling>>();
        }
        public void OnWinkelverkoop(object source, WinkelEventArgs args)
        {
            List<Bestelling> bestellingen = new List<Bestelling>();
            if (!rapport.ContainsKey(args.Bestelling.Adres))
            {
                bestellingen.Add(args.Bestelling);
                rapport.Add(args.Bestelling.Adres, bestellingen);
            }
            else
            {
                bestellingen = rapport[args.Bestelling.Adres];
                bestellingen.Add(args.Bestelling);
                rapport[args.Bestelling.Adres] = bestellingen;
            }
        }
        public string ShowRapport()
        {
            StringBuilder s = new StringBuilder();
            foreach (KeyValuePair<string, List<Bestelling>> r in rapport)
            {
                s.Append(r.Key + "\n");
                foreach (Bestelling b in r.Value)
                {
                    s.Append(b.Product + "," + b.Aantal + "\n");
                }
            }
            return "Sales - rapport \n" + s;
        }
    }
}
