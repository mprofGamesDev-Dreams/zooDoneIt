using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
	enum TIMEMODE { DAY, NIGHT };

	// Current Time Mode
	private TIMEMODE CurrentMode;

	// How long the round lasts
	public float RoundLength = 10;

	// Last Switch
	private float CurrentTime = 0;

	void Start ()
	{
		// Store current time
		CurrentTime = Time.timeSinceLevelLoad;
	}
	

	void Update ()
	{
		if( Time.timeSinceLevelLoad - CurrentTime > RoundLength)
		{
			SwitchMode();
			Debug.Log("SWITCH - " + CurrentMode);
		}
	}

	private void SwitchMode()
	{
		// Switch day / night
		if (CurrentMode == TIMEMODE.DAY)
		{
			CurrentMode = TIMEMODE.NIGHT;
		}
		else
		{
			CurrentMode = TIMEMODE.DAY;
		}

		// Store current time we are on
		CurrentTime = Time.timeSinceLevelLoad;
	}
}