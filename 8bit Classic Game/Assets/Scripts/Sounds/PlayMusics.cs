using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayMusics: MonoBehaviour
{
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
        StopPlayingCurrentMusic();
        PlaySceneMusic();
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

    void StopPlayingCurrentMusic()
    {
        aManager.StopPlaying(loadedScene);
    }
}
