using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	enum TIMEMODE { DAY, NIGHT };

	[Header("GUI")]
	public GameObject BackgroundGUI;

	public Sprite DayBackground;
	public Sprite NightBackground;

	[Header("GamePlay")]
	// How long the round lasts
	public float RoundLength = 10;

	// Access to the zoo
	public GameObject Zoo;

	// Last Switch
	private float CurrentTime = 0;

	// Current Time Mode
	private TIMEMODE CurrentMode;

	private int NumberOfKillers;

	// Accessors
	private Image BackgroundImage;

	void Start ()
	{
		// Store current time
		CurrentTime = Time.timeSinceLevelLoad;

		// Access the background sprite
		BackgroundImage = BackgroundGUI.GetComponent<Image>();

		// Create our initial crowd
		Zoo.GetComponent<ZooManager>().GenerateCrowd();
	}
	

	void Update ()
	{
		// Check if enough time has lapsed to switch
		if( Time.timeSinceLevelLoad - CurrentTime > RoundLength)
		{
			SwitchMode();
		}
	}

	private void SwitchMode()
	{
		// Switch day / night
		if (CurrentMode == TIMEMODE.DAY)
		{
			// Change Mode
			CurrentMode = TIMEMODE.NIGHT;

			// Set GameBackground to NightImage
			BackgroundImage.sprite = NightBackground;
		}
		else
		{
			// Change Mode
			CurrentMode = TIMEMODE.DAY;
			
			// Set GameBackground to NightImage
			BackgroundImage.sprite = DayBackground;
		}

		// Store current time we are on
		CurrentTime = Time.timeSinceLevelLoad;
	}
}