using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputLegacy : MonoBehaviour 
{
	public float speed = 125f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rb2d.velocity = new Vector2 (h, v) * speed * Time.deltaTime;
    }
}
