using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameManager managerScript;
    public AudioClip coinSound;
    private void Start()
    {
        
        managerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            managerScript.mulla += 1;
            SoundFXManager.instance.PlaySoundFXClip(coinSound,1f);
            Destroy(gameObject);
        }

    }
}
