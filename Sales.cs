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
            if (!rapport.ContainsKey(args.Bestelling.Adres))
            {
                rapport.Add(args.Bestelling.Adres, new List<Bestelling> { args.Bestelling });
            }
            else if (rapport.ContainsKey(args.Bestelling.Adres))
            {
                rapport[args.Bestelling.Adres].Add(args.Bestelling);
            }
        }
        public string ShowRapport()
        {
            StringBuilder s = new StringBuilder();
            foreach (KeyValuePair<string, List<Bestelling>> r in rapport)
            {
                Dictionary<ProductType, Bestelling> productRapport = new Dictionary<ProductType, Bestelling>();
                s.Append($"\n{r.Key} : \n");
                foreach (Bestelling b in r.Value)
                {
                    if (!productRapport.ContainsKey(b.Product))
                        productRapport.Add(b.Product, b);
                    else
                        productRapport[b.Product].Aantal += b.Aantal;
                }
                foreach (KeyValuePair<ProductType, Bestelling> b in productRapport)
                    s.Append(b.Key + "," + b.Value.Aantal + "\n");
            }
            return "Sales - rapport \n" + s + "------------------";
        }
    }
}
