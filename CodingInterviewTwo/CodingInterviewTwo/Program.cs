
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleCli
{
    class Program
    {
        static void Main(string[] args)
        {
            var doWork = new DoWork();
            Console.WriteLine(doWork.HelloWorld());
            Environment.Exit(0);
        }
    }

    public class Vote
    {
        public string Name;
        public string[] Cands;

        public Vote(string name, string[] cands)
        {
            Name = name;
            Cands = cands;
        }
    }

    public class DoWork
    {
        public string HelloWorld()
        {
            return "Hello World";
        }

        class ScoreResult
        {
            int votecount;

            private int PosOne;
            private int PosTwo;
            private int PosThree;


        }

        public List<String> findWinner(List<Vote> votes)
        {
            var score = new Dictionary<string, int>();

            if (votes == null || votes.Count == 0)
                return null;

            for (int i = 0; i < votes.Count; i++)
            {
                for (int j = 0; j < votes[i].Cands.Length; j++)
                {
                    var scoreValue = 3 - j;
                    var scoreCand = votes[i].Cands[j];

                    // Add to score to hashtable
                    if (!score.ContainsKey(scoreCand))
                    {
                        score.Add(scoreCand, scoreValue);
                    }
                    else
                    {
                        score[scoreCand] += scoreValue;
                    }
                }
            }

            var sortedDict = score.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            return sortedDict.Keys.ToList();

        }

    }
}