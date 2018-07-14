using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour 
{
    //Public Variables
	public float speed;
    public GameObject egg;

    //Enum
    private enum Directions { up, down, left, right };

    //Private Variables
    private EnemyAnimation enemyAnimation;
	private Vector2 colliderSize;
	private Vector2 direction;
	private List<Directions> listOfPossibleDirections;
    private bool alive;
    private float turningInterval;

    //Start Method
	void Start()
	{
        ControllerManager.Instance.enemiesController.registerEnemy(this.gameObject);
        enemyAnimation = this.GetComponent<EnemyAnimation>();
        colliderSize = new Vector2(0.9f, 0.9f);
		listOfPossibleDirections = new List<Directions>();
		direction = Vector2.down;
        turningInterval = 0f;
        alive = true;
    }

    //Update Method
    void Update()
	{
        if(alive)
        {
            if (ControllerManager.Instance.timeController.getTimeState()) Movement();
        }
        else
        {
            if (enemyAnimation.getStateAnimation() >= 1f) Destroy(this.gameObject);
        }
	}

    //Check if Alive
    public bool isAlive()
    {
        return alive;
    }

    //Kill Enemy
    public void killEnemy()
    {
        if(alive)
        {
            alive = false;
            enemyAnimation.triggerKillAnimation();
            ControllerManager.Instance.scoreController.spawnScore(this.transform.position);
            Instantiate(egg, new Vector2(Mathf.Round(this.transform.position.x), Mathf.Round(this.transform.position.y) + 0.25f), Quaternion.identity);
        }
    }

    //On Object Destroy
    private void OnDestroy()
    {
        if(ControllerManager.Instance != null) ControllerManager.Instance.enemiesController.deRegisterEnemy(this.gameObject);
    }

    //Movement Logic
    private void Movement()
	{
        if(turningInterval > 0f)
        {
            turningInterval -= Time.deltaTime;
            if(turningInterval <= 0f) CheckSurroundings();
        }
        else
        {
            this.transform.position = (Vector2) this.transform.position + direction * speed * Time.deltaTime;
            Collider2D[] collisions = Physics2D.OverlapBoxAll(this.transform.position, colliderSize, 0f);
            for(int i = 0; i < collisions.Length; i++)
            {
                if ((collisions[i].gameObject.layer == 8 || collisions[i].gameObject.layer == 10) || (collisions[i].gameObject.layer == 11) || (collisions[i].CompareTag("Enemy") && collisions[i].gameObject != this.gameObject))
                {
                    turningInterval = 1f;
                }
                else if (collisions[i].CompareTag("Player")) collisions[i].GetComponent<PlayerState>().killPlayer();
            }
        }
	}

    //Check Surroundings of Collision
	private void CheckSurroundings()
	{
        //Snap to Grid before checking collisions
        SnapToGrid();

        //Checking for collisions up
        Collider2D hit = Physics2D.OverlapBox((Vector2) transform.position + Vector2.up, colliderSize, 0f);
        if ((hit == null) || (hit.gameObject.layer != 8 && hit.gameObject.layer != 10 && !hit.CompareTag("Enemy")))
        {
            listOfPossibleDirections.Add(Directions.up);
        }

		//Checking for collisions down
		hit = Physics2D.OverlapBox((Vector2)transform.position + Vector2.down, colliderSize, 0f);
        if ((hit == null) || (hit.gameObject.layer != 8 && hit.gameObject.layer != 10 && !hit.CompareTag("Enemy")))
        {
            listOfPossibleDirections.Add(Directions.down);
        }

		//Checking for collisions left
		hit = Physics2D.OverlapBox((Vector2)transform.position + Vector2.left, colliderSize, 0f);
        if ((hit == null) || (hit.gameObject.layer != 8 && hit.gameObject.layer != 10 && !hit.CompareTag("Enemy")))
        {
            listOfPossibleDirections.Add(Directions.left);
        }

		//Checking for collisions right
		hit = Physics2D.OverlapBox((Vector2)transform.position + Vector2.right, colliderSize, 0f);
        if ((hit == null) || (hit.gameObject.layer != 8 && hit.gameObject.layer != 10 && !hit.CompareTag("Enemy")))
        {
            listOfPossibleDirections.Add(Directions.right);
        }

        //Finally...
        if (listOfPossibleDirections.Count > 0) SortDirectionOfMovement();
	}

    //Snap to Grid Center
	private void SnapToGrid()
	{
        this.transform.position = new Vector2 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
	}

    //Set Final Movement Direction Randomly
	private void SortDirectionOfMovement()
	{
		//Decide which of the empty tiles is going to be
		//the choosen for the direction of movement

		//pick up a random item from the possible directions list
		int rnd = Random.Range(0, listOfPossibleDirections.Count);
		Directions tempDirection = listOfPossibleDirections[rnd];

		//assign the vector2 direction variable according to the value
		if(tempDirection == Directions.up)
		{
			direction = Vector2.up;
            enemyAnimation.setMovementAnimation(1);
		}
		if(tempDirection == Directions.down)
		{
			direction = Vector2.down;
            enemyAnimation.setMovementAnimation(0);
        }
		if(tempDirection == Directions.left)
		{
			direction = Vector2.left;
            enemyAnimation.setMovementAnimation(3);
        }
		if(tempDirection == Directions.right)
		{
			direction = Vector2.right;
            enemyAnimation.setMovementAnimation(2);
        }
		
		//Clear the list for next iteration
		listOfPossibleDirections.Clear();
	}	
}
