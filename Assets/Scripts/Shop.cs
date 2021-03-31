using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    //reference for PlantManager
    PlantManager plantManager;

    // Start is called before the first frame update
    void Start()
    {
        plantManager = PlantManager.Instance;
        
    }

    // Update is called once per frame
    

    public void PurchasePeaShooter()
    {
        plantManager.SetPlant(plantManager.peaShooter);
    }

    public void PurchaseFirePeaShooter()
    {
        plantManager.SetPlant(plantManager.firePeaShooter);
    }

    public void PurchaseIcePeaShooter()
    {
        plantManager.SetPlant(plantManager.icePeaShooter);
    }
}
