using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Establish a rigidbody for the player model (This will hopefully contribute to fixing clipping issue
    private Rigidbody rigidbody;

    //The speed of the player model which can be adjusted in the 
    public int speed = 10;

    //The jump strength variable
    public int jumpStrength = 10;

    //The max playerhealth  
    public int playerHealth = 99;

    //The players points
    public int points = 0;

    //Bullet direction variable dependencies 
    public int direction = 0;


    private Vector3 respawnPoint;

    void Start()
    {
        GetComponent<EndScreen>().SwitchScene(0);
        respawnPoint = transform.position;
        rigidbody = GetComponent<Rigidbody>();
    }



    //The use of fixed update here should also help with reducing wall clipping with player movement
    void FixedUpdate()
    {
        //movement code based on letter keys
        Move();
    }



    void Update()
    {
        jump();
    }
    //Should Set up the movement for left and right keys on the player




    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //variables relevant to the bullet trajectory 
            direction = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //variables relevant to the bullet trajectory 
            direction = 1;
        }
    }
    
    private bool OnGround()
    {
        bool onGround = false;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            onGround = true;
        }

        return onGround;
    }

    //manages he force of the jump on keyspace of the spacebutton while checking if its on the ground to jump
    private void jump()
    {

        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            rigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
    }
    // Update is called once per frame

    public void LoseLife()
    {
        playerHealth--;

        if (playerHealth <= 0)
        {
            GetComponent<EndScreen>().SwitchScene(2);
            //game over
        }
        else
        {

            //respawn
            transform.position = respawnPoint;
        }
    }


    //Helps switch scenes either from startup to main to end screen


    private void OnTriggerEnter(Collider other)
    {
        
    }
}
