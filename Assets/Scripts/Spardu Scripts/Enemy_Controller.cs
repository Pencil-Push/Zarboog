using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    [Header ("Spawn Parameters")]
    //private float waitTimeBeforeSpawn = 5f;
    private bool insideSpawn = false;
    private GameObject spawnPoint;
    public GameObject SpawnPoint01;
    //public GameObject SpawnPoint02;
    //public GameObject SpawnPoint03;
    //public GameObject SpawnPoint04;
    //public GameObject SpawnPoint05;
    //public GameObject SpawnPoint06;
    public int currPoint;

    [Header ("Ship Prefabs")]
    [SerializeField] private GameObject Ship;

    // Start is called before the first frame update
    void Start()
    {
       //spawnWaitTime = waitTimeBeforeSpawn; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //GameObject Ship = Instantiate(prefab, new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, 0), Quaternion.identity);

        
    }
}
