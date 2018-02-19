using XamDash.Models;

namespace XamDash.ViewModels
{
    public class CRUDDetailViewModel : BaseViewModel
    {
        public Coinklasse CoinK { get; set; }        
        
        public CRUDDetailViewModel(Coinklasse coin = null)
        {
            CoinK = coin;
            
        }

        
    }
}