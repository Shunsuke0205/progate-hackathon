using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawn : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawn_probability = 0.5F;
    [SerializeField] private float spawn_interval = 1.0F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 pos = new Vector3(0, 2, 30);

    // Update is called once per frame
    void Update()
    {   
        int random_value_for_x = Random.Range(0, 3);
        if (random_value_for_x == 0) {
            pos.x = -2.0f;
        } else if (random_value_for_x == 1) {
            pos.x = 0.0f;
        } else {
            pos.x = 2.0f;
        }
        

        float random_value_float = Random.Range(0.0f, 1.0f);
        if (random_value_float < spawn_probability * Time.deltaTime) {
            // プレハブを元にインスタンスを生成
            Instantiate(prefab, pos, Quaternion.identity);
        }

    }
}
