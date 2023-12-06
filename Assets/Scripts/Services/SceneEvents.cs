using System;
using UnityEngine;
using UnityEngine.Events;

public class SceneEvents : MonoBehaviour
{
    public UnityEvent onMenu;
    public UnityEvent onPlay;
    public UnityEvent onEndGame;
    public UnityEvent onAddPoint;
    public UnityEvent<int> onPlayerThemeInput;
    public UnityEvent<int> onWorldThemeInput;

    public void MenuNotify()
    {
        onMenu?.Invoke();
    }
    public void PlayNotify()
    {
        onPlay?.Invoke();
    }
    public void EndGameNotify()
    {
        onEndGame?.Invoke();
    }
    public void AddPointNotify()
    {
        onAddPoint?.Invoke();
    }
    public void PlayerThemeInputNotify(int value)
    {
        onPlayerThemeInput?.Invoke(value);
    }
    public void WorldThemeInputNotify(int value)
    {
        onWorldThemeInput?.Invoke(value);
    }

}