using StarWarsCraig.ValidationPattern;

namespace StarWarsCraig
{
    public class Solution : ISolution
    {
        private readonly BaseDronStrategyType _baseDronStrategyType;

        public Solution() : this(BaseDronStrategyType.Normal) { }

        public Solution(BaseDronStrategyType baseDronStrategyType)
        {
            _baseDronStrategyType = baseDronStrategyType;
        }

        public int GetSolution(int[] a)
        {
            IExecutable<int> executable = a.GetBaseDronOrdnancesCalculator(_baseDronStrategyType);

            return executable.UnSafeExecute();
        }
    }
}
