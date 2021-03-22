using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Transform target;

    public float movementSpeed = 10f;

    private void Start()
    {
        target = WaveSpawner.laneToPush;
        int randomFactor = Random.Range(0, 2);
        if (randomFactor == 1)
        {
            movementSpeed = 15f;
        }
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * movementSpeed * Time.deltaTime, Space.World);

        if(transform.position.x <= target.position.x)
        {
            Destroy(gameObject);
            Debug.Log("Zombie ate your brain!");
            target = null;
            
        }

    }


}
