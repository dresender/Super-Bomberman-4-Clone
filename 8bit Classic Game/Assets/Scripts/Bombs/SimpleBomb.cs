using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBomb : Bomb
{
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //Explode Method
    public override void explode()
    {
        //Explosion Center
        GetComponent<SpriteRenderer>().sprite = null;
        Instantiate(centerExplosion, this.transform.position, Quaternion.identity);

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
                    if(collision.CompareTag("SoftBlock"))
                    {
                        upBlocked = true;
                        collision.GetComponent<Animator>().enabled = true;
                    }
                    else if(collision.CompareTag("Enemy"))
                    {
                        upBlocked = true;
                        collision.GetComponent<EnemyAI>().killEnemy();
                    }
                    else upBlocked = true;
                }
                else
                {
                    if (i == radius) Instantiate(upEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate(upArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
            if (!downBlocked)
            {
                Vector3 desiredPosition = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y - i + 0.5f, this.transform.position.z);
                Collider2D collision = Physics2D.OverlapBox(desiredPosition, collisionVector, 0f);

                if (collision != null)
                {
                    if(collision.CompareTag("SoftBlock"))
                    {
                        downBlocked = true;
                        collision.GetComponent<Animator>().enabled = true;
                    }
                    else if (collision.CompareTag("Enemy"))
                    {
                        upBlocked = true;
                        collision.GetComponent<EnemyAI>().killEnemy();
                    }
                    else downBlocked = true;
                }
                else
                {
                    if (i == radius) Instantiate(downEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate(downArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
            if (!rightBlocked)
            {
                Vector3 desiredPosition = new Vector3(this.transform.position.x + i + 0.5f, this.transform.position.y + 0.5f, this.transform.position.z);
                Collider2D collision = Physics2D.OverlapBox(desiredPosition, collisionVector, 0f);

                if (collision != null)
                {
                    if (collision.CompareTag("SoftBlock"))
                    {
                        rightBlocked = true;
                        collision.GetComponent<Animator>().enabled = true;
                    }
                    else if (collision.CompareTag("Enemy"))
                    {
                        upBlocked = true;
                        collision.GetComponent<EnemyAI>().killEnemy();
                    }
                    else rightBlocked = true;
                }
                else
                {
                    if (i == radius) Instantiate(rightEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate(rightArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
            if (!leftBlocked)
            {
                Vector3 desiredPosition = new Vector3(this.transform.position.x - i + 0.5f, this.transform.position.y + 0.5f, this.transform.position.z);
                Collider2D collision = Physics2D.OverlapBox(desiredPosition, collisionVector, 0f);

                if (collision != null)
                {
                    if (collision.CompareTag("SoftBlock"))
                    {
                        leftBlocked = true;
                        collision.GetComponent<Animator>().enabled = true;
                    }
                    else if (collision.CompareTag("Enemy"))
                    {
                        upBlocked = true;
                        collision.GetComponent<EnemyAI>().killEnemy();
                    }
                    else leftBlocked = true;
                }
                else
                {
                    if (i == radius) Instantiate(leftEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate(leftArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
        }

        //Destroy Bomb
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update ()
    {
        //If Animation Ended -> Destroy Self
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1) explode();
    }
}
