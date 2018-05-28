using System;
using System.Collections.Generic;
using System.IO;
using BitflyerQuiz.Controller;
using BitflyerQuiz.Logic;
using BitflyerQuiz.Modal;

namespace BitflyerQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            // read input
            FileIoController file_controller = new FileIoController(
                Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @".\Resources\Input1.txt");
            List<Transaction> transaction_list = file_controller.LoadTransactionFromFile();

            // process
            decimal final_reward = BaseLogic.GetCurrentBlockReward();
            final_reward += BlockCreationLogic.GetMaxAvalaibleTracsactionFeePerBlock(transaction_list, BaseLogic.GetBlockSize());

            // output
            Console.WriteLine(final_reward);
            Console.ReadKey();
        }
    }
}
