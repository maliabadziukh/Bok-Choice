using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountMulla : MonoBehaviour
{
    public GameManager manager;
    public TextMeshProUGUI coinDisplay;

    public void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        coinDisplay = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        coinDisplay.text = manager.mulla.ToString();
    }
}
