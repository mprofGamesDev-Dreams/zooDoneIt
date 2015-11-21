using System.Collections.Generic;

internal static class GameResources 
{
	internal static IList<string> TwoPersonNightActivities
	{
		get 
		{
			return 	new List<string>
			{
				"{0} was out dancing with {1}",
				"{0} baked a cake with {1}",
				"{0} was sleeping with {1}'s wife",
				"{0} went to Nando's with [1}",
				"{0} went for a long walk with {1}",
				"{0} and {1} were at a Rush Hour marathon",
				"{0} and {1} had a pinterest craft party",
				"{0} and {1} played trivial pursuit",
				"{0} and {1} had an iron chef night",
				"{0} and {1} went to open mic night",
				"{0} had a pinball tournament with {1}",
				"{0} watched {1} without them realising",
				"{0} and {1} binge watched youtube cat videos together",
			};
		}
	}

    internal static IList<string> OnePersonNightActivities
    {
        get
        {
            return new List<string>
            {
                "{0} was home alone watching The Great British Bake-Off",
                "{0} was working at the soup kitchen late",
                "{0} had swimming lessons",
                "{0} went to the spa",
                "{0} went to bed early",
                "{0} went to singles club at the korean church",
                "{0} beat children at laser tag",
                "{0} went to the arcade",
                "{0} was at bingo",
                "{0} did sudoku until he fell asleep",
                "{0} went for a walk in the park",
            };
        }
    }
    internal static IList<string> GoodTraits
    {
        get
        {
            return new List<string>
            {
                "{0} runs a children's charity",
                "{0} helps out at a soup kitchen",
                "{0} helps old ladies across the road",
                "{0} is a dedicated father and husband",
                "{0} is a part-time lifeguard",
                "{0} is a vicar at the local church",
                "{0} cried during 12 years a slave",
                "{0} gave all he owns to Oxfam",
                "{0} smiles all the time",
                "{0} makes friends easily",
                "{0} is an excellent listener",
                "{0} donates stamps to charity",
                "{0} cooks for vulnerable members of the community",
                "{0} regularly attends the synagogue",
                "{0} has never missed confession",
                "{0} likes to pass out gifts at the children's hospital",
            };
        }
    }

    internal static IList<string> BadTraits
    {
        get
        {
            return new List<string>
            {
                "{0} eats babies",
                "{0} is on house arrest",
                "{0} carries out human sacrifice",
                "{0} is pure evil",
                "{0} is a member of the nazi party",
                "{0} keeps a collection of squirrel skulls",
                "{0} loves to torture other animals",
                "{0} loves to torture humans",
                "{0} is a doctor",
                "{0} has a history of child abuse",
                "{0} is recently divorced",
                "{0} is an all-time top scorer on university challenge",
                "{0} is an established pyromaniac",
                "{0} wets the bed",
                "{0} has a history of failed suicide attempts",
                "{0} has a cocaine addiction",
                "{0} is an abusive alcoholic",
                "{0} has had an isolated, lonely upbringing",
                "{0} has suffered repeated head trauma",
                "{0} hates his parents passionately",
                "{0} has trouble holding down a job",
                "{0} was abandoned by his father",
            };
        }
    }

    internal static IList<string> Herrings
    {
        get
        {
            return new List<string>
            {
                "{0} bakes a mean black pudding bread",
                "{0} knits scarves",
                "{0} is a geography teacher",
                "{0} is part of the debate society",
                "{0} is the chairman of the amateur dramatics society",
                "{0} runs a hedge fund",
                "{0} believes that the moon is just the back of the sun",
                "{0} is a five times pool champion",
                "{0} is a beauty queen",
                "{0} is a fantastic gardener",
                "{0} can never resist chocolate",
                "{0} regularly reads the torah",
                "{0} hosts yard sales",
                "{0} runs a book club",
                "{0} has a husky, distinctive singing voice with just enough vibrato",
                "{0} is an excellent crochet player",
                "{0} hides a camera in his garden gnome",
            };
        }
    }
}