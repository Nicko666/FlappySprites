using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;
using UnityEngine;

public class GooglePlayController
{
    public Action<bool> isLogged;

    public void SetGooglePlayLogIn()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }
    
    public void OutputRecords()
    {
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
            SetGooglePlayLogIn();

        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
    }

    public void SetLiderboardGlobalPoints(int points)
    {
        if (!PlayGamesPlatform.Instance.IsAuthenticated())
            SetGooglePlayLogIn();

        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ReportScore(points, AndroidConfigurations.leaderboard_global_points, LiderboardUpdate);
    }

    private void ProcessAuthentication(SignInStatus status) =>
        Debug.Log($"Is connected: {status == SignInStatus.Success}");

    private void LiderboardUpdate(bool success) =>
        Debug.Log(success? "Leaderboard sucsess" : "Unable to update Leaderboard");
}