using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour
{

    private Transform target;

    public float shootingRange = 5f;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }

    // Update is called once per frame
    void UpdateTarget()
    {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("zombie");

        float shortestDistance = Mathf.Infinity;
        GameObject nearestZombie = null;

        foreach (GameObject zombie in zombies)
        {
            
            if (transform.position.z == zombie.transform.position.z)
            {

                float distanceToZombie = Vector3.Distance(transform.position, zombie.transform.position);
                if(distanceToZombie < shortestDistance)
                {
                    nearestZombie = zombie;
                }

            }
        }

        if(nearestZombie != null && shortestDistance <= shootingRange)
        {
            target = nearestZombie.transform;
            Debug.Log(gameObject + "nearest enemy " + target);
        }

    }
}
