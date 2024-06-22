using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Sprite triggered;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject pressurePad;

    public void OpenSesame()
    {
        print("Open Sesame");
        door.SetActive(false);
        pressurePad.SetActive(true);
        gameObject.GetComponent<SpriteRenderer>().sprite = triggered;
    }
    void Update()
    {
        
    }
}
