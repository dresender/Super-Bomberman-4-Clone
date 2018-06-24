﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { up, down, left, right, none };

public class PlayerInput : MonoBehaviour
{
    //Player Movement Speed
    public float speed = 125f;

    private float raycastMargin;

    //Collider Size
    private Vector2 colliderSize;

    //Start Method
    void Start()
    {
        colliderSize = GetComponent<BoxCollider2D>().size;
        raycastMargin = 0.5f;
    }

    //Update Method
	void Update () 
	{
		MovePlayer();
	}

    //Movement Algorithm
	private void MovePlayer()
	{
        Direction dirMovement = Direction.none;

        //Initialize Movement Vector
        Vector2 movement = transform.position;

        //Preview Movement
        bool hasMoved = false;
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
            hasMoved = true;
            movement += Vector2.up * speed * Time.deltaTime;
            dirMovement = Direction.up;
		}
		else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
            hasMoved = true;
            movement += Vector2.down * speed * Time.deltaTime;
            dirMovement = Direction.down;
        }
		else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
            hasMoved = true;
            movement += Vector2.right * speed * Time.deltaTime;
            dirMovement = Direction.right;
        }
		else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
            hasMoved = true;
            movement += Vector2.left * speed * Time.deltaTime;
            dirMovement = Direction.left;
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
                for(int i = 0; i < collisions.Length; i++)
                {
                    //TODO: Add more logic here. Certain powerups can modify this.
                    if (collisions[i].tag == "Destroyable" || collisions[i].tag == "Indestructible")
                    {
                        if (dirMovement == Direction.down)
                        {
                            RaycastHit2D hitMiddle = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - raycastMargin - 0.01f), Vector2.down, 1f);

                            if (hitMiddle.collider == null)
                            {
                                RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + raycastMargin, transform.position.y - raycastMargin - 0.01f), Vector2.down, 1f);
                                RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - raycastMargin, transform.position.y - raycastMargin - 0.01f), Vector2.down, 1f);

                                if (hitRight.collider == null && hitLeft.collider != null)
                                {
                                    movement.x += 0.1f;
                                }
                                else if (hitLeft.collider == null && hitRight.collider != null)
                                {
                                    movement.x -= 0.1f;
                                }
                                else
                                {
                                    canMove = false;
                                }
                            }
                            else
                            {
                                canMove = false;
                            }
                        }
                        else if (dirMovement == Direction.up)
                        {                  
                            RaycastHit2D hitMiddle = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + raycastMargin + 0.01f), Vector2.up, 1f);

                            if (hitMiddle.collider == null)
                            {
                                RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + raycastMargin, transform.position.y + raycastMargin + 0.01f), Vector2.up, 1f);
                                RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - raycastMargin, transform.position.y + raycastMargin + 0.01f), Vector2.up, 1f);

                                if (hitRight.collider == null && hitLeft.collider != null)
                                {
                                    movement.x += 0.1f;
                                }
                                else if (hitLeft.collider == null && hitRight.collider != null)
                                {
                                    movement.x -= 0.1f;
                                }
                                else
                                {
                                    canMove = false;
                                }
                            }
                            else
                            {
                                canMove = false;
                            }

                        }
                        else if (dirMovement == Direction.right)
                        {
                            RaycastHit2D hitMiddle = Physics2D.Raycast(new Vector2(transform.position.x + raycastMargin + 0.01f, transform.position.y), Vector2.right, 1f);

                            if (hitMiddle.collider == null)
                            {
                                RaycastHit2D hitUp = Physics2D.Raycast(new Vector2(transform.position.x + raycastMargin + 0.01f, transform.position.y + raycastMargin), Vector2.right, 1f);
                                RaycastHit2D hitDown = Physics2D.Raycast(new Vector2(transform.position.x + raycastMargin + 0.01f, transform.position.y - raycastMargin), Vector2.right, 1f);

                                if (hitUp.collider == null && hitDown.collider != null)
                                {
                                    movement.y += 0.1f;
                                }
                                else if (hitDown.collider == null && hitUp.collider != null)
                                {
                                    movement.y -= 0.1f;
                                }
                                else
                                {
                                    canMove = false;
                                }
                            }
                            else
                            {
                                canMove = false;
                            }
                        }
                        else if (dirMovement == Direction.left)
                        {
                            RaycastHit2D hitMiddle = Physics2D.Raycast(new Vector2(transform.position.x - raycastMargin - 0.01f, transform.position.y), Vector2.left, 1f);

                            if (hitMiddle.collider == null)
                            {
                                RaycastHit2D hitUp = Physics2D.Raycast(new Vector2(transform.position.x - raycastMargin - 0.01f, transform.position.y + raycastMargin), Vector2.left, 1f);
                                RaycastHit2D hitDown = Physics2D.Raycast(new Vector2(transform.position.x - raycastMargin - 0.01f, transform.position.y - raycastMargin), Vector2.left, 1f);

                                if (hitUp.collider == null && hitDown.collider != null)
                                {
                                    movement.y += 0.1f;
                                }
                                else if (hitDown.collider == null && hitUp.collider != null)
                                {
                                    movement.y -= 0.1f;
                                }
                                else
                                {
                                    canMove = false;
                                }
                            }
                            else
                            {
                                canMove = false;
                            }
                        }
                        else canMove = false;
                    }
                }
            }

            //Move Player!
            if(canMove) 
                transform.position = movement;
        }
	}
}
