using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rock : MonoBehaviour
{
    [SerializeField] private bool isPickedUp = false;
    [SerializeField] private bool isPlayerInRange = false;
    [SerializeField] private float bounceDrag;
    public GameObject player = null;
    private bool playerFound = false;
    [SerializeField] private GameObject highlight;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float throwForce = 1;
    [SerializeField] private bool inFlight;
    [SerializeField] private float aimDistanceMultiplier;
    private bool inVoid = false;
    [SerializeField] private Transform resetPoint;
    public AudioClip punchClip;
    public AudioClip pickupClip;
    public AudioClip throwClip;
    public GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            RockLanded(colObject);
            if (colObject.CompareTag("Enemy"))
                SoundFXManager.instance.PlaySoundFXClip(punchClip, 1f);
        }
        if (colObject.CompareTag("Trigger"))
        {
            print("Button triggered");
            colObject.GetComponent<OpenDoor>().OpenSesame(true);
            if(colObject.GetComponent<OpenDoor>().isLeftDoor)
                gameManager.ToggleDoorSave(0);
            else gameManager.ToggleDoorSave(2);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")&& !playerFound)
        {
            player = other.gameObject;
        }

        if (other.gameObject.CompareTag("Player") && !isPickedUp && !inFlight)
        {
            highlight.SetActive(true);
            isPlayerInRange = true;
        }
        if ((other.gameObject.layer == 7))
        {
            print("rock in void");
            inVoid = true;
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !isPickedUp)
        {
            PickUp();
        }
        if ((other.gameObject.layer == 7))
        {
            print("rock in void");
            inVoid = true;
        }

    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            highlight.SetActive(false);
            isPlayerInRange = false;

        }
        if ((other.gameObject.layer == 7))
        {
            print("rock out void");
            inVoid = false;
        }
    }

    void RockLanded(GameObject colObject)
    {
        inFlight = false;
        GetComponent<Collider2D>().isTrigger = true;
        BounceBack();
        if (inVoid) {
            rb.velocity = Vector3.zero;
            transform.position = resetPoint.position;
        }
    }

    void BounceBack()
    {
        rb.velocity = -(rb.velocity);
        rb.drag = bounceDrag;
    }

    private void PickUp()
    {
        SoundFXManager.instance.PlaySoundFXClip(pickupClip, 1f);
        rb.drag = 0;
        isPickedUp = true;
        print("Picked up " + isPickedUp);
        rb.isKinematic = true;
        GetComponent<Collider2D>().enabled = false;
        highlight.SetActive(false);
    }
    public void Throw()
    {
        SoundFXManager.instance.PlaySoundFXClip(throwClip, 1f);
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
