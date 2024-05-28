using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelManager", menuName = "Scripts/LevelManager", order = 1)]
public class LevelManager : ScriptableObject
{
    public GameState GameState { get; set; }
    private void OnEnable()
    {
        GameEvents.levelExit += OnLevelExit;
        Debug.Log("Level Manager active.");
    }
    private void OnLevelExit(string nextLevel, string nextPlayerSpawnName)
    {
        GameState.playerSpawnLocation = nextPlayerSpawnName;
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }

    private void OnDisable()
    {
        GameEvents.levelExit -= OnLevelExit;
    }
}