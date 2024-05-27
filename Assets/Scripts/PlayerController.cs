
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movementVector = new Vector3(horizontal, vertical, 0);
        movementVector = movementVector.normalized * movementSpeed * Time.deltaTime;

        rigidbody.MovePosition(rigidbody.transform.position + movementVector);
    }
}
