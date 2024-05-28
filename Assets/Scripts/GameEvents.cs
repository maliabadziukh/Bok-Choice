using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents
{
    public static UnityAction<Transform> onPlaterSpawned;
    public static UnityAction onPlayerDespawned;
    public static UnityAction<Transform> levelLoaded;
    public static UnityAction<string, string> levelExit;
}