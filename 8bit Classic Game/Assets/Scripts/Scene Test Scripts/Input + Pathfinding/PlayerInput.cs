using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
    //Player Movement Speed
	public float speed = 125f;

    //Collider Size
    public Vector2 colliderSize;

    //Start Method
    void Start()
    {
        colliderSize = this.GetComponent<BoxCollider2D>().size;
    }

    //Update Method
	void Update () 
	{
		MovePlayer();
	}

    //Movement Algorithm
	private void MovePlayer()
	{
        //Initialize Movement Vector
        Vector2 movement = this.transform.position;

        //Preview Movement
        bool hasMoved = false;
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
            hasMoved = true;
            movement += Vector2.up * speed * Time.deltaTime;
		}
		else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
            hasMoved = true;
            movement += Vector2.down * speed * Time.deltaTime;
        }
		else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
            hasMoved = true;
            movement += Vector2.right * speed * Time.deltaTime;
        }
		else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
            hasMoved = true;
            movement += Vector2.left * speed * Time.deltaTime;
        }

        //Check for Collisions
        if(hasMoved)
        {
            //Get Colliders
            Collider2D[] collisions = Physics2D.OverlapBoxAll(movement, colliderSize, 0f);
            bool canMove = true;

            //Will Always Collide with Itself!
            if (collisions.Length > 1)
            {
                for(int i = 1; i < collisions.Length; i++)
                {
                    //TODO: Add more logic here. Certain powerups can modify this.
                    if(collisions[i].tag == "Destroyable" || collisions[i].tag == "Indestructible") canMove = false;
                }
            }

            //Move Player!
            if(canMove) transform.position = movement;
        }
	}
}
