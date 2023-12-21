using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayData : MonoBehaviour
{
    bool connectedToGooglePlay;

    private void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    private void Start()
    {
        LogInGooglePlay();
    }

    void LogInGooglePlay()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    
    }

    void ProcessAuthentication(SignInStatus signInStatus)
    {
        connectedToGooglePlay = (signInStatus == SignInStatus.Success);
        
    }

    public void LiderboardGlobalPoints(int points)
    {
        Social.ReportScore(points, GPGSIds.leaderboard_global_points, LiderboardUpdate);
    
    }

    void LiderboardUpdate(bool success)
    {
        if (success)
            Debug.Log("Updated Leaderboard");
        else
            Debug.Log("Unable to update Leaderboard");
    
    }

    public void ShowLiderboardGlobalPoints()
    {
        if(!connectedToGooglePlay) LogInGooglePlay();
        Social.ShowLeaderboardUI();
    }


}
