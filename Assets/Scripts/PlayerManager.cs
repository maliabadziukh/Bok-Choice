using UnityEngine;

[CreateAssetMenu(fileName = "PlayerManager", menuName = "Scripts/PlayerManager", order = 1)]

public class PlayerManager : ScriptableObject
{
    [SerializeField] private GameObject playerPrefab;
    public GameObject ActivePlayer { get; set; }
    [SerializeField] private GameState startingState;
    public GameState GameState { get; set; }
    public string spawnTag = "Respawn";

    private void OnEnable()
    {
        GameEvents.levelLoaded += SpawnPlayer;
        GameState = Instantiate(startingState);
        Debug.Log("Player Manager active.");

    }

    protected void SpawnPlayer(Transform defaultSpawnTransform)
    {
        Debug.Log("Spawning player!");
        if (GameState.playerSpawnLocation != "")
        {
            GameObject[] spawns = GameObject.FindGameObjectsWithTag(spawnTag);
            bool foundSpawn = false;

            foreach (GameObject spawn in spawns)
                if (spawn.name == GameState.playerSpawnLocation)
                {
                    foundSpawn = true;
                    ActivePlayer = Instantiate(playerPrefab, spawn.transform.position, Quaternion.identity);
                }
            if (!foundSpawn)
            {
                throw new MissingReferenceException("Could not find the player spawn location with the name " + GameState.playerSpawnLocation);
            }

        }
        else
        {
            ActivePlayer = Instantiate(playerPrefab, defaultSpawnTransform.position, Quaternion.identity);
            Debug.Log("Player spawned at default location.");
        }


    }

    private void OnDisable()
    {
        GameEvents.levelLoaded -= SpawnPlayer;
    }
}
