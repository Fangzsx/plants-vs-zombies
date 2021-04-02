using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private Transform target;

    public float bulletSpeed = 60f;
    public GameObject hitEffect;
    private ParticleSystem.MainModule ps;
    private Renderer rend;


    public void Seek(Transform _target)
    {
        target = _target;
    }


    private void Start()
    {
        ps = hitEffect.GetComponent<ParticleSystem>().main;
        rend = GetComponent<Renderer>();
        

    }


    private void Update()
    {

        ps.startColor = rend.material.color;

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
        Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
