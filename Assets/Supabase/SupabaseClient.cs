using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Supabase;
using Zou.Unity.ScoreModel;
using System.Linq;
using System.Threading.Tasks;

public class SupabaseClient : MonoBehaviour
{
    [SerializeField] private string supabaseUrl;
    [SerializeField] private string supabaseKey;

    private Client supabase;

    private async void Awake()
    {
        Debug.Log("Initializing Supabase Client");
        supabase = new Client(supabaseUrl, supabaseKey);
        await supabase.InitializeAsync();
        Debug.Log("Supabase Client Initialized");
        var result = await supabase.From<ScoreModel>().Get();
        var scores = result.Models;
        foreach (var score in scores)
        {
            Debug.Log($"Score: {score.Score}, User: {score.UserName}");
        }
    }

    public async void InsertScore(ScoreModel score)
    {
        var supabase = new Client(supabaseUrl, supabaseKey);
        await supabase.InitializeAsync();
        await supabase.From<ScoreModel>().Insert(score);
    }

    public async Task<List<ScoreModel>> FetchAllScores()
    {
        var result = await supabase.From<ScoreModel>().Order("score", Postgrest.Constants.Ordering.Descending).Get();
        var scores = result.Models;
        foreach (var score in scores)
        {
            Debug.Log($"Score: {score.Score}, User: {score.UserName}");
        }
        return scores.ToList();
    }
}