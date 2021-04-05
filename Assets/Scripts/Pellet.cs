using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private Transform target;
    private Renderer rend;
    

    public float bulletSpeed = 60f;
    public GameObject hitEffect;
    


    private void Start()
    {
        rend = GetComponent<Renderer>();
    }


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
        GameObject hitEffectGO = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
        hitEffectGO.GetComponent<Renderer>().material.color = rend.material.color;
        Destroy(gameObject);
        Destroy(hitEffectGO, 1f);
    }
}
