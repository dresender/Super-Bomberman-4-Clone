using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayThemeMusic: MonoBehaviour
{
    [HideInInspector]
    public string loadedScene;

    private AudioManager aManager;

	void Start ()
    {
        aManager = FindObjectOfType<AudioManager>();
        aManager.Play("Theme Music");
	}    
}
