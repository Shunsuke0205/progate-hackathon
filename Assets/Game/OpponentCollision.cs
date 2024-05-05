using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCollision : MonoBehaviour
{
    [SerializeField] private int playerLife = 3;
    [SerializeField] private GameObject lifePrefab;

    GameObject life1;
    GameObject life2;
    GameObject life3;

    // Start is called before the first frame update
    void Start()
    {
        life1 = Instantiate(lifePrefab, new Vector3(0, 5, 0), Quaternion.identity);
        life2 = Instantiate(lifePrefab, new Vector3(2, 5, 2), Quaternion.identity);
        life3 = Instantiate(lifePrefab, new Vector3(4, 5, 4), Quaternion.identity);
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
            Destroy(oponent.gameObject);
            playerLife -= 1;
            if (playerLife == 2) {
                Destroy(life1);
            } else if (playerLife == 1) {
                Destroy(life2);
            } else if (playerLife == 0) {
                Destroy(life3);
                // TODO: Game Over
            }
        }
        
    }
}
