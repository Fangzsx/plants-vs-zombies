using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    private Transform target;
    private Material defaultMaterial;
    private Material whiteMaterial;
    private Renderer rend;
    private bool isDead = false;


    public float health;
    public float startHealth = 10f;
    public float movementSpeed = 10f;
    public Image healthBar;
    public float sizeChangeSpeed = 0.05f;
    

    private void Start()
    {
        //set up health
        health = startHealth;

        target = WaveSpawner.laneToPush;
        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;


        //for hit flash effect
        whiteMaterial = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        
        
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pellet"))
        {
            health--;
            healthBar.fillAmount = health / startHealth;


            //change the material of game object to shot on hit effect
            rend.material = whiteMaterial;
            if (health <= 0)
            {
                Destroy(gameObject);
                Debug.Log("zombie died");
                
               
            }
            else
            {
                //return to default material
                Invoke(nameof(ResetMaterial), 0.35f);
            }
        }
        
    }

    void ResetMaterial()
    {
        //default material
        rend.material = defaultMaterial;
    }

}
