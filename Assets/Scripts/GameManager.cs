using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameState startingState;
    public GameState gameState { get; private set; }
    public LevelManager levelManager;
    public PlayerManager playerManager;
    public List<bool> doorSaves = new List<bool>();
    public int mulla = 0;
    public bool isPaused = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            for (int i = 0; i < 3; i++)
            {
                doorSaves.Add(false);
            }
        }
        gameState = Instantiate(startingState);
        levelManager.GameState = gameState;
        playerManager.GameState = gameState;
        print("Game manager awake.");
    }

    public void ToggleDoorSave(int i)
    {
        if (doorSaves[i] == false)
            doorSaves[i] = true;
    }

    public void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape)&& !isPaused && (SceneManager.GetActiveScene().buildIndex!=0))
        {
            isPaused = true;
            Time.timeScale = 0;
            SceneManager.LoadScene(6,LoadSceneMode.Additive);
        }

    }

    public void Respawn()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

}
