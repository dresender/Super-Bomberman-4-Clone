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

    //PickUp Method
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Powerup! " + powerUpType);
            PlayerState playerState = collision.GetComponent<PlayerState>();
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
                    if(playerState.maxBombs < 10) playerState.bombRadius += 1;
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
                    if(playerState.bombRadius < 10) playerState.bombRadius += 1;
                    break;
                case PowerUpType.FullFire:
                    //TODO
                    break;
                case PowerUpType.Geta:
                    if (playerState.speed > 1) playerState.speed -= 1;
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
                    //collision.GetComponent<Player>().bombType = pierceBomb;
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
                    if (playerState.speed < 10) playerState.speed += 1;
                    break;
                case PowerUpType.Sushi:
                    //TODO
                    break;
                case PowerUpType.Time:
                    ControllerManager.Instance.timeController.pauseTime(5f);
                    break;
            }

            //Self-Destruct
            Destroy(this.gameObject);
        }
    }
}
