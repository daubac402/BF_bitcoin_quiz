namespace BitflyerQuiz.Logic
{
    /// <summary>
    /// All logic should inherit this class
    /// </summary>
    public class BaseLogic
    {
        public static ulong GetBlockSize() => 500000; // bytes

        public static decimal GetCurrentBlockReward() => 12.5M; // current: 12.5 bitcoin for a block reward
    }
}
