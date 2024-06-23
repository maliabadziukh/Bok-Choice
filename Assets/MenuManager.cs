using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadScene(int i)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(i);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(6));
    }

}
