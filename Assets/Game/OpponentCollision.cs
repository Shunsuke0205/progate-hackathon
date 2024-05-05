using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentCollision : MonoBehaviour
{
    [SerializeField] private int playerLife = 3;
    [SerializeField] private GameObject lifePrefab;

    List<GameObject> lifeList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerLife; i++) {
            lifeList.Add(Instantiate(lifePrefab, new Vector3(i * 2, 5, i * 2), Quaternion.identity));
        }
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
            if (playerLife >= 0) {
                Destroy(lifeList[playerLife]);
            }
            if (playerLife == 0) {
                Debug.Log("Game Over");
            }
        }
        
    }
}
