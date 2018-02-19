using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XamDash.Models
{

    public class CoinValue
    {
        public string CoinName { get; set; }
        public float BTC { get; set; }
        public float USD { get; set; }
        public double MyAmount { get; set; }
        public double AmountUSD { get; set; }
        public double AmountDKK { get; set; }
        public double CoinBoughtTo { get; set; }
        public double CoinOutcomeDKK { get; set; }

    }

    public class Coinklasse
    {
        public int Cid { get; set; }
        public string CoinName { get; set; }
        public double CoinAmount { get; set; }
        public double CoinBoughtTo { get; set; }
        public int Userid { get; set; }
    }

    public class UidClass
    {
        public int Uid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }



}



