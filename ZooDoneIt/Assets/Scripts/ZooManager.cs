using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ZooManager : MonoBehaviour
{
	public List<Animal> Crowd;

	[Range(3,10)]
	// How many people can we have in a crowd
	public int NumberInCrowd = 5;

	// How many killers can we have in a crowd
	public int MaxNumberOfKillers = 3;

	// Counter for maximum number of killers
	private int NumberOfKillers = 0;

	void Start ()
	{
		// Creat the array to store the crowd
		Crowd = new List<Animal> ();

		// Create our starting crowd
		GenerateCrowd ();
	}

	void Update()
	{
	}

	public void GenerateCrowd()
	{
		// Generate our crowd
		for(int i = 0; i < NumberInCrowd; i++)
		{
			AddCrowdMember();
		}

		// Pick the killer
		ChooseKiller ();

		OutputListToDebug ();
	}

	public void ChooseKiller()
	{
		int Index;
		while (NumberOfKillers < MaxNumberOfKillers)
		{
			// Pick one at random
			Index = UnityEngine.Random.Range (0, NumberInCrowd);
			
			// Check if the selected one is a killer already
			if(Crowd[Index].GetKiller())
			{
				return;
			}
			else
			{
				// Flag it is the killer
				Crowd [Index].SetKiller ();
				NumberOfKillers++;
				
				break;
			}
		}
	}
	
	// Just for Debugging
	private void OutputListToDebug()
	{
		int i = 1;
		foreach(Animal animal in Crowd)
		{
			if(animal.GetKiller())
			{
				Debug.Log (i + " : " + animal.GetAnimalType().ToString() + " - KILLER\n");
			}
			else
			{
				Debug.Log (i + " : " + animal.GetAnimalType().ToString() + " - INNOCENT\n");
			}
			i++;
		}
	}

	private void AddCrowdMember()
	{
		int RandomType = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Animal.ANIMAL_TYPE)).Length);
		
		Crowd.Add (new Animal((Animal.ANIMAL_TYPE)RandomType));
	}
}
