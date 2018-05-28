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

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		listOfPossibleDirections = new List<directions>();
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


		DirectionOfMovement();
	}

	private void DirectionOfMovement()
	{
		//Decide which of the empty tiles is going to be
		//the choosen for the direction of movement

		//pick up a random item from the possible directions list

		//assign the vector2 direction variable according to the value

		//Clear the list for next iteration
		listOfPossibleDirections.Clear();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//Set the vector2 direction to zero, so enemy doesnt move
		//while "thinking" where to go

		//If there is a collision, wait for 1 second and call the
		//CheckSurroundings method
	}
}
