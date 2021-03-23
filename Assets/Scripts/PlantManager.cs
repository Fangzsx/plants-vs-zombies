using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public static PlantManager Instance;
    public GameObject plantPrefab;

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
        return plantPrefab;
    }

}
