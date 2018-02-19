using XamDash.Models;

namespace XamDash.ViewModels
{
    public class CoinDetailViewModel : BaseViewModel
    {
        public CoinValue Coin { get; set; }
        public Coinklasse CoinK { get; set; }        
        
        public CoinDetailViewModel(CoinValue coin = null)
        {
            Coin = coin;
            
        }

        
    }
}