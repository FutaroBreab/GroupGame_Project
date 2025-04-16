using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //Establish a rigidbody for the player model (This will hopefully contribute to fixing clipping issue
    public Rigidbody rb;

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
        rb = GetComponent<Rigidbody>();
        GetComponent<EndScreen>().SwitchScene(0);
        respawnPoint = transform.position;
        
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
            rb.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 180, 0);
            //variables relevant to the bullet trajectory 
            direction = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            rb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
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
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
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




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<LightEnemyScript>())
        {
            //call the script below
        }
    }

    private void InvincibilityFrames()
    {
           //visually make the player fade in and out of transparency or just visibility 
           //while making it so that they dont take damage for the duration of this time 
    }
    
}
