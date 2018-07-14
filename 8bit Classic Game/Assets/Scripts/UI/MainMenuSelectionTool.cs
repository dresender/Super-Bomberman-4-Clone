using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SelectorPosition { up, middle, down };

public class MainMenuSelectionTool : MonoBehaviour
{    
    private Vector2 newPosition;
    private float newPositionY;
    private float newPositionX;
    private SelectorPosition handPointer;

    void Start ()
    {
        //Setting up initial pointer SelectorPosition
        handPointer = SelectorPosition.up;

        //Setting up initial pointer position
        newPositionY = -2.75f;
        newPositionX = -4.25f;
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z) && handPointer == SelectorPosition.up)
        {
            SceneManager.LoadScene("World One");
        }

		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (handPointer == SelectorPosition.up)
            {
                handPointer = SelectorPosition.middle;
                newPositionY = -3.75f;
            }
            else if (handPointer == SelectorPosition.middle)
            {
                handPointer = SelectorPosition.down;
                newPositionY = -4.75f;
            }
            else
            {
                handPointer = SelectorPosition.up;
                newPositionY = -2.75f;
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (handPointer == SelectorPosition.up)
            {
                handPointer = SelectorPosition.down;
                newPositionY = -4.75f;
            }
            else if (handPointer == SelectorPosition.middle)
            {
                handPointer = SelectorPosition.up;
                newPositionY = -2.75f;
            }
            else
            {
                handPointer = SelectorPosition.middle;
                newPositionY = -3.75f;
            }
        }

        newPosition.y = newPositionY;
        newPosition.x = newPositionX;
        transform.position = newPosition;
	}
}
