using System;
using System.Collections.Generic;
using System.Text;

namespace PC01.Models
{
    public class Criptomoneda
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Rank { get; set; }
        public string Price_usd { get; set; }
        public string Price_btc { get; set; }
        public string Volume_usd_24h { get; set; }
        public string Market_cap_usd { get; set; }
        public string Available_supply { get; set; }
        public string Total_supply { get; set; }
        public string Max_supply { get; set; }
        public string Percent_change_1h { get; set; }
        public string Percent_change_24h { get; set; }
        public string Percent_change_7d { get; set; }
        public string Last_updated { get; set; }

    }
}
