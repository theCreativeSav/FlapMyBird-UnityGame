using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{


    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float topBorder = 20;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
            if (PlayerPrefs.GetInt("IsSFXOn") == 1)
            {

                logic.flapAudSource.clip = logic.wingFlap;
                logic.flapAudSource.Play();
            }
        }

        if (transform.position.y >= 20 || transform.position.y <= -19)
        {
            logic.gameOver();
            birdIsAlive = false;     
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
    