using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Tower towerPrefabs;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }


    void OnMouseDown()
    {
        if (isPlaceable) 
        {
            bool isPlaced = towerPrefabs.CreateTower(towerPrefabs, transform.position);
            isPlaceable = !isPlaced;
            //Instantiate(towerPrefabs, transform.position, Quaternion.identity);
            //isPlaceable = false;
            //Debug.Log(transform.name);
        }
    }
}
