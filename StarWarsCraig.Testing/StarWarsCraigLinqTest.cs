using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StarWarsCraig.Testing
{
    [TestClass]
    public class StarWarsCraigLinqTest : StarWarsCraigBaseTest 
    {
        protected override void ResolveDependencies()
        {
            _solution = new Solution(BaseDronStrategyType.Linq);
        }
    }
}
