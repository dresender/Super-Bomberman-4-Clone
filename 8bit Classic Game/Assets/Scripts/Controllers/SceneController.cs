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

    //Start Method
    private void Start()
    {
        sceneToLoad = null;
    }

    //Reload Scene
    public void reloadScene()
    {
        LivesData.lives -= 1;
        sceneToLoad = "World One";
    }

    //Load Game Over Scene
    public void loadGameOverScene()
    {
        sceneToLoad = "Game Over";
    }

    //Load Main Menu
    public void loadMainMenuScene()
    {
        sceneToLoad = "Main Menu";
    }

    //Update
    private void Update()
    {
        if (LivesData.lives <= 0)
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
