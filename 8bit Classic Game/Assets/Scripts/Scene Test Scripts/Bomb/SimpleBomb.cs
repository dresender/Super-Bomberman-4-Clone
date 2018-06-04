using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBomb : Bomb
{
    public override void explode()
    {
        //Explosion Center
        GetComponent<SpriteRenderer>().sprite = null;
        Instantiate<GameObject>(centerExplosion, this.transform.position, Quaternion.identity);

        //Collision Vector
        Vector2 collisionVector = new Vector2(0.75f, 0.75f);

        //Add Explosion Radius
        bool upBlocked = false;
        bool downBlocked = false;
        bool rightBlocked = false;
        bool leftBlocked = false;

        for (int i = 1; i <= radius; i++)
        {
            if(!upBlocked)
            {
                Vector3 desiredPosition = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + i + 0.5f, this.transform.position.z);
                Collider2D collision = Physics2D.OverlapBox(desiredPosition, collisionVector, 0f);

                if(collision != null)
                {
                    upBlocked = true;
                    if (collision.tag == "Destroyable") Destroy(collision.gameObject);
                    //TODO: Make animations of being destroyed
                }
                else
                {
                    if (i == radius) Instantiate<GameObject>(upEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate<GameObject>(upArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
            if (!downBlocked)
            {
                Vector3 desiredPosition = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y - i + 0.5f, this.transform.position.z);
                Collider2D collision = Physics2D.OverlapBox(desiredPosition, collisionVector, 0f);

                if (collision != null)
                {
                    downBlocked = true;
                    if (collision.tag == "Destroyable") Destroy(collision.gameObject);
                    //TODO: Make animations of being destroyed
                }
                else
                {
                    if (i == radius) Instantiate<GameObject>(downEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate<GameObject>(downArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
            if (!rightBlocked)
            {
                Vector3 desiredPosition = new Vector3(this.transform.position.x + i + 0.5f, this.transform.position.y + 0.5f, this.transform.position.z);
                Collider2D collision = Physics2D.OverlapBox(desiredPosition, collisionVector, 0f);

                if (collision != null)
                {
                    rightBlocked = true;
                    if (collision.tag == "Destroyable") Destroy(collision.gameObject);
                    //TODO: Make animations of being destroyed
                }
                else
                {
                    if (i == radius) Instantiate<GameObject>(rightEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate<GameObject>(rightArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
            if (!leftBlocked)
            {
                Vector3 desiredPosition = new Vector3(this.transform.position.x - i + 0.5f, this.transform.position.y + 0.5f, this.transform.position.z);
                Collider2D collision = Physics2D.OverlapBox(desiredPosition, collisionVector, 0f);

                if (collision != null)
                {
                    leftBlocked = true;
                    if (collision.tag == "Destroyable") Destroy(collision.gameObject);
                    //TODO: Make animations of being destroyed
                }
                else
                {
                    if (i == radius) Instantiate<GameObject>(leftEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate<GameObject>(leftArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
        }

        //Destroy Bomb
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        radius = 2;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //If Animation Ended -> Destroy Self
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) explode();
    }
}
