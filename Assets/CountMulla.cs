using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountMulla : MonoBehaviour
{
    public int mulla = 0;
    public TextMeshProUGUI coinDisplay;

    public void Start()
    {
        coinDisplay = GameObject.Find("Coins display").GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        PlayerPrefs.SetInt("Coins", mulla);
        coinDisplay.text = PlayerPrefs.GetInt("Coins").ToString();
        if (Input.GetKeyDown("r"))
            PlayerPrefs.SetInt("Coins", 0);
    }
}
