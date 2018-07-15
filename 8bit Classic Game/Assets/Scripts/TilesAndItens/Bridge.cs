using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    //References
    public SpriteRenderer tile1;
    public SpriteRenderer tile2;
    public SpriteRenderer tile3;
    public SpriteRenderer tile4;

    public Sprite tile1normal;
    public Sprite tile1withPlayer;
    public Sprite tile2normal;
    public Sprite tile2withPlayer;
    public Sprite tile3normal;
    public Sprite tile3withPlayer;
    public Sprite tile4normal;
    public Sprite tile4withPlayer;

    private void OnTriggerExit2D(Collider2D collision)
    {
        tile1.sprite = tile1normal;
        tile2.sprite = tile2normal;
        tile3.sprite = tile3normal;
        tile4.sprite = tile4normal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tile1.sprite = tile1withPlayer;
        tile2.sprite = tile2withPlayer;
        tile3.sprite = tile3withPlayer;
        tile4.sprite = tile4withPlayer;
    }
}
