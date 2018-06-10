using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{
	public float speed = 125f;

	private Vector2 movement;
	private bool upBlocked;
	private bool downBlocked;
	private bool rightBlocked;
	private bool leftBlocked;
	private float colliderSize;

	void Start () 
	{
		movement = new Vector2();
		movement = transform.position;
	}	

	void Update () 
	{
		CheckPlayerCollisions();
		MovePlayer();
	}

	private void CheckPlayerCollisions()
	{
		//Checking up direction
		Collider2D hit = Physics2D.OverlapBox(new Vector2(transform.position.x, 
			transform.position.y + 0.51f + 0.1f), new Vector2(0.45f, 0.05f), 0f);
		
		if (hit != null)
		{
			upBlocked = true;
		}
		else
		{
			upBlocked = false;
		}

		//Checking down direction
		hit = Physics2D.OverlapBox(new Vector2(transform.position.x, 
			transform.position.y - 0.51f - 0.01f), new Vector2(0.45f, 0.05f), 0f);
		
		if (hit != null)
		{
			downBlocked = true;
		}
		else
		{
			downBlocked = false;
		}

		//Checking right direction
		hit = Physics2D.OverlapBox(new Vector2(transform.position.x + 0.51f + 0.1f, 
			transform.position.y), new Vector2(0.05f, 0.45f), 0f);
		
		if (hit != null)
		{
			rightBlocked = true;
		}
		else
		{
			rightBlocked = false;
		}

		//Checking left direction
		hit = Physics2D.OverlapBox(new Vector2(transform.position.x - 0.51f - 0.1f, 
			transform.position.y), new Vector2(0.05f, 0.45f), 0f);
		
		if (hit != null)
		{
			leftBlocked = true;
		}
		else
		{
			leftBlocked = false;
		}
	}

	private void MovePlayer()
	{
		if(Input.GetKey("up") && !upBlocked)
		{
			movement += Vector2.up * speed * Time.deltaTime;
		}
		if(Input.GetKey("down") && !downBlocked)
		{
			movement += Vector2.down * speed * Time.deltaTime;
		}
		if(Input.GetKey("right") && !rightBlocked)
		{
			movement += Vector2.right * speed * Time.deltaTime;
		}
		if(Input.GetKey("left") && !leftBlocked)
		{
			movement += Vector2.left * speed * Time.deltaTime;
		}

		transform.position = movement;
	}
}
