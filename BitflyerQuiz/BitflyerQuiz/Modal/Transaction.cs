using System;

namespace BitflyerQuiz.Modal
{
    /// <summary>
    /// Bitcoin transaction
    /// </summary>
    public class Transaction : BaseModal
    {
        public ulong Id { get; set; }
        public ulong Size { get; set; }
        public decimal Fee { get; set; }
        public decimal FeeRate { get; set; }

        public Transaction(ulong id, ulong size, decimal fee)
        {
            this.Id = id;
            this.Size = size;
            this.Fee = fee;
            this.FeeRate = (size > 0) ? fee / size : Decimal.MaxValue;
        }
    }
}
