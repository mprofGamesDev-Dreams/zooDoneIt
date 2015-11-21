using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	enum TIMEMODE { DAY, NIGHT };

	[Header("GUI - Background")]
	public GameObject BackgroundGUI;
	public Sprite DayBackground;
	public Sprite NightBackground;

	[Header("GUI - Text")]
	public GameObject TextGUI;

	[Header("GamePlay")]
	public float DayRoundLength = 10;
	public float NightRoundLength = 5;
	public float RoundLength;
	public GameObject Zoo;

	// Round Length
	private float CurrentTime = 0;

	// Last Switch
	private float LastRoundSwitchTime = 0;

	// Current Time Mode
	private TIMEMODE CurrentMode;

	// How many killers are in the level
	private int NumberOfKillers;

	void Start ()
	{
		// Store current time
		LastRoundSwitchTime = Time.timeSinceLevelLoad;

		// Create our initial crowd
		Zoo.GetComponent<ZooManager>().GenerateCrowd();

		// Define the day round length
		RoundLength = DayRoundLength;
	}

	void Update ()
	{
		// Elapsed time since round began
		CurrentTime = Time.timeSinceLevelLoad - LastRoundSwitchTime;

		// Check if enough time has lapsed to switch
		if( CurrentTime > RoundLength)
		{
			SwitchMode();
		}

		// Update Text
		UpdateGUI ();

		// Check if the game has met the game over requirements
		CheckGameOver ();
	}

	private void UpdateGUI()
	{
		// Display how long is left on the 
		TextGUI.GetComponent<Text> ().text = "Time Left : " + (int)(RoundLength - CurrentTime);
	}

	private void SwitchMode()
	{
		// Switch day / night
		if (CurrentMode == TIMEMODE.DAY)
		{
			// Change Mode
			CurrentMode = TIMEMODE.NIGHT;

			// Set GameBackground to NightImage
			BackgroundGUI.GetComponent<Image>().sprite = NightBackground;

			// Define the night round length
			RoundLength = NightRoundLength;
		}
		else
		{
			// Change Mode
			CurrentMode = TIMEMODE.DAY;
			
			// Set GameBackground to NightImage
			BackgroundGUI.GetComponent<Image>().sprite = DayBackground;

			// Select a new killer
			Zoo.GetComponent<ZooManager>().ChooseVictim();

			// Define the night round length
			RoundLength = DayRoundLength;
		}

		// Store current time we are on
		LastRoundSwitchTime = Time.timeSinceLevelLoad;
	}

	private void CheckGameOver()
	{
		if(CurrentMode == TIMEMODE.NIGHT)
		{
			// Check if there are more killers than innocents
		}
		else if(CurrentMode == TIMEMODE.DAY)
		{
			// No killers in crowd
		}
	}
}