using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour 
{
    //Public Variables
	public float speed;

    //Enum
    private enum Directions { up, down, left, right };

    //Private Variables
    private EnemyAnimation enemyAnimation;
	private Vector2 colliderSize;
	private Vector2 direction;
	private Vector2 transformMovement;
	private List<Directions> listOfPossibleDirections;
    private bool active;
    private float turningInterval;

    //Start Method
	void Start()
	{
        ControllerManager.Instance.enemiesController.registerEnemy(this.gameObject);
        enemyAnimation = this.GetComponent<EnemyAnimation>();
        colliderSize = GetComponent<BoxCollider2D>().size;
		listOfPossibleDirections = new List<Directions>();
		transformMovement = transform.position;
		direction = Vector2.down;
        turningInterval = 0f;
    }

    //Update Method
    void Update()
	{
        if(ControllerManager.Instance.timeController.getTimeState()) Movement();
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
            transformMovement += direction * speed * Time.deltaTime;
            transform.position = transformMovement;
            Collider2D[] collisions = Physics2D.OverlapBoxAll(transformMovement, colliderSize, 0f);
            for(int i = 0; i < collisions.Length; i++)
            {
                if(collisions[i].gameObject.layer == 8 || collisions[i].gameObject.layer == 10) turningInterval = 1f;
            }
        }
		
	}

	private void CheckSurroundings()
	{
		//Checking for collisions up
		Collider2D hit = Physics2D.OverlapPoint(transform.position + new Vector3(0, 1, 0));
		if (hit == null) listOfPossibleDirections.Add(Directions.up);

		//Checking for collisions down
		hit = Physics2D.OverlapPoint(transform.position + new Vector3(0, -1, 0));
		if (hit == null) listOfPossibleDirections.Add(Directions.down);

		//Checking for collisions left
		hit = Physics2D.OverlapPoint(transform.position + new Vector3(-1, 0, 0));
		if (hit == null) listOfPossibleDirections.Add(Directions.left);

		//Checking for collisions right
		hit = Physics2D.OverlapPoint(transform.position + new Vector3(1, 0, 0));
		if (hit == null) listOfPossibleDirections.Add(Directions.right);

		SnapToGrid();
        if(listOfPossibleDirections.Count > 0) SortDirectionOfMovement();
	}

	private void SnapToGrid()
	{
		transformMovement = new Vector2 (Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
	}

	private void SortDirectionOfMovement()
	{
		//Decide which of the empty tiles is going to be
		//the choosen for the direction of movement

		//pick up a random item from the possible directions list
		int rnd = Random.Range(0, listOfPossibleDirections.Count);

		//Debug.Log(rnd);

		Directions tempDirection = listOfPossibleDirections[rnd];

		//Debug.Log(tempDirection);

		//assign the vector2 direction variable according to the value
		if(tempDirection == Directions.up)
		{
			direction = Vector2.up;
            enemyAnimation.setAnimation(1);
		}
		if(tempDirection == Directions.down)
		{
			direction = Vector2.down;
            enemyAnimation.setAnimation(0);
        }
		if(tempDirection == Directions.left)
		{
			direction = Vector2.left;
            enemyAnimation.setAnimation(3);
        }
		if(tempDirection == Directions.right)
		{
			direction = Vector2.right;
            enemyAnimation.setAnimation(2);
        }
		
		//Clear the list for next iteration
		listOfPossibleDirections.Clear();
	}	
}
