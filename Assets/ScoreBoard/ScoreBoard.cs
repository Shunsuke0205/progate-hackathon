using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject supabaseClientObject;

    private SupabaseClient SupabaseClient;
    async void Start()
    {
        Debug.Log("Fetching Scores");
        SupabaseClient = supabaseClientObject.GetComponent<SupabaseClient>();
        var scores = await SupabaseClient.FetchAllScores();
        scoreText.text = "<b>Score Board</b>\n";
        int rank = 1;
        foreach (var score in scores)
        {
            scoreText.text += $"#{rank}      ";
            rank++;
            scoreText.text += $"{score.UserName}      {score.Score}\n";
        };
    }

    public async void ReDraw()
    {
        scoreText.text = "<b>Score Board</b>\n";
        var scores = await SupabaseClient.FetchAllScores();
        scoreText.text = "<align=center><b>Score Board</b></align>\n";
        int rank = 1;
        foreach (var score in scores)
        {
            scoreText.text += $"#{rank}      ";
            rank++;
            scoreText.text += $"{score.UserName}      {score.Score}\n";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
