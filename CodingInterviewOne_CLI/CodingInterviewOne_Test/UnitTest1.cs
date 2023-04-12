using CodingInterviewOne_CLI;

namespace CodingInterviewOne_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_BasicTest()
        {
            const int maxRate = 3;
            const int maxSecond = 3;

            var rateLimit = new RateLimit(maxRate);

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsFalse(rateLimit.DoProcess(1));
        }


        [TestMethod]
        public void Test_BasicTestWith1SecWait()
        {
            const int maxRate = 3;
            const int maxSecond = 3;

            var rateLimit = new RateLimit(maxRate);

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsFalse(rateLimit.DoProcess(1));

            Thread.Sleep(1000);

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsFalse(rateLimit.DoProcess(1));
        }


        [TestMethod]
        public void Test_BasicTestWithMultiCustomers()
        {
            const int maxRate = 3;
            const int maxSecond = 3;

            var rateLimit = new RateLimit(maxRate);

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsTrue(rateLimit.DoProcess(1));

            Assert.IsFalse(rateLimit.DoProcess(1));

            
            Assert.IsTrue(rateLimit.DoProcess(2));

            Assert.IsTrue(rateLimit.DoProcess(2));

            Assert.IsTrue(rateLimit.DoProcess(2));

            Assert.IsFalse(rateLimit.DoProcess(2));
        }


    }
}