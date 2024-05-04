using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

        Debug.Log ("time (sec.)" + Time.time);
    }
}
