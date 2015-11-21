using UnityEngine;
using System.Collections;

public class Animal
{
	public enum ANIMAL_TYPE {
		SHEEP, WOLF, FOX, CHICKEN, ELEPHANT, CROCODILE, 
		EMU, PLATYPUS, MONKEY, TIGER, LION, COW,
		HIPPO, HORSE, FROG, LLAMA, GNAT, PIG,
		GOLDFISH, DOG, CAT, BEAR, HAWK, MOUSE,
		HYENA, DODO, PENGUIN, POLARBEAR, PANDA
	};

	private bool IsKiller;
	private ANIMAL_TYPE AnimalType;

	public Animal(ANIMAL_TYPE type)
	{
		AnimalType = type;
	}

	public void SetKiller()
	{
		IsKiller = true;
	}

	public bool GetKiller()
	{
		return IsKiller;
	}

	public ANIMAL_TYPE GetAnimalType()
	{
		return AnimalType;
	}
}