using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMoveScript : MonoBehaviour
{
    public float moveSpeed = 2;
    public float deadZone = -85;


    void Start()
    {

    }


    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Debug.Log("cloud deleted");
            Destroy(gameObject);
        }
    }
}
