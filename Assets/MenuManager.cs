using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadScene(int i)
    {
        if(i == 1)
        {
            GameObject manager = GameObject.Find("GameManager");
            Destroy(manager);
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(i);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
    }

    public void Resume()
    {
        GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        manager.isPaused = false;
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(6));
    }

}
