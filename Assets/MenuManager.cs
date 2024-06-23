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

    public void Resume()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(6));
    }

}
