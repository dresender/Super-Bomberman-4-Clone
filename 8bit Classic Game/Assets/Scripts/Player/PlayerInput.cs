using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { up, down, left, right, none };

public class PlayerInput : MonoBehaviour
{
    //Internal Variables
    private float raycastMargin;
    private Vector2 colliderSize;
    private PlayerAnimation playerAnimation;
    private PlayerState playerState;
    private GameObject lastBombLayed;
    private bool insideBomb;

    //Start Method
    void Start()
    {
        lastBombLayed = null;
        playerState = this.GetComponent<PlayerState>();
        playerAnimation = this.GetComponent<PlayerAnimation>();
        colliderSize = this.GetComponent<BoxCollider2D>().size;
        raycastMargin = 0.5f;
    }

    //Update Method
	void Update () 
	{
        layBombs();
		movePlayer();
	}

    //Lay Bombs Algorithm
    private void layBombs()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
            //Check for Position
            Collider2D[] collisions = Physics2D.OverlapBoxAll(this.transform.position, colliderSize, 0f);

            for(int i = 0; i < collisions.Length; i++)
            {
                if (collisions[i].gameObject.layer == 9) return;
            }

            //Finally...
            lastBombLayed = ControllerManager.Instance.bombController.placeBomb(playerState.maxBombs, playerState.bombRadius, playerState.bombType, this.transform.position);
            if (lastBombLayed != null) insideBomb = true;
        }
    }

    //Movement Algorithm
	private void movePlayer()
	{
        //Initialize Temporary Variables
        Direction dirMovement = Direction.none;
        Vector2 movement = transform.position;
        bool remainInsideBomb = false;

        //Preview Movement
        bool hasMoved = false;
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
            hasMoved = true;
            movement += Vector2.up * playerState.speed * Time.deltaTime;
            dirMovement = Direction.up;
            playerAnimation.setMovementAnimation(true, 1);
        }
		else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
            hasMoved = true;
            movement += Vector2.down * playerState.speed * Time.deltaTime;
            dirMovement = Direction.down;
            playerAnimation.setMovementAnimation(true, 0);
        }
		else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
            hasMoved = true;
            movement += Vector2.right * playerState.speed * Time.deltaTime;
            dirMovement = Direction.right;
            playerAnimation.setMovementAnimation(true, 2);
        }
		else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
            hasMoved = true;
            movement += Vector2.left * playerState.speed * Time.deltaTime;
            dirMovement = Direction.left;
            playerAnimation.setMovementAnimation(true, 3);
        }
        else playerAnimation.setMovementAnimation(false);

        //Check for Collisions
        if (hasMoved)
        {
            //Get Colliders
            Collider2D[] collisions = Physics2D.OverlapBoxAll(movement, colliderSize, 0f);
            bool canMove = true;

            //Will Always Collide with Itself!
            if (collisions.Length > 1)
            {
                for (int i = 0; i < collisions.Length; i++)
                {
                    if (collisions[i].gameObject.layer == 11)
                    {
                        if (lastBombLayed != collisions[i].gameObject) canMove = false;
                        else
                        {
                            if (insideBomb) remainInsideBomb = true;
                            else canMove = false;
                        }
                    }
                    else if (collisions[i].gameObject.layer == 8 || collisions[i].gameObject.layer == 10)
                    {
                        if (dirMovement == Direction.down)
                        {
                            RaycastHit2D hitMiddle = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.down, 1f);

                            if (hitMiddle.collider == null)
                            {
                                RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + raycastMargin, transform.position.y), Vector2.down, 1f);
                                RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - raycastMargin, transform.position.y), Vector2.down, 1f);

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
                                RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x + raycastMargin, transform.position.y), Vector2.up, 1f);
                                RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x - raycastMargin, transform.position.y), Vector2.up, 1f);

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
                            RaycastHit2D hitMiddle = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.right, 1f);

                            if (hitMiddle.collider == null)
                            {
                                RaycastHit2D hitUp = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + raycastMargin), Vector2.right, 1f);
                                RaycastHit2D hitDown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - raycastMargin), Vector2.right, 1f);

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
                            RaycastHit2D hitMiddle = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.left, 1f);

                            if (hitMiddle.collider == null)
                            {
                                RaycastHit2D hitUp = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + raycastMargin), Vector2.left, 1f);
                                RaycastHit2D hitDown = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - raycastMargin), Vector2.left, 1f);

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
                    else if (collisions[i].CompareTag("Enemy"))
                    {
                        if(collisions[i].GetComponent<EnemyAI>().isAlive()) playerState.killPlayer();
                    }
                }
            }

            //Set Bomb Walkability
            if (!remainInsideBomb) insideBomb = false;

            //Move Player!
            if (canMove) transform.position = movement;
        }
	}
}
