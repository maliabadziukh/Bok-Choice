using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "Scripts/GameState", order = 1)]
public class GameState : ScriptableObject
{
    public string playerSpawnLocation = "";

}