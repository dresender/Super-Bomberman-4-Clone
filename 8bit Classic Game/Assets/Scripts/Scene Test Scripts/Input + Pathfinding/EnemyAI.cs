using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour 
{
	public float speed = 125f;

	private enum directions { up, down, left, right };
	private Rigidbody2D rb2d;
	private Vector2 direction;
	private List<directions> listOfPossibleDirections;
	private int tempo = 0;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		listOfPossibleDirections = new List<directions>() { directions.up, 
			directions.down, directions.left, directions.right };

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
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1f);

		if (hit.collider == null)
			listOfPossibleDirections.Add(directions.up);

		//Checking for collisions down
		hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);

		if (hit.collider == null)
			listOfPossibleDirections.Add(directions.down);

		//Checking for collisions left
		hit = Physics2D.Raycast(transform.position, Vector2.left, 1f);

		if (hit.collider == null)
			listOfPossibleDirections.Add(directions.left);

		//Checking for collisions right
		hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);

		if (hit.collider == null)
			listOfPossibleDirections.Add(directions.right);

		foreach (var dir in listOfPossibleDirections)
		{
			Debug.Log(dir);
		}		

		DirectionOfMovement();
	}

	private void DirectionOfMovement()
	{
		//Decide which of the empty tiles is going to be
		//the choosen for the direction of movement

		//pick up a random item from the possible directions list
		int rnd = Random.Range(0, listOfPossibleDirections.Count);

		Debug.Log(rnd);

		directions tempDirection = listOfPossibleDirections[rnd];

		Debug.Log(tempDirection);

		//assign the vector2 direction variable according to the value
		if(tempDirection == directions.up)
		{
			direction = Vector2.up;
		}
		if(tempDirection == directions.down)
		{
			direction = Vector2.down;
		}
		if(tempDirection == directions.left)
		{
			direction = Vector2.left;
		}
		if(tempDirection == directions.right)
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
