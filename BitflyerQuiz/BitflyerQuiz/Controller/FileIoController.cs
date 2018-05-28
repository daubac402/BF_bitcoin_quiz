using BitflyerQuiz.Modal;
using System;
using System.Collections.Generic;
using System.IO;

namespace BitflyerQuiz.Controller
{
    /// <summary>
    /// Controller for File Input / Output
    /// </summary>
    public class FileIoController : BaseController
    {
        const int NUMBER_OF_TRANSACTION_FIELD_PER_LINE = 3;

        public string File_path { get; set; }

        public FileIoController(string file_path)
        {
            this.File_path = file_path;
        }

        /// <summary>
        /// Get the transaction list from File
        /// </summary>
        /// <returns></returns>
        public List<Transaction> LoadTransactionFromFile()
        {
            List<Transaction> transaction_list = new List<Transaction>();
            try
            {
                StreamReader file = new StreamReader(this.File_path);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    // bypass the header row
                    if (!line.StartsWith("#"))
                    {
                        Transaction transaction = this.LoadTransactionFromLine(line);
                        if (null != transaction)
                        {
                            transaction_list.Add(transaction);
                        }
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return transaction_list;
        }

        /// <summary>
        /// Return a transaction by reading a text line
        /// </summary>
        /// <param name="line">The text line contains transcation fields</param>
        /// <returns></returns>
        private Transaction LoadTransactionFromLine(string line)
        {
            string[] parts = line.Split('\t');
            if (parts.Length == FileIoController.NUMBER_OF_TRANSACTION_FIELD_PER_LINE)
            {
                try
                {
                    return new Transaction(Convert.ToUInt64(parts[0]), Convert.ToUInt64(parts[1]), Convert.ToDecimal(parts[2]));
                }
                catch (FormatException ex) { Console.WriteLine(ex.ToString()); }
                catch (OverflowException ex) { Console.WriteLine(ex.ToString()); }
            }
            return null;
        }
    }
}
