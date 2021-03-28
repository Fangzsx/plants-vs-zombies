using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

    private Transform target;

    public GameObject pelletPrefab;
    public Transform firePoint;
    public float shootingRange = 45f;
    public float fireCountdown = 0f; //time between shoot
    public float fireRate = 1f;



    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
    }


    private void Update()
    {
        if(target == null)
        {
            return;
        }

        if(fireCountdown <= 0)
        {

            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
       
        GameObject pelletGO = (GameObject)Instantiate(pelletPrefab, firePoint.position, firePoint.rotation);
        Pellet pellet = pelletGO.GetComponent<Pellet>();

        if(pellet != null)
        {
            pellet.Seek(target);
        }

    }

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
                if(distanceToZombie < shortestDistance )
                {
                    shortestDistance = distanceToZombie;
                    nearestZombie = zombie;

                }
            }

        }

        if(nearestZombie != null && shortestDistance <= shootingRange && nearestZombie.transform.position.x > transform.position.x)
        {
            target = nearestZombie.transform;
        }
        else
        {
            target = null;
        }    

    }
}
