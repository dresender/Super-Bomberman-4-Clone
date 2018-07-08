using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelectorPosition { up, middle, down };

public class MainMenuSelectionTool : MonoBehaviour
{
    //35, 52, 69 (17 positions)

    Vector2 newPosition;
    float newPositionY;
    SelectorPosition handPointer;

    void Start ()
    {
        handPointer = SelectorPosition.up;
	}
	
	void Update ()
    {
        newPosition = transform.position;

		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (handPointer == SelectorPosition.up)
            {
                handPointer = SelectorPosition.middle;
                newPositionY = 69f;
            }
            else if (handPointer == SelectorPosition.middle)
            {
                handPointer = SelectorPosition.down;
                newPositionY = 52f;
            }
            else
            {
                handPointer = SelectorPosition.up;
                newPositionY = 35f;
            }
        }
        else if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
 
        }

        newPosition.y = newPositionY;
        transform.position = newPosition;
	}
}
