
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Transform defaultSpawnPoint;
    private void Start()
    {
        GameEvents.levelLoaded.Invoke(defaultSpawnPoint);
    }
}