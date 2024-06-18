using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private bool isPickedUp = false;
    [SerializeField] private bool isPlayerInRange = false;
    public GameObject player = null;
    [SerializeField] private GameObject highlight;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float throwForce = 1;
    [SerializeField] private bool inFlight;
    [SerializeField] private float aimDistanceMultiplier;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        highlight = transform.GetChild(0).gameObject;
        highlight.SetActive(false);
        inFlight = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPickedUp)
        {
            transform.position =
                new Vector3(player.transform.position.x + GetPlayerDir().x * aimDistanceMultiplier, player.transform.position.y + GetPlayerDir().y * aimDistanceMultiplier, this.transform.position.z);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Throw();
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInRange && !isPickedUp)
        {
            PickUp();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject colObject = other.collider.gameObject;
        if ((colObject.CompareTag("Obstacle") || colObject.CompareTag("Enemy")) && inFlight)
        {
            print("rock hits obstacle");
            rb.velocity = Vector3.zero;
            inFlight = false;
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp && !inFlight)
        {
            highlight.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !isPickedUp)
        {
            PickUp();
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            highlight.SetActive(false);
            isPlayerInRange = false;

        }
    }


    public void PickUp()
    {
        isPickedUp = true;
        print("Picked up " + isPickedUp);
        rb.isKinematic = true;
        GetComponent<Collider2D>().enabled = false;
        highlight.SetActive(false);
    }
    public void Throw()
    {
        print("YEET ");
        isPickedUp = false;
        rb.isKinematic = false;
        transform.parent = null;
        rb.AddForce(GetPlayerDir() * throwForce, ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Collider2D>().isTrigger = false;
        inFlight = true;
        isPlayerInRange = false;
    }

    private Vector2 GetPlayerDir()
    {
        return new Vector2(player.GetComponent<PlayerController>().playerDirX, player.GetComponent<PlayerController>().playerDirY);
    }
}
