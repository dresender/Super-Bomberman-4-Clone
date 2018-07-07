using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    //Variables
    private LinkedList<GameObject> bombsPlayer1;

    //Start Method
    private void Start()
    {
        bombsPlayer1 = new LinkedList<GameObject>();
    }

    //Place New Bomb Method
    public void placeBomb(int max, int bombRadius, GameObject bombType, Vector2 position)
    {
        if(bombsPlayer1.Count < max)
        {
            Debug.Log(position);
            position.x = Mathf.Round(position.x) - 0.5f;
            position.y = Mathf.Round(position.y) - 0.5f;
            GameObject bomb = Instantiate(bombType, position, Quaternion.identity);
            bomb.GetComponent<Bomb>().setRadius(bombRadius);
            bombsPlayer1.AddLast(bomb);
        }
    }

    //Remove Bomb from List Method
    public void removeBomb(GameObject bombReference)
    {
        bombsPlayer1.Remove(bombReference);
    }
}
