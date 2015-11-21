﻿using UnityEngine;
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

	[Header("GUI - Misc")]
	public GameObject StatsGUI;

	[Header("GamePlay")]
	public float DayRoundLength = 10;
	public float NightRoundLength = 5;
	public float RoundLength;
	public GameObject Zoo;

	[Header("Statistics")]
	private int StatRounds = 0;
	private int StatVictims = 0;
	private int StatMurderers = 0;
	private int StatGuesses = 0;

	// Round Length
	private float CurrentTime = 0;

	// Last Switch
	private float LastRoundSwitchTime = 0;

	// Current Time Mode
	private TIMEMODE CurrentMode;

	// How many killers are in the level
	private int NumberOfKillers;

	// Accessor for the stats screen
	private GameObject StatsScreen = null;

	private bool IsGameOver = false;

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
		// Check if its gameover
		if(IsGameOver)
		{
			return;
		}

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

		// Testing
		if(Input.GetKeyDown(KeyCode.Return))
		{
			SetStats();
		}
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

			// Increase stats
			StatRounds++;
			StatVictims++;
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

	private void SetStats()
	{
		if (StatsScreen)
			return;

		IsGameOver = true;
		
		// Create the stats screen
		StatsScreen = (GameObject)Instantiate(StatsGUI);

		// Find the stats screen text
		Text StatsText = StatsScreen.transform.Find ("Canvas").Find("Text").gameObject.GetComponent<Text>();

		// Set the text
		StatsText.text = "Rounds : " + StatRounds + "\n" +
						"Victims : " + StatVictims + "\n" +
						"Murderers : " + StatMurderers + "\n" +
						"Correct Guesses : " + StatGuesses + "\n";
	}
}