using BitflyerQuiz.Modal;
using System.Collections.Generic;

namespace BitflyerQuiz.Logic
{
    public class BlockCreationLogic : BaseLogic
    {
        /// <summary>
        /// Calculate the max avalaible transaction fee for the input transaction list, affect by the block size
        /// </summary>
        /// <param name="transactions">Transaction list to calculate the max avalaible fee</param>
        /// <param name="block_size">Current size of a block</param>
        /// <returns></returns>
        public static decimal GetMaxAvalaibleTracsactionFeePerBlock(List<Transaction> transactions, ulong block_size)
        {
            transactions.Sort((x, y) => -1 * x.FeeRate.CompareTo(y.FeeRate));

            ulong current_block_size = 0;
            decimal total_transaction_fee = 0;
            foreach (Transaction transaction in transactions)
            {
                if (current_block_size + transaction.Size > block_size)
                {
                    continue;
                }
                else
                {
                    current_block_size += transaction.Size;
                    total_transaction_fee += transaction.Fee;
                    if (current_block_size == block_size)
                    {
                        break;
                    }
                }
            }
            return total_transaction_fee;
        }
    }
}
