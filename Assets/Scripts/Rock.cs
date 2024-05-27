using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private bool isPickedUp = false;
    [SerializeField] private bool isPlayerInRange = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject highlight;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float throwForce = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        highlight = transform.GetChild(0).gameObject;
        highlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (isPickedUp)
        {
            transform.SetParent(player.transform);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
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
        rb.isKinematic = true;
        GetComponent<Collider2D>().enabled = false;
    }
    public void Throw()
    {
        isPickedUp = false;
        rb.isKinematic = false;
        transform.parent = null;
        rb.AddForce(new Vector2(1, 1) * throwForce, ForceMode2D.Impulse);
        GetComponent<Collider2D>().enabled = true;
    }
}
