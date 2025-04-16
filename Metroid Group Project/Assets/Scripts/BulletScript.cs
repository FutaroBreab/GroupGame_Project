using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 19;
    public int direction = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Death", 0.25f, 1);   
        if (direction == 0)
        {
            speed *= -1;
        }
    }

    //This kills the crab
    void Death()
    {
        Object.Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed,0,0) * Time.deltaTime;
    }





    //BULLET COLLISIONS YEAAA COLLISIONS
    private void OnCollisionEnter(Collision collision)    
    {

        if (collision.gameObject.GetComponent<Door>())
        {

            collision.gameObject.GetComponent<Door>().HitByBullet();
        Destroy(gameObject);

        }


        if (!collision.gameObject.GetComponent<PlayerScript>())
        {
            Destroy(gameObject);
        }


    }
}
