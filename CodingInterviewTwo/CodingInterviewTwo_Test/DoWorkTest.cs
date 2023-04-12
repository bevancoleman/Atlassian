using ConsoleCli;

namespace CodingInterviewTwo_Test
{
    [TestClass]
    public class DoWorkTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var doWork = new DoWork();

            Assert.IsTrue(doWork.HelloWorld() == "Hello World");
        }

        [TestMethod]
        public void TestVoteWinnerOne()
        {
            var doWork = new DoWork();

            var data = new List<Vote>();
            data.Add(new Vote ("VOne", new string[] {"Can1", "Can2", "Can3"} ));
            data.Add(new Vote("VTwo", new string[] { "Can2" }));
            data.Add(new Vote("VThree", new string[] { "Can1" }));

            var expectedResult = new List<string>();
            expectedResult.Add("Can1");
            expectedResult.Add("Can2");
            expectedResult.Add("Can3");


            var result = doWork.findWinner(data);

            Assert.IsTrue(result.Count == expectedResult.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.IsTrue(result[i] == expectedResult[i]);
            }
        }


        [TestMethod]
        public void TestVoteWinnerNullTest()
        {
            var doWork = new DoWork();


            var result = doWork.findWinner(null);

            Assert.IsNull(result);
        }


        [TestMethod]
        public void TestVoteWinnerSecond()
        {
            var doWork = new DoWork();

            var data = new List<Vote>();
            data.Add(new Vote("VOne", new string[] { "Can1", "Can2" }));
            data.Add(new Vote("VTwo", new string[] { "Can2", "Can1" }));
            data.Add(new Vote("VThree", new string[] { "Can3", "Can1" }));
            data.Add(new Vote("VFour", new string[] { "Can3", "Can1" }));
            data.Add(new Vote("VFive", new string[] { "Can3" }));


            var expectedResult = new List<string>();
            expectedResult.Add("Can3"); // 9  (because more first places)
            expectedResult.Add("Can1"); // 9
            expectedResult.Add("Can2"); // 5
            
            
            
            
            


            var result = doWork.findWinner(data);

            Assert.IsTrue(result.Count == expectedResult.Count);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.IsTrue(result[i] == expectedResult[i]);
            }
        }

    }
}