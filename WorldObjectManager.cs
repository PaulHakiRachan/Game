using System.Collections.Generic;
using UnityEngine;

public class WorldObjectManager : MonoBehaviour
{
    static WorldObjectManager instance;

    [Header("Fog Walls")]
    public List<FogWallInteractable> fogWalls;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddFogWallTolist()
    {
        
    }
}
