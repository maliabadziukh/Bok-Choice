using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private float damage = 10;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Vector3 playerPosition;
    [SerializeField] private float attackRange = 1;
    [SerializeField] private float distanceToPlayer;
    [SerializeField] private bool isAttacking;

    private Transform playerTransform;
    void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.transform;
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

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
}
