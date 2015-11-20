using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ZooManager : MonoBehaviour
{
	private static Random _randomGenerator = new Random();  

	void Start ()
	{
		_randomGenerator = new System.Random();
	}

	public void GenerateCrowd()
	{
	}

	private void ChooseKiller()
	{
	}

	private IList<string> GetNightActivityText(string killer, IList<string> zoo)
	{
		IList<string> activities = new List<string>();		
		Shuffle<string>(zoo);
		IList<string> nightCopy = new List<string>(Resources.nightActivities);
		Shuffle<string>(nightCopy);
		
		for(int i=0; i<zoo.Count-1; i++)
		{
			
			activities.Add(String.Format(nightCopy[i]), zoo[i], zoo[i+1]);
		}
		activities.Add(String.Format(nightCopy[zoo.Count], zoo[zoo.Count-1], zoo[0]));
	}

	public static void Shuffle<T>(this IList<T> list)  
	{  
		int n = list.Count;  
		while (n > 1) 
		{  
			n--;  
			int k = _randomGenerator.Next(n + 1);  
			T value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}
}

internal static class Resources 
{
	internal static IList<string> NightActivities
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
	
}