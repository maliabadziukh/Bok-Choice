using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1;
    public float damage = 10;
    public GameObject player = null;
    public PlayerController playerController;
    public Vector3 playerPosition;
    public Transform playerTransform = null;
    [SerializeField] private float attackRange = 1;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private bool isAttacking;
    private Collider2D col;
    public Vector3 flipLeft;
    private float oldXpos;

    private void Start()
    {
        oldXpos = transform.position.x;
        flipLeft = new Vector3(-1, 1, 1);
    }
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = flipLeft;
        }else transform.localScale = Vector3.one;

        playerPosition = playerTransform.position;
        MoveToTarget(playerPosition);
    }


    void MoveToTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer > attackRange)
        {
            transform.position += movementSpeed * Time.deltaTime * direction;
            isAttacking = false;
        }
        else
        {
            isAttacking = true;
            Attack();
        }
    }

    void Attack()
    {
        print("Attacking player!!!! >:(");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            Destroy(this.gameObject);
        }
    }
}
