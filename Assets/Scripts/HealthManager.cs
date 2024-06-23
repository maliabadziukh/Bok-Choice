using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public AudioClip damageSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            // load game over screen
            Time.timeScale = 0;
        }

        if (Input.GetKeyDown("h"))
        {
            GetHeal(10);
        }
    }

    public void TakeDamage(float damage)
    {
        AudioSource.PlayClipAtPoint(damageSound, transform.position, 1f);
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void GetHeal(float heal)
    {
        healthAmount += heal;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}