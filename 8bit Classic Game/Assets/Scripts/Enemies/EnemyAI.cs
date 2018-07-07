using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour 
{
    //Public Variables
	public float speed = 1.5f;

    //Private Variables
    private EnemyAnimation enemyAnimation;
	private enum Directions { up, down, left, right };
	private Vector2 colliderSize;
	private Directions aiDirection;
	private Vector2 direction;
	private Vector2 transformMovement;
	private List<Directions> listOfPossibleDirections;

	void Start()
	{
        enemyAnimation = this.GetComponent<EnemyAnimation>();
        colliderSize = GetComponent<BoxCollider2D>().size;
		listOfPossibleDirections = new List<Directions>();
		transformMovement = transform.position;
		direction = Vector2.down;
        enemyAnimation.setAnimation(0);
    }

	void Update()
	{
		Movement();
	}

	private void Movement()
	{
		transformMovement += direction * speed * Time.deltaTime;
		transform.position = transformMovement;


		CheckSurroundings();
	}

	private void CheckSurroundings()
	{
		Collider2D[] collisions = Physics2D.OverlapBoxAll(transformMovement, colliderSize, 0f);

		if (collisions.Length > 1)
        {
			Debug.Log("Collission detected!");

			//Checking for collisions up
			Collider2D hit = Physics2D.OverlapPoint(transform.position + new Vector3(0, 1, 0));

			if (hit == null)
			{
				listOfPossibleDirections.Add(Directions.up);
			}

			//Checking for collisions down
			hit = Physics2D.OverlapPoint(transform.position + new Vector3(0, -1, 0));
			//Debug.Log(hit);

			if (hit == null)
			{
				listOfPossibleDirections.Add(Directions.down);
			}

			//Checking for collisions left
			hit = Physics2D.OverlapPoint(transform.position + new Vector3(-1, 0, 0));
			//Debug.Log(hit);

			if (hit == null)
			{
				listOfPossibleDirections.Add(Directions.left);
			}

			//Checking for collisions right
			hit = Physics2D.OverlapPoint(transform.position + new Vector3(1, 0, 0));

			if (hit == null)
			{
				listOfPossibleDirections.Add(Directions.right);
			}

			foreach (var dir in listOfPossibleDirections)
			{
				//Debug.Log(dir);
			}

			SnapToGrid();
			SortDirectionOfMovement();		
		}
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
