using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public SpriteRenderer flash;

    private string sceneToLoad;
    private LivesController LivesControllerScript;

    public void Awake()
    {
        LivesControllerScript = GameObject.Find("LivesController").GetComponent<LivesController>();
    }

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

    //Update
    private void Update()
    {
        if (LivesControllerScript.lives <= 0)
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
