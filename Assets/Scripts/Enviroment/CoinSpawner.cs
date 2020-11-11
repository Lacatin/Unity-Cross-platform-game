using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{

    [SerializeField]
    public GameObject prefab;

    public void Spawn(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
     
}
