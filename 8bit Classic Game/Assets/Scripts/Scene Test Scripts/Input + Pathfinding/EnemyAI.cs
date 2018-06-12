using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour 
{
	public float speed = 5f;

	private enum Directions { up, down, left, right };
	private Rigidbody2D rb2d;
	private Directions aiDirection;
	private Vector2 direction;
	private List<Directions> listOfPossibleDirections;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		listOfPossibleDirections = new List<Directions>();
		CheckSurroundings();
	}

	void FixedUpdate()
	{
		Movement();
	}

	private void Movement()
	{
		rb2d.velocity = direction * speed * Time.deltaTime;
	}

	private void CheckSurroundings()
	{
		//Check all four directions to see which ones are free
		//for movement (empty tiles)

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

		DirectionOfMovement();
	}

	private void DirectionOfMovement()
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
		}
		if(tempDirection == Directions.down)
		{
			direction = Vector2.down;
		}
		if(tempDirection == Directions.left)
		{
			direction = Vector2.left;
		}
		if(tempDirection == Directions.right)
		{
			direction = Vector2.right;
		}

		//Clear the list for next iteration
		listOfPossibleDirections.Clear();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//Set the vector2 direction to zero, so enemy doesnt move
		//while "thinking" where to go
		direction = Vector2.zero;
		
		//If there is a collision, wait for 1 second and call the
		//CheckSurroundings method
		CheckSurroundings();
	}
}
