using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;

public class ZooManager : MonoBehaviour
{
	[Header("Current Crowd")]

	// Just a blank gameobject to tidy up heirarchy
	public GameObject CrowdManager;
	public List<GameObject> CrowdObj;
	public IEnumerable<string> CrowdStr;

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

	// Names
	private string KillerName;
	private string VictimName;
    private ClueManager clueManager;
	void Start()
	{
		// Creat the array to store the crowd
		CrowdObj = new List<GameObject> ();
		clueManager = new ClueManager();

		int x = 0;
		int y = 0;
		int index = 0;
		
		// Generate our crowd gameobjects
		while(index < NumberInCrowd)
		{
			// Calculate the offset to the first crowd member
			Vector2 GridPosition = new Vector2 (x * SpriteSeperation, -y * SpriteSeperation);
			
			// Create the object
			GameObject CrowdMember = (GameObject)Instantiate (AnimalPrefab, FirstCrowdMemberStartPosition + GridPosition, new Quaternion ()) as GameObject;
			CrowdMember.transform.parent = CrowdManager.transform;
			CrowdObj.Add (CrowdMember);
			
			// Move to next member
			x++;
			index++;
			
			if(index == CrowdMemberPerRow)
			{
				x = 0;
				y++;
			}
		}

		GenerateCrowd ();
	}

	public void GenerateCrowd()
	{
		// Get a list of animal types
		IList<string> Animals = Enum.GetNames(typeof(Animal.ANIMAL_TYPE));

		// Shuffle them
		Animals.Shuffle ();

		// Take the first
		CrowdStr = Animals.Take (NumberInCrowd);

		// Update the objects
		for(int i = 0; i < NumberInCrowd; i++)
		{
			SetCrowdMember(i, CrowdStr.ToArray()[i]);
		}

		// Get the killer name
		KillerName = CrowdStr.ToArray () [0];
		CrowdObj [0].GetComponent<Animal> ().SetKiller ();

		// Get the victim name
		SetVictim (1);
	}

	private void SetVictim(int Index)
	{
		// Get the name of the victim
		VictimName = CrowdStr.ToArray () [Index];

		// Update the object
		CrowdObj [Index].GetComponent<Animal> ().SetVictim ();
	}

	private void SetCrowdMember(int index, string type)
	{
		// Convert to enum
		Animal.ANIMAL_TYPE animalType = (Animal.ANIMAL_TYPE) Enum.Parse(typeof(Animal.ANIMAL_TYPE), type);  

		// Set the type of the animal
		CrowdObj[index].GetComponent<Animal> ().SetAnimal (animalType);
	}

    public bool IsKillerStillWithUs()
    {
        return CrowdStr.Contains(KillerName);
    }

    public IList<string> GetClues(bool isDay)
    {
        return isDay
            ? clueManager.GetNightActivity(CrowdStr.ToList(), KillerName)
            : clueManager.GetDayActivity(CrowdStr.ToList(), KillerName);
    }
}