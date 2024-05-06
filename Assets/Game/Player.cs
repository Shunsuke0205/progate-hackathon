using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int playerLife = 3;
    [SerializeField] private GameObject lifePrefab;
    public GameObject canvasSet;
    private bool overed = false;
    ScoreBoardSpawn scoreBoardSpawnScript;

    List<GameObject> lifeList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerLife; i++) {
            lifeList.Add(Instantiate(lifePrefab, new Vector3(i * 2 - 4, 0, -1), Quaternion.identity));
        }
        scoreBoardSpawnScript = canvasSet.GetComponent<ScoreBoardSpawn>();
    }

    int x_position_state = 1;

    // Update is called once per frame
    void Update()
    {
        // 座標を取得
        Vector3 pos = transform.position;

        if (Input.GetKey("j")) {
            pos.x = -2.0f;
        }
        if (Input.GetKey("k")) {
            pos.x = 0.0f;
        }
        if (Input.GetKey("l")) {
            pos.x = 2.0f;
        }
        
        transform.position = pos;

        //Debug.Log ("time (sec.)" + Time.time);
    }

    void OnTriggerEnter(Collider oponent)
    {
        Debug.Log("Hit!");
        // Debug.Log(oponent.gameObject.name);
        if (oponent.gameObject.name == "Meat1(Clone)" || oponent.gameObject.name == "Pumpkin(Clone)") {
            Destroy(oponent.gameObject);
            playerLife -= 1;
            if (playerLife >= 0) {
                Destroy(lifeList[playerLife]);
            }
            if (playerLife == 0) {
                Debug.Log("Game Over");
                if(overed == false){
                    overed = true;
                    scoreBoardSpawnScript.showing = true;
                    scoreBoardSpawnScript.score = (int)Time.time;
                }
            }
        }
        
    }
}
