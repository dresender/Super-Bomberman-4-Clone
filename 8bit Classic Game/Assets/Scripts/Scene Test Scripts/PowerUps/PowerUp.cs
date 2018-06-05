using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    BlockPass,
    BombKick,
    BombPass,
    BombUp,
    Cake,
    Corndog,
    Crepe,
    Fire,
    FullFire,
    Geta,
    Heart,
    IceCream,
    InvincibleSuit,
    Jelly,
    PierceBomb,
    Potato,
    PowerGlove,
    Punch,
    Push,
    RemoteControl,
    SamuraiBall,
    SelectItem,
    Skull,
    SpeedUp,
    Sushi,
    Time
};

[RequireComponent(typeof(BoxCollider2D))]
public class PowerUp : MonoBehaviour
{
    //Type of PowerUp
    public PowerUpType powerUpType;

    //Bomb Prefabs
    public GameObject pierceBomb;

    //PickUp Method
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (powerUpType)
            {
                case PowerUpType.BlockPass:
                    //TODO
                    break;
                case PowerUpType.BombKick:
                    //TODO
                    break;
                case PowerUpType.BombPass:
                    //TODO
                    break;
                case PowerUpType.BombUp:
                    //TODO
                    break;
                case PowerUpType.Cake:
                    //TODO
                    break;
                case PowerUpType.Corndog:
                    //TODO
                    break;
                case PowerUpType.Crepe:
                    //TODO
                    break;
                case PowerUpType.Fire:
                    if(collision.GetComponent<Player>().bombRadius < 10) collision.GetComponent<Player>().bombRadius += 1;
                    break;
                case PowerUpType.FullFire:
                    //TODO
                    break;
                case PowerUpType.Geta:
                    if (collision.GetComponent<Player>().speed > 1) collision.GetComponent<Player>().speed -= 1;
                    break;
                case PowerUpType.Heart:
                    //TODO
                    break;
                case PowerUpType.IceCream:
                    //TODO
                    break;
                case PowerUpType.InvincibleSuit:
                    //TODO
                    break;
                case PowerUpType.Jelly:
                    //TODO
                    break;
                case PowerUpType.PierceBomb:
                    collision.GetComponent<Player>().bombType = pierceBomb;
                    break;
                case PowerUpType.Potato:
                    //TODO
                    break;
                case PowerUpType.PowerGlove:
                    //TODO
                    break;
                case PowerUpType.Punch:
                    //TODO
                    break;
                case PowerUpType.Push:
                    //TODO
                    break;
                case PowerUpType.RemoteControl:
                    //TODO
                    break;
                case PowerUpType.SamuraiBall:
                    //TODO
                    break;
                case PowerUpType.SelectItem:
                    //TODO
                    break;
                case PowerUpType.Skull:
                    //TODO
                    break;
                case PowerUpType.SpeedUp:
                    if (collision.GetComponent<Player>().speed < 10) collision.GetComponent<Player>().speed += 1;
                    break;
                case PowerUpType.Sushi:
                    //TODO
                    break;
                case PowerUpType.Time:
                    //TODO
                    break;
            }

            //Self-Destruct
            Destroy(this.gameObject);
        }
    }

    //Scene Test
    public bool isClone = false;
    public Player player;
    private void OnMouseDown()
    {
        if(!isClone)
        {
            GameObject clone = Instantiate(gameObject);

            if(player.currentTarget == player.pointA.position) clone.transform.position = new Vector3(player.transform.position.x - 1.5f, 0.5f, 0f);
            else clone.transform.position = new Vector3(player.transform.position.x + 1.5f, 0.5f, 0f);

            clone.GetComponent<PowerUp>().isClone = true;
        }
    }
}
