using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public class ClueManager
    {
        public string Victim { get; set; }
        private const double ChanceBadKillerTrait = 0.7;
        private const double ChanceBadFodderTrait = 0.2;

        /// <summary>
        /// SIDE EFFECT: Sets the Victim property if needed
        /// </summary>
        /// <param name="zoo"></param>
        /// <param name="killer"></param>
        /// <returns>the night activity text</returns>
        public IList<string> GetNightActivity(IList<string> zoo, string killer)
        {
            if (!zoo.Contains(killer))
            {
                return new List<string>();
            }

            zoo.Shuffle();
            Victim = GetVictim(zoo, killer);

            IList<string> nightCopy = new List<string>(GameResources.TwoPersonNightActivities);
            nightCopy.Shuffle();

            IList<string> activities = new List<string>();
            for (int i = 0; i < zoo.Count - 1; i++)
            {
                activities.Add(String.Format(nightCopy[i], zoo[i], zoo[i + 1]));
            }
            activities.Add(String.Format(nightCopy[zoo.Count], zoo[zoo.Count - 1], zoo[0]));
            activities.Shuffle();

            return activities;
        }

        public IList<string> GetDayActivity(IList<string> zoo, string killer)
        {
            if (!zoo.Contains(killer))
            {
                return new List<string>();
            }

            var herring = new List<string>(GameResources.Herrings);
			var goodTraits = new List<string>(GameResources.GoodTraits);
			var badTraits = new List<string>(GameResources.BadTraits);
            herring.Shuffle();
            goodTraits.Shuffle();
            badTraits.Shuffle();

            // good and bad traits
            int badIndex = 0;
            int goodIndex = 0;
            var clues = zoo.Select(x =>
                                {
                                    double chance = x == killer ? ChanceBadKillerTrait : ChanceBadFodderTrait;
                                    string trait = Extensions.RandomGenerator.Next(0, 999)/1000.0 < chance
                                        ? badTraits[badIndex++]
                                        : goodTraits[goodIndex++];
                                    return String.Format(trait, x);
                                }).ToList();

            // herrings
            int herringIndex = 0;
            clues.AddRange(zoo.Select(x => String.Format(herring[herringIndex++], x)));

            clues.Shuffle();

            return clues;
        }

        /// <summary>
        /// return the item after the killer. 
        /// if the killer is the last in the list, return the first one
        /// </summary>
        /// <param name="shuffledZoo">collection of zoo animals</param>
        /// <param name="killer">the killer</param>
        /// <returns></returns>
        protected string GetVictim(IList<string> shuffledZoo, string killer)
        {
            int index = shuffledZoo.IndexOf(killer);
            return shuffledZoo[(index + 1)%shuffledZoo.Count]; 
        } 
    }
}
