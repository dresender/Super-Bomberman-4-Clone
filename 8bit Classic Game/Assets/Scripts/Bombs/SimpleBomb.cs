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
                Vector3 desiredPosition = this.transform.position + (Vector3.up * i);
                Collider2D[] collision = Physics2D.OverlapBoxAll(desiredPosition, collisionVector, 0f);

                for(int j = 0; j < collision.Length; j++)
                {
                    if (collision[j].CompareTag("SoftBlock"))
                    {
                        upBlocked = true;
                        collision[j].GetComponent<Animator>().enabled = true;
                    }
                    else if (collision[j].CompareTag("PowerUp"))
                    {
                        upBlocked = true;
                        collision[j].GetComponent<PowerUp>().destroyPowerup();
                    }
                    else if (collision[j].CompareTag("Enemy"))
                    {
                        collision[j].GetComponent<EnemyAI>().killEnemy();
                    }
                    else if (collision[j].CompareTag("Player"))
                    {
                        collision[j].GetComponent<PlayerState>().killPlayer();
                    }
                    else upBlocked = true;
                }
                
                if(!upBlocked)
                {
                    if (i == radius) Instantiate(upEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate(upArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
            if (!downBlocked)
            {
                Vector3 desiredPosition = this.transform.position + (Vector3.down * i);
                Collider2D[] collision = Physics2D.OverlapBoxAll(desiredPosition, collisionVector, 0f);

                for (int j = 0; j < collision.Length; j++)
                {
                    if (collision[j].CompareTag("SoftBlock"))
                    {
                        downBlocked = true;
                        collision[j].GetComponent<Animator>().enabled = true;
                    }
                    else if (collision[j].CompareTag("PowerUp"))
                    {
                        downBlocked = true;
                        collision[j].GetComponent<PowerUp>().destroyPowerup();
                    }
                    else if (collision[j].CompareTag("Enemy"))
                    {
                        collision[j].GetComponent<EnemyAI>().killEnemy();
                    }
                    else if (collision[j].CompareTag("Player"))
                    {
                        collision[j].GetComponent<PlayerState>().killPlayer();
                    }
                    else downBlocked = true;
                }

                if (!downBlocked)
                {
                    if (i == radius) Instantiate(downEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate(downArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
            if (!rightBlocked)
            {
                Vector3 desiredPosition = this.transform.position + (Vector3.right * i);
                Collider2D[] collision = Physics2D.OverlapBoxAll(desiredPosition, collisionVector, 0f);

                for (int j = 0; j < collision.Length; j++)
                {
                    if (collision[j].CompareTag("SoftBlock"))
                    {
                        rightBlocked = true;
                        collision[j].GetComponent<Animator>().enabled = true;
                    }
                    else if (collision[j].CompareTag("PowerUp"))
                    {
                        rightBlocked = true;
                        collision[j].GetComponent<PowerUp>().destroyPowerup();
                    }
                    else if (collision[j].CompareTag("Enemy"))
                    {
                        collision[j].GetComponent<EnemyAI>().killEnemy();
                    }
                    else if (collision[j].CompareTag("Player"))
                    {
                        collision[j].GetComponent<PlayerState>().killPlayer();
                    }
                    else rightBlocked = true;
                }

                if (!rightBlocked)
                {
                    if (i == radius) Instantiate(rightEndExplosion, desiredPosition, Quaternion.identity);
                    else Instantiate(rightArmExplosion, desiredPosition, Quaternion.identity);
                }
            }
            if (!leftBlocked)
            {
                Vector3 desiredPosition = this.transform.position + (Vector3.left * i);
                Collider2D[] collision = Physics2D.OverlapBoxAll(desiredPosition, collisionVector, 0f);

                for (int j = 0; j < collision.Length; j++)
                {
                    if (collision != null)
                    {
                        if (collision[j].CompareTag("SoftBlock"))
                        {
                            leftBlocked = true;
                            collision[j].GetComponent<Animator>().enabled = true;
                        }
                        else if (collision[j].CompareTag("PowerUp"))
                        {
                            leftBlocked = true;
                            collision[j].GetComponent<PowerUp>().destroyPowerup();
                        }
                        else if (collision[j].CompareTag("Enemy"))
                        {
                            collision[j].GetComponent<EnemyAI>().killEnemy();
                        }
                        else if (collision[j].CompareTag("Player"))
                        {
                            collision[j].GetComponent<PlayerState>().killPlayer();
                        }
                        else leftBlocked = true;
                    }
                }

                if (!leftBlocked)
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
