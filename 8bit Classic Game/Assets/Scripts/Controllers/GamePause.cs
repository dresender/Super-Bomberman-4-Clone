using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    private bool gamePause;

	void Start ()
    {
        gamePause = false;
	}	

	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Return))
        {
            if(gamePause == false)
            {
                gamePause = true;
                Time.timeScale = 0f;
            }
            else if (gamePause == true)
            {
                gamePause = false;
                Time.timeScale = 1f;
            }            
        }
	}
}
