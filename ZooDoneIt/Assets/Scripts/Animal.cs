using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Animal : MonoBehaviour
{
	// Types of animals
	public enum ANIMAL_TYPE {
		SHEEP, WOLF, FOX, CHICKEN, ELEPHANT, CROCODILE, 
		EMU, PLATYPUS, MONKEY, TIGER, LION, COW,
		HIPPO, HORSE, FROG, LLAMA, GNAT, PIG,
		GOLDFISH, DOG, CAT, BEAR, HAWK, MOUSE,
		HYENA, DODO, PENGUIN, POLARBEAR, PANDA
	};

	[Header("GUI")]
	public GameObject ImageObj;
	public GameObject NameObj;

	[Header("Animal Information")]
	[SerializeField]private bool IsKiller;
	[SerializeField]private bool IsDead;
	[SerializeField]private ANIMAL_TYPE AnimalType;

	// Accessor for spritesheet
	private Sprite[] Sprites;

	// ID for sprites
	private const int MURDER_SPRITE_ID = 30;
	private const int DEAD_SPRITE_ID = 31;
	
	public void SetAnimal(ANIMAL_TYPE type)
	{
		// Set the type of animal
		AnimalType = type;

		// Load the sprites from resources
		Sprites = Resources.LoadAll<Sprite>("TempSpritesheet") as Sprite[];

		// Update Object
		UpdateObject ();
	}
	
	public void SetVictim()
	{
		// Flag is dead
		IsDead = true;
		
		// Update the image
		ImageObj.GetComponent<Image> ().sprite = Sprites[DEAD_SPRITE_ID];
	}

	public void SetKiller()
	{
		// Flag is the killer
		IsKiller = true;

		// Debugging purposes - REMOVE LATER
		ImageObj.GetComponent<Image> ().sprite = Sprites[MURDER_SPRITE_ID];
	}

	public void UpdateObject()
	{	
		// Update gameobject name
		this.gameObject.name = AnimalType.ToString ();

		// Update GUI Text
		NameObj.GetComponent<Text> ().text = this.gameObject.name;

		// Update GUI Image
		ImageObj.GetComponent<Image> ().sprite = Sprites[(int)AnimalType];
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