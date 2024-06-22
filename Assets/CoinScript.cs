using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CountMulla managerScript;
    public AudioManager audioScript;
    public AudioClip coinSound;
    private void Start()
    {
        coinSound = GetComponent<AudioClip>();
        managerScript = GameObject.Find("MullaManager").GetComponent<CountMulla>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            managerScript.mulla += 1;
            StartCoroutine(audioScript.PlaySound(coinSound));
            Destroy(gameObject);
        }

    }
}
