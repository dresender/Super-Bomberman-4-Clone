using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraEggsController : MonoBehaviour
{
    //Variables
    private LinkedList<GameObject> extraEggsList;
    public int delayExtraEggMovement;

    //References
    public GameObject extraEggGameObject;

    // Use this for initialization
    void Start ()
    {
        extraEggsList = new LinkedList<GameObject>();
    }

    //Get Number of Extra Eggs
    public int extraEggsCount()
    {
        return extraEggsList.Count;
    }

    //Get Next Egg
    public GameObject getNextEgg()
    {
        return extraEggsList.First.Value;
    }

    //Stop Eggs
    public void stopEggs()
    {
        foreach (GameObject obj in extraEggsList)
        {
            obj.GetComponent<ExtraEgg>().stopEgg();
        }
    }

    //Move Eggs
    public void moveEggs(Vector2 position)
    {
        foreach(GameObject obj in extraEggsList)
        {
            position = obj.GetComponent<ExtraEgg>().move(position);
        }
    }

    //Move Eggs
    public void rearrangeEggs(Vector2 position)
    {
        Vector2 desiredPosition = extraEggsList.First.Value.transform.position;
        extraEggsList.First.Value.GetComponent<ExtraEgg>().move(position);
        extraEggsList.First.Value.GetComponent<ExtraEgg>().move(desiredPosition);
    }

    //Create Extra Egg
    public void createExtraEgg(Vector2 position)
    {
        GameObject newEgg = Instantiate(extraEggGameObject, position, Quaternion.identity);
        extraEggsList.AddLast(newEgg);
    }

    //Destroy Extra Egg
    public void destroyExtraEgg(GameObject obj)
    {
        Vector2 desiredPosition = obj.transform.position;
        extraEggsList.Remove(obj);
        if (extraEggsList.Count == 2) rearrangeEggs(desiredPosition);
    }
}
