using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //Variables
    public SpriteRenderer flash;
    public GameObject portal;
    private string sceneToLoad;

    //Reload Scene
    public void reloadScene()
    {
        sceneToLoad = "World One";
    }

    //Load Game Over Scene
    public void loadGameOverScene()
    {
        sceneToLoad = "Game Over";
    }

    //Load Main Meny
    public void loadMainMenuScene()
    {
        sceneToLoad = "Main Menu";
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
