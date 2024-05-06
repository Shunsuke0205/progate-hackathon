using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoardSpawn : MonoBehaviour
{
    public GameObject scoreBoardPrefab;
    public bool showing = false;
    public bool showed = false;
    public int score = 0;
    public GameObject parentCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(showing == true && showed == false){
           GameObject scoreboard = Instantiate(scoreBoardPrefab, new Vector3(350, 250, 0), Quaternion.identity,
           parentCanvas.transform);
           showed = true;
           GameObject.Find("Text (TMP)").GetComponent<ScoreBoard>().givenScore = score;
        }
    }
}
