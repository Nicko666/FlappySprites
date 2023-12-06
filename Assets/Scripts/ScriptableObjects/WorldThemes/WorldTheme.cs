using UnityEngine;

[CreateAssetMenu]
public class WorldTheme : ScriptableObject
{
    [SerializeField] Sprite sky;
    [SerializeField] Sprite farBackground;
    [SerializeField] Sprite closeBackground;
    [SerializeField] Sprite obstacles;
    [SerializeField] Sprite platform;

    public Sprite SkySprite => sky;
    public Sprite FarBackground => farBackground;
    public Sprite CloseBackground => closeBackground;
    public Sprite Obstacles => obstacles;
    public Sprite Platform => platform;

}
