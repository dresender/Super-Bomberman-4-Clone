using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * TODO: Dynamic Collision (Something Intentionally enters explosion area)
 */

public class SimpleBomb : Bomb
{
    public override void explode()
    {
        //Explosion Center
        GetComponent<SpriteRenderer>().sprite = null;
        Instantiate<GameObject>(explosion, this.transform.position, Quaternion.identity);

        //Add Explosion Radius
        bool upBlocked = false;
        bool downBlocked = false;
        bool rightBlocked = false;
        bool leftBlocked = false;

        for (int i = 1; i <= radius; i++)
        {
            Vector3 desiredPosition;

            //Spawn Explosion Tiles
            if (!upBlocked)
            {
                desiredPosition = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y + i + 0.5f, this.transform.position.z);
                //TODO - Check Collision

                GameObject explosionTile = Instantiate<GameObject>(explosion, desiredPosition, Quaternion.identity);
                if (i == radius) explosionTile.GetComponent<Explosion>().setAnimation(5);
                else explosionTile.GetComponent<Explosion>().setAnimation(3);
            }
            if (!downBlocked)
            {
                desiredPosition = new Vector3(this.transform.position.x + 0.5f, this.transform.position.y - i + 0.5f, this.transform.position.z);
                //TODO - Check Collision

                GameObject explosionTile = Instantiate<GameObject>(explosion, desiredPosition, Quaternion.identity);
                if (i == radius) explosionTile.GetComponent<Explosion>().setAnimation(6);
                else explosionTile.GetComponent<Explosion>().setAnimation(4);
            }
            if (!rightBlocked)
            {
                desiredPosition = new Vector3(this.transform.position.x + i + 0.5f, this.transform.position.y + 0.5f, this.transform.position.z);
                //TODO - Check Collision

                GameObject explosionTile = Instantiate<GameObject>(explosion, desiredPosition, Quaternion.identity);
                if (i == radius) explosionTile.GetComponent<Explosion>().setAnimation(8);
                else explosionTile.GetComponent<Explosion>().setAnimation(1);
            }
            if (!leftBlocked)
            {
                desiredPosition = new Vector3(this.transform.position.x - i + 0.5f, this.transform.position.y + 0.5f, this.transform.position.z);
                //TODO - Check Collision

                GameObject explosionTile = Instantiate<GameObject>(explosion, desiredPosition, Quaternion.identity);
                if (i == radius) explosionTile.GetComponent<Explosion>().setAnimation(7);
                else explosionTile.GetComponent<Explosion>().setAnimation(2);
            }
        }

        //Terminate Self
        Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        remainingTime = detonationTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (remainingTime <= 0) explode();
        else
        {
            remainingTime = remainingTime - Time.deltaTime;
        }
	}
}
