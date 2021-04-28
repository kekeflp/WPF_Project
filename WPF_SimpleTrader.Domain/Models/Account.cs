using System.Collections.Generic;

namespace WPF_SimpleTrader.Domain.Models
{
    public class Account
    {
        //+ Id: int
        //+ AccountHolder : User
        //+ Balance: double
        //+ AssetTransactions: IEnumerable<AssetTransaction>
        //+ Assets: IEnumerable<Asset>

        public int Id { get; set; }
        public User AccountHolder { get; set; }
        public double Balance { get; set; }
        public IEnumerable<AssetTransaction> AssetTransactions { get; set; }
        public IEnumerable<Asset> Assets { get; set; }
    }
}
