using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartImage : MonoBehaviour
{
    //Sprites References
    public Sprite heart3;
    public Sprite heart2;
    public Sprite heart1;
    public Sprite heart0;

    // Use this for initialization
    void Start ()
    {
        int lives = LivesController.Instance.lives;
        if (lives == 3) this.GetComponent<SpriteRenderer>().sprite = heart3;
        else if (lives == 2) this.GetComponent<SpriteRenderer>().sprite = heart2;
        else if (lives == 1) this.GetComponent<SpriteRenderer>().sprite = heart1;
        else if (lives == 0) this.GetComponent<SpriteRenderer>().sprite = heart0;
    }
}
