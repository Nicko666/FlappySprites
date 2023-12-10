using UnityEngine;

[CreateAssetMenu]
public class StaticData : ScriptableObject
{
    public GameObject playerPrefab;
    public float jumpForce;
    public float gravityScale;
    public float raycastRadius;

    public PlayerTheme[] playerThemes;
    public WorldTheme[] worldThemes;

    public float playerGravityMultiplyer; //to speed up falling

    public string encryptionCodeWord;
}
