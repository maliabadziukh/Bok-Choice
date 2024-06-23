using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public CountMulla managerScript;
    public AudioClip coinSound;
    private void Start()
    {
        
        managerScript = GameObject.Find("MullaManager").GetComponent<CountMulla>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            managerScript.mulla += 1;
            AudioSource.PlayClipAtPoint(coinSound, transform.position,1f);
            Destroy(gameObject);
        }

    }
}
