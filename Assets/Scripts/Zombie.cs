using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Transform target;
    private Material defaultMaterial;
    private Material whiteMaterial;
    private Renderer rend;
    private int maxHealth = 10;

    public float movementSpeed = 10f;
    public Gradient gradient;
    public HealthBar healthBar;
    public int currentHealth;
    

    private void Start()
    {
        target = WaveSpawner.laneToPush;
        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;
        whiteMaterial = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        
        
        int randomFactor = Random.Range(0, 2);
        if (randomFactor == 1)
        {
            movementSpeed = 15f;
        }


        //health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

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
            currentHealth--;
            healthBar.SetHealth(currentHealth);


            //change the material of game object to shot on hit effect
            rend.material = whiteMaterial;

            Debug.Log("collision detected");
            if (currentHealth <= 0)
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
