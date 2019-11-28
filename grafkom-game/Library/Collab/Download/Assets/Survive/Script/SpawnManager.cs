using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject foodPrefab;

    void Start()
    {
        // InvokeRepeating("spawnObject", 10f, 15f);
    }

    void spawnObject()
    {
        // Instantiate(foodPrefab, new Vector3(0, 0, 12), foodPrefab.transform.rotation);
    }
}
