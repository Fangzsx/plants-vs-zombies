﻿using System.Collections;
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

        if(direction.magnitude < distanceThisFrame)
        {
            HitTarget();
        }


        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

    }


    void HitTarget()
    {
        Destroy(gameObject);
    }
}
