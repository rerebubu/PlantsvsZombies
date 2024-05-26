using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    public GameObject sunObject;

    private void Start()
    {
        SpawnSun();

    }



    void SpawnSun()
    {
        GameObject mySun = Instantiate(sunObject,  new Vector3(Random.Range(-4f, 6f), 7, 0), Quaternion.identity);
        mySun.GetComponent<Sun>().dropToYPos = Random.Range(2f, -3f);
        Invoke("SpawnSun", Random.Range(4, 10));


    }



}
