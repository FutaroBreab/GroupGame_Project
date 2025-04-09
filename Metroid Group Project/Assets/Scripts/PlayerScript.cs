using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Establish a rigidbody for the player model (This will hopefully contribute to fixing clipping issue
    private Rigidbody rigidbody;
    //The speed of the player model which can be adjusted in the 
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //The use of fixed update here should also help with reducing wall clipping with player movement
    void FixedUpdate()
    {
        //movement code based on letter keys
        Move();
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.position += Vector3.left * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0,180,0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.position += Vector3.right * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        // Update is called once per frame
        void Update()
    {
        
    }
}
