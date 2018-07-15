using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { up, down, left, right, none };

public class PlayerInput : MonoBehaviour
{
    //Internal Variables
    private float raycastMargin;
    private BoxCollider2D collider;
    private PlayerAnimation playerAnimation;
    private PlayerState playerState;
    private GameObject lastBombLayed;
    private bool insideBomb;
    private LinkedList<Vector2> lastPositions;
    private AudioManager aManager;
    private float timeWithoutMoving;

    //Start Method
    void Start()
    {
        //Cacheing the Audio Manager in the local variable
        aManager = FindObjectOfType<AudioManager>();

        lastBombLayed = null;
        playerState = this.GetComponent<PlayerState>();
        playerAnimation = this.GetComponent<PlayerAnimation>();
        collider = this.GetComponent<BoxCollider2D>();
        raycastMargin = 0.5f;
        lastPositions = new LinkedList<Vector2>();
    }

    //Update Method
	void Update () 
	{
        timeWithoutMoving += Time.deltaTime;
        layBombs();
		movePlayer();
        if (timeWithoutMoving >= 5f) playerAnimation.setDanceAnimation();
    }

    //Save Position
    private Vector2 savePosition(Vector2 position)
    {
        if(lastPositions.Count == 0)
        {
            lastPositions.AddFirst(position);
            return position;
        }
        else if (lastPositions.Last.Value != position)
        {
            Vector2 result = lastPositions.First.Value;
            if(lastPositions.Count == ControllerManager.Instance.extraEggsController.delayExtraEggMovement) lastPositions.RemoveFirst();
            lastPositions.AddLast(position);
            return result;
        }
        else return lastPositions.First.Value;
    }

    //Lay Bombs Algorithm
    private void layBombs()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z))
        {
            //Check for Position
            Collider2D[] collisions = new Collider2D[2];
            int hits = collider.GetContacts(collisions);
            bool canLayBomb = true;

            for(int i = 0; i < hits; i++)
            {
                if (!collisions[i].CompareTag("ExtraEgg")) canLayBomb = false;
            }

            //Finally...
            if (canLayBomb)
            {
                lastBombLayed = ControllerManager.Instance.bombController.placeBomb(playerState.maxBombs, playerState.bombRadius, playerState.bombType, this.transform.position);
                if (lastBombLayed != null) insideBomb = true;
            }
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
            playerAnimation.setMovementAnimation(true, 1, playerState.isRiding());
        }
		else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
            hasMoved = true;
            movement += Vector2.down * playerState.speed * Time.deltaTime;
            dirMovement = Direction.down;
            playerAnimation.setMovementAnimation(true, 0, playerState.isRiding());
        }
		else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
            hasMoved = true;
            movement += Vector2.right * playerState.speed * Time.deltaTime;
            dirMovement = Direction.right;
            playerAnimation.setMovementAnimation(true, 2, playerState.isRiding());
        }
		else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
            hasMoved = true;
            movement += Vector2.left * playerState.speed * Time.deltaTime;
            dirMovement = Direction.left;
            playerAnimation.setMovementAnimation(true, 3, playerState.isRiding());
        }
        else playerAnimation.setMovementAnimation(false, playerState.isRiding());

        //Check for Collisions
        if (hasMoved)
        {
            //Get Colliders
            timeWithoutMoving = 0f;
            Collider2D[] collisions = Physics2D.OverlapBoxAll(movement, collider.size, 0f);
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
            if (canMove)
            {
                if (ControllerManager.Instance.extraEggsController.extraEggsCount() > 0)
                {
                    Vector2 desiredPosition = savePosition(movement);
                    if (lastPositions.Count == ControllerManager.Instance.extraEggsController.delayExtraEggMovement)
                    {
                        ControllerManager.Instance.extraEggsController.moveEggs(desiredPosition);
                    }
                }
                else lastPositions.Clear();

                if (!aManager.IsPlaying("Walk"))
                {
                    aManager.Play("Walk");
                }

                //Finally...
                transform.position = movement;
            }
        }
	}
}
