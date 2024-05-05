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
        scoreText.text = "<align=center><u><b>Score Board</b></u></align>\n";
        foreach (var score in scores)
        {
            scoreText.text += $"<align=left>{score.UserName}</align>: <align=right>{score.Score}</align>\n";
        }
        scoreText.text += "<align=center>-------</align>\n";
    }

    public async void ReDraw()
    {
        scoreText.text = "<b>Score Board</b>\n";
        var scores = await SupabaseClient.FetchAllScores();
        scoreText.text = "<align=center><u><b>Score Board</b></u></align>\n";
        foreach (var score in scores)
        {
            scoreText.text += $"<align=left>{score.UserName}</align>: <align=right>{score.Score}</align>\n";
        }
        scoreText.text += "<align=center>-------</align>\n";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
