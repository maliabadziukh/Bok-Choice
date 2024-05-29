
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    private Vector2 movement;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.sqrMagnitude > 0.01)
        {
            animator.SetFloat("Hor", movement.x);
            animator.SetFloat("Ver", movement.y);
        }
    }

    void MovePlayer()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 movementVector = new Vector3(movement.x, movement.y, 0);
        movementVector = movementVector.normalized * movementSpeed * Time.deltaTime;

        transform.position += movementSpeed * Time.deltaTime * movementVector;
    }
}