using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain;

namespace Api.Services.Interfaces
{
    public interface ISplitService
    {
        Task<bool> CreateTransaction(Transaction transaction, List<Seller> sellers);
        Task<List<SellerTransaction>> GetTransactions();

        Task<bool> CreateSeller(Seller seller);
    }
}
