using StarWarsCraig.BaseDron;
using StarWarsCraig.BaseDronLinq;

namespace StarWarsCraig
{
    public static class BaseDronStrategySelector
    {
        public static IBaseDronOrdnancesCalculator GetBaseDronOrdnancesCalculator(
            this BaseDronEntity baseDronEntity, 
            BaseDronStrategyType? baseDronStrategy = null)
        {
            return baseDronStrategy switch
            {
                BaseDronStrategyType.Normal => new BaseDronOrdnancesCalculator(baseDronEntity),
                BaseDronStrategyType.Linq => new BaseDronOrdnancesLinqCalculator(baseDronEntity),
                _ => new BaseDronOrdnancesCalculator(baseDronEntity),
            };
        }

        public static IBaseDronOrdnancesCalculator GetBaseDronOrdnancesCalculator(
            this int[] baseDronArray, 
            BaseDronStrategyType? baseDronStrategy = null)
        {
            var baseDronEntity = new BaseDronEntity(baseDronArray);

            return baseDronEntity.GetBaseDronOrdnancesCalculator(baseDronStrategy);
        }
    }
}
