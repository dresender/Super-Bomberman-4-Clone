using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTest : MonoBehaviour
{
    public GameObject prefab;
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.x = Mathf.Floor(position.x);
            position.y = Mathf.Floor(position.y);
            position.z = 0;
            Instantiate(prefab, position, Quaternion.identity);
        }
	}
}
