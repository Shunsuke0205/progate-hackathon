using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int x_position_state = 1;

    // Update is called once per frame
    void Update()
    {
        // Debug.Log ("time (sec.)" + Time.time);
    }
    void OnTriggerEnter(Collider oponent)
    {
        Debug.Log("Hit!");
        Debug.Log(oponent.gameObject.name);
        if (oponent.gameObject.name == "CubeObstacle") {
            oponent.transform.position = new Vector3(100, 2, 30);
        }
        
    }
}
