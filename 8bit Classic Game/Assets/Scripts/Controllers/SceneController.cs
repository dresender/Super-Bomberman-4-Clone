using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //Variables
    public SpriteRenderer flash;
    public GameObject portal;

    [HideInInspector]
    public string sceneToLoad;

    private PlayMusics pMusics;

    void Awake()
    {
        pMusics = FindObjectOfType<PlayMusics>();
    }

    //Reload Scene
    public void reloadScene()
    {
        sceneToLoad = "World One";
        pMusics.loadedScene = "World One";
        pMusics.ChangeMusicAccordingToActiveScene();
    }

    //Load Game Over Scene
    public void loadGameOverScene()
    {
        sceneToLoad = "Game Over";
        pMusics.loadedScene = "Game Over";
        pMusics.ChangeMusicAccordingToActiveScene();
    }

    //Load Main Menu
    public void loadMainMenuScene()
    {
        sceneToLoad = "Main Menu";
        pMusics.loadedScene = "Main Menu";
        pMusics.ChangeMusicAccordingToActiveScene();
    }

    //Update
    private void Update()
    {
        if (LivesController.lives <= 0)
        {
            loadGameOverScene();
        }

        if(sceneToLoad != null)
        {
            if(flash.color.a >= 1f) SceneManager.LoadScene(sceneToLoad);
            else flash.color = new Color(0f, 0f, 0f, flash.color.a + (1f * Time.deltaTime));
        }
    }
}
