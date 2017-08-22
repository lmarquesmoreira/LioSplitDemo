using Api.Domain;
using Api.Repository.Interfaces;
using Api.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public class SplitService: ISplitService
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<SellerTransaction> _sellerTransactionRepository;
        private readonly IRepository<Seller> _sellerRepository;

        public SplitService(IRepository<Transaction> transactionRepository, IRepository<SellerTransaction> sellerTransactionRepository, IRepository<Seller> sellerRepository)
        {
            _transactionRepository = transactionRepository;
            _sellerTransactionRepository = sellerTransactionRepository;
            _sellerRepository = sellerRepository;
        }

        public async Task<bool> CreateTransaction(Transaction transaction, List<Seller> sellers)
        {
            try
            {
                foreach (var seller in sellers)
                {
                    var sel = await ( _sellerRepository.GetAsync(s => s.Id == seller.Id));
                    var mdr = sel.Mdr;
                    var order = JsonConvert.SerializeObject(transaction.Order);

                    var seller_amount = Convert.ToInt64(transaction.Amount) * mdr / 100;
                    await _sellerTransactionRepository.SaveAsync(new SellerTransaction
                    {
                        Amount = seller_amount.ToString(),
                        SellerId = seller.Id,
                        Order = order,
                        CreatedOn = DateTime.Now.ToShortDateString()
                    });

                }

                await _transactionRepository.SaveAsync(transaction);
                return true;
            }
            catch (Exception)
            {
                // exception occurs
            }
            return false;
        }

        public async Task<List<SellerTransaction>> GetTransactions()
        {
            return await _sellerTransactionRepository.GetAsync();
        }
    }
}
