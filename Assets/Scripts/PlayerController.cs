
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health;
    public Camera cam;
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;
    public float playerDirX;
    public float playerDirY;
    private Vector2 movement;
    private GameObject rock;
    public HealthManager healthScript;
    private List<GameObject> enemies = new List<GameObject>();

    void Start()
    {
        cam = Camera.main;
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        cam.transform.parent = transform;
        healthScript = GameObject.Find("HealthManager").GetComponent<HealthManager>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemies.Add(enemy);
            print("Enemy added");
        }
        foreach (GameObject enemy in enemies)
        {
            SetupEnemyTargeting(enemy);
            print("Enemy target set");
        }
    }

    void SetupEnemyTargeting(GameObject i)
    {
        EnemyController enemyScript = i.GetComponent<EnemyController>();
        enemyScript.player = this.gameObject;
        enemyScript.playerTransform = enemyScript.player.transform;
        enemyScript.playerController = enemyScript.player.GetComponent<PlayerController>();
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
            playerDirX = movement.x;
            playerDirY = movement.y;
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            healthScript.TakeDamage(col.gameObject.GetComponent<EnemyController>().damage);
        }
        if (col.gameObject.CompareTag("Trigger")){
            print("trigger collided");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Consumable"))
        {
            if (healthScript.healthAmount < 100) 
            { 
                healthScript.GetHeal(20);
                Destroy(collision.gameObject);
            }
        }
        if (collision.CompareTag("Trigger"))
        {
            collision.GetComponent<OpenDoor>().OpenSesame();
        }
    }
}