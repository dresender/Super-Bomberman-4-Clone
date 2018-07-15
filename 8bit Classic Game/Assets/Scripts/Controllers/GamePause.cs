using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    //Variables
    public GameObject player;
    private bool gamePause;

    //Start Method
	void Start ()
    {
        gamePause = true;
        Time.timeScale = 0f;
        this.enabled = false;
    }

    //Pause Method
    public void pauseOrUnpauseGame()
    {
        if (gamePause == false)
        {
            gamePause = true;
            Time.timeScale = 0f;
            player.GetComponent<PlayerInput>().enabled = false;
        }
        else if (gamePause == true)
        {
            gamePause = false;
            Time.timeScale = 1f;
            player.GetComponent<PlayerInput>().enabled = true;
        }
    }

    //Update Method
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.P))
        {
            pauseOrUnpauseGame();
        }
	}
}
