using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	public AudioClip AmbienceDay;
	public AudioClip AmbienceNight;

	public AudioClip AlertDay;
	public AudioClip AlertNight;

	public AudioClip Clock;

	private AudioSource GameAudio;

	private int Mode = 0;

	// Use this for initialization
	void Start ()
	{
		// Get the attached audio source
		GameAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameAudio.isPlaying)
		{
			if(Mode == 0)
			{
				PlayDayAmbience();
			}
			else if(Mode == 1)
			{
				PlayNightAmbience();
			}
		}
	}

	public void PlayDayAmbience()
	{
		Mode = 0;

		GameAudio.clip = AmbienceDay;
		GameAudio.Play ();
	}

	public void PlayNightAmbience()
	{
		Mode = 1;
		
		GameAudio.clip = AmbienceNight;
		GameAudio.Play ();
	}

	public void PlayDayAlert()
	{
		GameAudio.clip = AlertDay;
		GameAudio.Play ();
	}

	public void PlayNightAlert()
	{
		GameAudio.clip = AlertNight;
		GameAudio.Play ();
	}

	public void PlayClock()
	{
		GameAudio.clip = Clock;
		GameAudio.Play ();
	}
}
