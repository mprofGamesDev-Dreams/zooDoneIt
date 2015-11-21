using System;
using System.Collections.Generic;
using Assets.Scripts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnityVS.ZooDoneIt.CSharpTests.Assets.Scripts
{
    [TestClass]
    public class ClueManagerTest
    {
        [TestMethod]
        public void GetNightActivityTextTest()
        {
            var manager = new ClueManager();
            var rng = Extensions.RandomGenerator = new Random(1);
            IList<string> zoo = new List<string> {"wrench", "killer", "abstract"};
            
            IList<string> text1 = manager.GetNightActivity(zoo, "killer");           

            // each is used twice
            Assert.AreEqual(2, text1.Count(x => x.Contains(zoo[0])));
            Assert.AreEqual(2, text1.Count(x => x.Contains(zoo[1])));
            Assert.AreEqual(2, text1.Count(x => x.Contains(zoo[2])));

            rng = Extensions.RandomGenerator = new Random(2);
            IList<string> text2 = manager.GetNightActivity(zoo, "killer");

            Assert.AreEqual(2, text2.Count(x => x.Contains(zoo[0])));
            Assert.AreEqual(2, text2.Count(x => x.Contains(zoo[1])));
            Assert.AreEqual(2, text2.Count(x => x.Contains(zoo[2])));

            Assert.IsFalse(text1.SequenceEqual(text2));
        }

        [TestMethod]
        public void GetNightActivitySetsVictim()
        {
            var manager = new SubClueManager();
            var rng = Extensions.RandomGenerator = new Random(1);
            IList<string> zoo = new List<string> { "wrench", "killer", "abstract" };

            IList<string> text1 = manager.GetNightActivity(zoo, "killer");
            var expectedVictim = manager.GetVictimName(zoo, "killer");

            Assert.AreEqual(expectedVictim, manager.Victim);
        }

        [TestMethod]
        public void GetVictimTest()
        {
            var manager = new SubClueManager();
            var rng = Extensions.RandomGenerator = new Random(1);
            IList<string> zoo = new List<string> { "wrench", "killer", "abstract" };

            Assert.AreEqual("killer", manager.GetVictimName(zoo, "wrench"));
            Assert.AreEqual("abstract", manager.GetVictimName(zoo, "killer"));
            Assert.AreEqual("wrench", manager.GetVictimName(zoo, "abstract"));
        }

        [TestMethod]
        public void GetDayActivityTest()
        {
            var manager = new SubClueManager();
            var rng = Extensions.RandomGenerator = new Random(1);
            IList<string> zoo = new List<string> { "wrench", "killer", "abstract" };

            var clues1 = manager.GetDayActivity(zoo, "killer");

            Assert.AreEqual(2, clues1.Count(x => x.Contains(zoo[0])));
            Assert.AreEqual(2, clues1.Count(x => x.Contains(zoo[1])));
            Assert.AreEqual(2, clues1.Count(x => x.Contains(zoo[2])));

            rng = Extensions.RandomGenerator = new Random(2);
            var clues2 = manager.GetDayActivity(zoo, "killer");

            Assert.AreEqual(2, clues2.Count(x => x.Contains(zoo[0])));
            Assert.AreEqual(2, clues2.Count(x => x.Contains(zoo[1])));
            Assert.AreEqual(2, clues2.Count(x => x.Contains(zoo[2])));

            Assert.IsFalse(clues1.SequenceEqual(clues2));
        }

        [TestMethod]
        public void KillerNotInZooGetsEmptyList()
        {
            var manager = new SubClueManager();
            var rng = Extensions.RandomGenerator = new Random(1);
            IList<string> zoo = new List<string> { "wrench", "killer", "abstract" };

            var clues = manager.GetDayActivity(zoo, "albacore");
            Assert.AreEqual(0, clues.Count);
        }

        public class SubClueManager : ClueManager
        {
            public string GetVictimName(IList<string> zoo, string killer)
            {
                return GetVictim(zoo, killer);
            }
        }
    }
}
