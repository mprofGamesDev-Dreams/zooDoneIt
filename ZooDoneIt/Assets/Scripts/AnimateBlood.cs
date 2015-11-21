using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimateBlood : MonoBehaviour
{
	public Image BloodImage;
	public Sprite[] BloodSprites;
	public float TimePerFrame = 0.1f;

	private int Index = 0;

	private float LastUpdate;

	// Use this for initialization
	void Start ()
	{
		// Get the starting time
		LastUpdate = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if( Time.realtimeSinceStartup - LastUpdate > TimePerFrame)
		{
			// Move to next index
			Index++;
			
			// If we have finished then destroy
			if(Index >= BloodSprites.Length)
			{
				Destroy (this.gameObject);
			}
			else
			{
				LastUpdate = Time.realtimeSinceStartup;

				BloodImage.sprite = BloodSprites[Index];
			}
		}
	}
}
