using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{

    public GameObject cloud;
    public float spawnRate = 24;

    private float cloudTimer = 0;

    public LogicScript logic;


   
    void Start()
    {


        SpawnClouds();
        Instantiate(cloud, new Vector3(-26,8), transform.rotation);
        Instantiate(cloud, new Vector3(-10, -8), transform.rotation);
        Instantiate(cloud, new Vector3(26, 0), transform.rotation);
     
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
      

        if (cloudTimer < spawnRate)
        {
            cloudTimer += Time.deltaTime;
        }
        else
        {

            SpawnClouds();
            cloudTimer = 0;
        }


    }

   


    void SpawnClouds()
    {

        Instantiate(cloud, new Vector3(transform.position.x, Random.Range(-21, 21)), transform.rotation);
    }

}
