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
    public GameObject placeBomb(int max, int bombRadius, GameObject bombType, Vector2 position)
    {
        if (bombsPlayer1.Count < max)
        {
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y);
            GameObject bomb = Instantiate(bombType, position, Quaternion.identity);
            bomb.GetComponent<Bomb>().setRadius(bombRadius);
            bombsPlayer1.AddLast(bomb);
            return bomb;
        }
        else return null;
    }

    //Remove Bomb from List Method
    public void removeBomb(GameObject bombReference)
    {
        bombsPlayer1.Remove(bombReference);
    }
}
