using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETCoinAPIv3.Models
{
    public class MyCoins
    {
          
        public string CoinName { get; set; }
        public double CoinAmount { get; set; }
        public double CoinBoughtTo { get; set; }
        public int UserId { get; set; }
    }




}