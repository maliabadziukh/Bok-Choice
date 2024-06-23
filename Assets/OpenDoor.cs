using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Sprite triggered;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject pressurePad;
    public bool isLeftDoor;
    public AudioClip clip;
    public GameManager manager;
    private Scene currentScene;

    private void Awake()
    {
        
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Bottom")
        {
            if (isLeftDoor && manager.doorSaves[0])
                OpenSesame(false);
            else if (!isLeftDoor && manager.doorSaves[1])
                OpenSesame(false);
        }
        else if (currentScene.name == "Left" && manager.doorSaves[2])
            OpenSesame(false);
            
    }

    public void OpenSesame(bool withSound)
    {
        print("Open Sesame");
        if(withSound)
            SoundFXManager.instance.PlaySoundFXClip(clip,1f);
        door.SetActive(false);
        pressurePad.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().sprite = triggered;
    }
}
