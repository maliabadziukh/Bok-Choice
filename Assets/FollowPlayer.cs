using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player = null;
    public void FindPlayer()
    { 
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
