using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GameState startingState;
    public GameState GameState { get; private set; }
    public LevelManager levelManager;
    public PlayerManager playerManager;
    public List<bool> doorSaves = new List<bool>();
    public int mulla = 0;

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
        GameState = Instantiate(startingState);
        levelManager.GameState = GameState;
        playerManager.GameState = GameState;
        print("Game manager awake.");
    }

    public void ToggleDoorSave(int i)
    {
        if (doorSaves[i] == false)
            doorSaves[i] = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(6,LoadSceneMode.Additive);
        }

    }

}
