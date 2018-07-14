using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class WorldOneMusic : MonoBehaviour
{
    private AudioManager aManager;

	void Start ()
    {
        aManager = FindObjectOfType<AudioManager>();

        //Play World One Theme Song
        PlayWorldOneThemeSong();
	}
	
	void PlayWorldOneThemeSong()
    {
        //aManager.Play("World One");
	}
}
