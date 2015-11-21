using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ZooManager : MonoBehaviour
{
	[Header("Current Crowd")]

	// Just a blank gameobject to tidy up heirarchy
	public GameObject CrowdManager;
	public List<GameObject> Crowd;

	[Header("GamePlay")]

	// How many people can we have in a crowd
	[Range(3,10)]
	public int NumberInCrowd = 5;

	// How many killers can we have in a crowd
	public int MaxNumberOfKillers = 3;

	[Header("GUI Controls")]
	public GameObject AnimalPrefab;
	public Vector2 FirstCrowdMemberStartPosition;
	public int CrowdMemberPerRow = 5;
	public int NumberOfRows = 5;
	public int SpriteSeperation = 512;

	// Counter for maximum number of killers
	private int NumberOfKillers = 0;


	public void GenerateCrowd()
	{
		int x = 0;
		int y = 0;
		int index = 0;
		
		// Generate our crowd
		while(index < NumberInCrowd)
		{
			AddCrowdMember(x,y);

			x++;
			index++;
			
			if(index == CrowdMemberPerRow)
			{
				x = 0;
				y++;
			}
		}

		// Pick the killer
		ChooseKiller ();

		// Pick the victim
		ChooseVictim ();

		// THIS IS WHERE WE SHOULD GENERATE MEMBER TRAITS
	}

	public void ChooseKiller()
	{
		// Check if we have too many killers
		if (NumberOfKillers >= MaxNumberOfKillers)
			return;


		int Index;
		while (true)
		{
			// Pick one at random
			Index = UnityEngine.Random.Range (0, NumberInCrowd);
			
			// Check if the selected one is a killer already
			if(!Crowd[Index].GetComponent<Animal>().GetKiller())
			{
				// Flag it is the killer
				Crowd [Index].GetComponent<Animal>().SetKiller ();

				// Increase our counter
				NumberOfKillers++;
				break;
			}
		}
	}

	public void ChooseVictim()
	{
		int Index;
		while (true)
		{
			// Pick one at random
			Index = UnityEngine.Random.Range (0, NumberInCrowd);

			// Check if the selected one is a killer i.e. cant be victim
			if(!Crowd[Index].GetComponent<Animal>().GetKiller())
			{
				// Flag the crowd member is a victim
				Crowd[Index].GetComponent<Animal>().SetVictim();				
				break;
			}
		}
	}

	private void AddCrowdMember(int x, int y)
	{
		// Make sure we have a crowd array to add to
		if(Crowd == null)
		{
			// Creat the array to store the crowd
			Crowd = new List<GameObject> ();
		}

		// Generate a random type of animal
		int RandomType = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Animal.ANIMAL_TYPE)).Length);

		// Calculate the offset to the first crowd member
		Vector2 GridPosition = new Vector2 (x* SpriteSeperation, -y * SpriteSeperation);

		// Create the object
		GameObject CrowdMember = (GameObject)Instantiate (AnimalPrefab, FirstCrowdMemberStartPosition + GridPosition, new Quaternion ()) as GameObject;
		CrowdMember.GetComponent<Animal> ().SetAnimal ((Animal.ANIMAL_TYPE)RandomType);
		CrowdMember.transform.parent = CrowdManager.transform;

		// Add to the list
		Crowd.Add (CrowdMember);
	}
}
