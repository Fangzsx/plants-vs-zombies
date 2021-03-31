using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    private Color startColor;
    private Renderer rend;
    private GameObject plant;
    private PlantManager plantManager;

    public Color hoverColor;
    public Vector3 positionOffset;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        plantManager = PlantManager.Instance;
    }


    private void OnMouseEnter()
    {
        if (plant == null)
        {
            rend.material.color = hoverColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if(plant == null)
        {
            Debug.Log("Please select a plant first!");

            if (plant != null)
            {
                Debug.Log("Cannot plant on occupied node!");
                return;
            }
            else
            {
                GameObject plantToSet = plantManager.GetPlant();
                plant = (GameObject)Instantiate(plantToSet, transform.position + positionOffset, transform.rotation);
            }
        }

       

           
    }

    
}
