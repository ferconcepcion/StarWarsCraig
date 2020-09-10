using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsCraig.ValidationPattern;

namespace StarWarsCraig.Testing
{
    [TestClass]
    public abstract class StarWarsCraigBaseTest
    {
        protected ISolution _solution;

        protected virtual void ResolveDependencies()
        {
            _solution = new Solution();
        }


        [TestInitialize]
        public void Initialize()
        {
            ResolveDependencies();
        }

        [TestMethod]
        public void TestExample1()
        {
            // Arrange
            var array = new int[] { 1, 6, 4, 5, 4, 5, 1, 2, 3, 4, 7, 2 };
            var expectedResult = 3;

            // Action
            var result = _solution.GetSolution(array);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestExample2()
        {
            // Arrange
            var array = new int[] { 1, 5, 3, 4, 3, 4, 1, 2, 3, 4, 6, 2 };
            var expectedResult = 3;

            // Action
            var result = _solution.GetSolution(array);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidableException))]
        public void TestEmptyArray()
        {
            // Arrange
            var array = new int[] {};

            // Action
            _solution.GetSolution(array);
        }

        [TestMethod]
        public void TestLateralInvalidTopsArray()
        {
            // Arrange
            var array = new int[] {5, 1, 1, 5 };
            var expectedResult = 0;

            // Action
            var result = _solution.GetSolution(array);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestNotTopsArray()
        {
            // Arrange
            var array = new int[] { 1, 1 };
            var expectedResult = 0;

            // Action
            var result = _solution.GetSolution(array);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestOnlyOneTopArray()
        {
            // Arrange
            var array = new int[] { 1, 3, 0, 2, 2, 2, 2, 2, 1 };
            var expectedResult = 1;

            // Action
            var result = _solution.GetSolution(array);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidableException))]
        public void TestInvalidArrayWithNegatives()
        {
            // Arrange
            var array = new int[] { 9, 7, -1, 0, 8 };

            // Action
            _solution.GetSolution(array);
        }

    }
}
