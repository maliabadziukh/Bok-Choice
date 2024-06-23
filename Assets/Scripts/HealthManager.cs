using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    public AudioClip damageSound;

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown("h"))
        {
            GetHeal(10);
        }
    }

    public void TakeDamage(float damage)
    {
        SoundFXManager.instance.PlaySoundFXClip(damageSound,1f);
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
