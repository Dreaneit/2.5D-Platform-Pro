using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    private Vector3 targetDirection;
    [SerializeField]
    private Transform targetA, targetB;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x == targetB.position.x)
        {
            targetDirection = targetA.position;
        }
        else if (transform.position.x == targetA.position.x)
        {
            targetDirection = targetB.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetDirection, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.transform.parent = transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.transform.parent = null;
            }
        }
    }
}
