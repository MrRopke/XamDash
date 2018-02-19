using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASPNETCoinAPIv3.Models;

namespace ASPNETCoinAPIv3.Controllers
{
    public class CoinsController : ApiController
    {
        UserCoins[] coins = new UserCoins[]
        {
            new UserCoins { UserId = 1, CoinName = "EOS",},
            new UserCoins { UserId = 1, CoinName = "BTC",},
            new UserCoins { UserId = 1, CoinName = "TRX",},
            new UserCoins { UserId = 2, CoinName = "EOS",},
            new UserCoins { UserId = 2, CoinName = "BTC",},
            new UserCoins { UserId = 2, CoinName = "TRX",},
            new UserCoins { UserId = 3, CoinName = "EOS",},
            new UserCoins { UserId = 3, CoinName = "BTC",},
            new UserCoins { UserId = 3, CoinName = "TRX"},
        };


        UserCoins[] coins2 = new UserCoins[]
        {

        };






        public IEnumerable<UserCoins> GetAllCoins()
        {
            return coins;
        }



        public IHttpActionResult GetCoin(int id)
        {
            string[] sa = new string[5] { "Test1", "Test2", "Test3", "Test4", "Test5" };
            //var user3 = coinwallet;
            //var user4 = coins.FirstOrDefault((p) => p.UserId == id);

            foreach (var item in coins)
            {
                if (item.UserId == id)
                {
                           
                }
            }

            //return Ok(GetByUserId(id));
            //var user2 = coins.FirstOrDefault((p) => p.UserId == id);

            ////var user = coins.FirstOrDefault((p) => p.CoinId == id);
            //if (user2 == null)
            //{
            //    return NotFound();
            //}
             
            return Ok();

        }



    }
}
