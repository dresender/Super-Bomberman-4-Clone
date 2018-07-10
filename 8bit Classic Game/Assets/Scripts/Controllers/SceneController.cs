using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    //Variables
    public SpriteRenderer flash;
    private string sceneToLoad;

    //Reload Scene
    public void reloadScene()
    {
        sceneToLoad = "World One";
    }

    //Load Game Over Scene
    public void loadGameOverScene()
    {
        //TODO
    }

    //Update
    private void Update()
    {
        if(sceneToLoad != null)
        {
            if(flash.color.a >= 1f) SceneManager.LoadScene(sceneToLoad);
            else flash.color = new Color(0f, 0f, 0f, flash.color.a + (1f * Time.deltaTime));
        }
    }
}
