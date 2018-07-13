using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public enum SelectorPosition { up, middle, down };

public class GameOverScreenSelectionTool : MonoBehaviour
{
    Vector2 newPosition;
    float newPositionY;
    float newPositionX;
    SelectorPosition handPointer;

    void Start ()
    {
        //Setting up initial pointer SelectorPosition
        handPointer = SelectorPosition.up;

        //Setting up initial pointer position
        newPositionY = 2.5f;
        newPositionX = -3.9f;
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
        {
            LivesController.lives = 3;
            if (handPointer == SelectorPosition.up)
            {
                SceneManager.LoadScene("World One");
            }
            else
            {
                SceneManager.LoadScene("Main Menu");
            }
        }

		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (handPointer == SelectorPosition.up)
            {
                handPointer = SelectorPosition.down;
                newPositionY = 1.5f;
            }
            else
            {
                handPointer = SelectorPosition.up;
                newPositionY = 2.5f;
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (handPointer == SelectorPosition.up)
            {
                handPointer = SelectorPosition.down;
                newPositionY = 1.5f;
            }
            else
            {
                handPointer = SelectorPosition.up;
                newPositionY = 2.5f;
            }
        }

        newPosition.y = newPositionY;
        newPosition.x = newPositionX;
        transform.position = newPosition;
	}
}
