using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePad : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private bool isPlayerInRange = false;
    [SerializeField] private KeyCode key = KeyCode.E;
    [SerializeField] private string sceneNameToLoad = "";
    private void Start()
    {
        arrow.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(key) && isPlayerInRange)
        {
            print("Loading new scene...");
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            arrow.SetActive(true);
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            arrow.SetActive(false);
        }
    }
}
