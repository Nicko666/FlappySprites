using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using System;

public class GooglePlayData : MonoBehaviour
{
    [SerializeField] CustomLog customLog;

    bool connectedToGooglePlay;


    public void Init()
    {
        try
        {
            LogInGooglePlay();
        }
        catch (Exception e)
        {
            customLog.Log(e.Message);
        }
    }

    void LogInGooglePlay()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);

    }

    void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
            connectedToGooglePlay = true;
        else
            connectedToGooglePlay = false;

    }

    public void LiderboardGlobalPoints(int points)
    {
        if (connectedToGooglePlay)
            Social.ReportScore(points, GPGSIds.leaderboard_global_points, LiderboardUpdate);
    
    }

    void LiderboardUpdate(bool success)
    {
        if (success)
            Debug.Log("Leaderboard sucsess");
        //else
        //    Debug.Log("Unable to update Leaderboard");
    
    }

    public void ShowLiderboardGlobalPoints()
    {
        try
        {
            if (!connectedToGooglePlay) LogInGooglePlay();
            Social.ShowLeaderboardUI();
        }
        catch (Exception e)
        {
            customLog.Log(e.Message);
        }
        
    }


}
