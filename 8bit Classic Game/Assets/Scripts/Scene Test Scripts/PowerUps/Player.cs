using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Generic Powerup
    public int bombRadius = 1;
    public int numberOfBombs = 1;
    public float speed = 2f;
    //TODO: Continue

    //Type of Bomb
    public GameObject bombType;

    //Specific Powerups
    public bool bombKick = false;
    //TODO: Continue

    //Scene Test
    public Transform pointA;
    public Transform pointB;
    public Vector3 currentTarget;

    void Start()
    {
        currentTarget = pointA.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bomb = Instantiate(bombType, new Vector3(this.transform.position.x - 0.5f, this.transform.position.y - 0.5f, this.transform.position.z), Quaternion.identity);
            bomb.GetComponent<Bomb>().setRadius(bombRadius);
        }

        if((this.transform.position - currentTarget).magnitude < 1)
        {
            if (currentTarget == pointA.position) currentTarget = pointB.position;
            else currentTarget = pointA.position;
        }
        else this.transform.position = Vector3.MoveTowards(this.transform.position, currentTarget, Time.deltaTime * speed);
    }
}
