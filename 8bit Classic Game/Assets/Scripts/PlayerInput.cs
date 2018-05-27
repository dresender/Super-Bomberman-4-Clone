using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour 
{

	public float initialSpeed = 0.5f;

	private Vector2 movement;
	private Vector2 initialPosition;
	private float speed;
	private enum collisionType { left, right, up, down, free };
	private collisionType collision;

	void Start () 
	{
		initialPosition = new Vector2(-0.961f, 0.722f);
		movement = new Vector2();
		movement = initialPosition;
		speed = initialSpeed;
	}

	void Update () 
	{
		DetectInput();
	}

	private void DetectInput()
	{
		if (Input.GetKey("up"))
		{
			movement +=  Vector2.up * speed * Time.deltaTime; 
		}
		if (Input.GetKey("down"))
		{
			movement +=  Vector2.down * speed * Time.deltaTime; 
		}
		if (Input.GetKey("right"))
		{
            if (collision != collisionType.right)
			    movement +=  Vector2.right * speed * Time.deltaTime; 
		}
		if (Input.GetKey("left"))
		{
           //if (collision != collisionType.left)
                movement +=  Vector2.left * speed * Time.deltaTime; 
		}

		Move();
	}

	private void Move()
	{
		transform.position = movement;
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.position.x > transform.position.x)
        {
            collision = collisionType.right;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        collision = collisionType.free;
    }

}
