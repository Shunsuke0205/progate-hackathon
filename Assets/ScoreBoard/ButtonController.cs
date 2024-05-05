using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zou.Unity.ScoreModel;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private GameObject nameField;
    [SerializeField] private Button button;
    [SerializeField] private GameObject supabaseClientObject;
    [SerializeField] private GameObject scoreBoardObject;

    public void OnClick()
    {
        Debug.Log("Button Clicked");
        string name = nameField.GetComponent<TMP_InputField>().text;
        int score = Random.Range(0, 100);
        Debug.Log($"Sending score {name} {score}");
        var supabaseClient = supabaseClientObject.GetComponent<SupabaseClient>();
        supabaseClient.InsertScore(new ScoreModel { UserName = name, Score = score });
        scoreBoardObject.GetComponent<ScoreBoard>().ReDraw();
    }
}
