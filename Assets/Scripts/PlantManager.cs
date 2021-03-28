using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance;
    private GameObject _plant;
    public GameObject peaShooter;
    public GameObject firePeaShooter;
    public GameObject icePeaShooter;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("An error has occured! Multiple PlantManager instance!");
            return;
        }

        Instance = this;
    }

    //return the plant to set
    public GameObject GetPlant()
    {
        return _plant;
    }

    public void SetPlant(GameObject plant)
    {
        _plant = plant;
    }

}
