using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayMusics: MonoBehaviour
{
    [HideInInspector]
    public string loadedScene;

    private AudioManager aManager;

	void Start ()
    {
        loadedScene = "Main Menu";
        aManager = FindObjectOfType<AudioManager>();

        PlaySceneMusic();
	}

    public void ChangeMusicAccordingToActiveScene()
    {
        PlaySceneMusic();
    }

    public void StopPlayingCurrentMusic()
    {
        aManager.StopPlaying(loadedScene);
    }

    private void PlaySceneMusic()
    {
        switch (loadedScene)
        {
            case "Main Menu":
                PlayMainMenuThemeSong();
                break;
            case "World One":
                PlayWorldOneThemeSong();
                break;
            case "Game Over":
                PlayGameOverThemeSong();
                    break;
        }
    }
	
	void PlayMainMenuThemeSong ()
    { 
        aManager.Play("Main Menu");
	}

    void PlayWorldOneThemeSong()
    {
        aManager.Play("World One");
    }

    void PlayGameOverThemeSong()
    {
        aManager.Play("Game Over");
    }
}
