using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private Transform target;

    public float bulletSpeed = 60f;


    public void Seek(Transform _target)
    {
        target = _target;
    }


    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }


        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if(distanceThisFrame <= direction.magnitude)
        {
            Debug.Log("Zombie hit!");
            return;
        }

        transform.Translate(direction.normalized * bulletSpeed, Space.World);

    }
}
