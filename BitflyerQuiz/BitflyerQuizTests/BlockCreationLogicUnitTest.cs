using System.Collections.Generic;
using BitflyerQuiz.Logic;
using BitflyerQuiz.Modal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitflyerQuizTests
{
    [TestClass]
    public class BlockCreationLogicUnitTest
    {
        [TestMethod]
        public void EmptyTransaction()
        {
            ulong block_size = 500000;
            var transaction_list = new List<Transaction>();
            decimal result = BlockCreationLogic.GetMaxAvalaibleTracsactionFeePerBlock(transaction_list, block_size);
            decimal expected = 0;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ZeroFee()
        {
            ulong block_size = 1000;
            var transaction_list = new List<Transaction>();
            transaction_list.Add(new Transaction(1, 100, 0));
            transaction_list.Add(new Transaction(2, 400, 100));
            transaction_list.Add(new Transaction(3, 400, 100));
            decimal result = BlockCreationLogic.GetMaxAvalaibleTracsactionFeePerBlock(transaction_list, block_size);
            decimal expected = 200;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Simple()
        {
            ulong block_size = 1000;
            var transaction_list = new List<Transaction>();
            transaction_list.Add(new Transaction(1, 200, 2000));
            transaction_list.Add(new Transaction(2, 300, 9000));
            transaction_list.Add(new Transaction(3, 400, 16000));
            transaction_list.Add(new Transaction(4, 500, 10000));
            decimal result = BlockCreationLogic.GetMaxAvalaibleTracsactionFeePerBlock(transaction_list, block_size);
            decimal expected = 27000;
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LargeSizeTransaction()
        {
            ulong block_size = 1000;
            var transaction_list = new List<Transaction>();
            transaction_list.Add(new Transaction(1, 2000, 2000));
            transaction_list.Add(new Transaction(2, 3000, 9000));
            transaction_list.Add(new Transaction(3, 5000, 10000));
            decimal result = BlockCreationLogic.GetMaxAvalaibleTracsactionFeePerBlock(transaction_list, block_size);
            decimal expected = 0;
            Assert.AreEqual(expected, result);
        }
    }
}
